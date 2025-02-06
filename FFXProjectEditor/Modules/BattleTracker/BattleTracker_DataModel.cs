using Avalonia.Controls;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Services;
using FFXProjectEditor.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Timers;
using Xe.BinaryMapper;

namespace FFXProjectEditor.Modules.BattleTracker
{
    internal partial class BattleTracker_DataModel : ObservableObject
    {
        // Settings
        private const byte _enemyCount = 11;
        private const byte _allyCount = 18;
        private const int _timerMilliseconds = 1000;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(AutoRefreshDisabled))][NotifyPropertyChangedFor(nameof(LoadEnabled))] public bool autoRefreshEnabled = false;
        public bool AutoRefreshDisabled => !autoRefreshEnabled;
        public bool LoadEnabled => !autoRefreshEnabled && InBattle && DataLoaded;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(LoadEnabled))] public bool dataLoaded = false;

        // Battle info
        [ObservableProperty][NotifyPropertyChangedFor(nameof(LoadEnabled))] public bool inBattle;
        [ObservableProperty] public string battleName;
        [ObservableProperty] public byte battleIndex;

        // Enemy and Ally lists
        internal List<sbyte> AlliesInBattle = new();
        internal List<MemoryChr> EnemyChrs = new();
        internal List<MemoryChr> AllyChrs = new();
        internal ObservableCollection<BattleTrackerChr_Wrapper> EnemyList { get; set; } = new();
        internal ObservableCollection<BattleTrackerChr_Wrapper> AllyList { get; set; } = new();
        internal ObservableCollection<BattleTrackerChr_Wrapper> DisplayAllyList { get; set; } = new();
        internal ObservableCollection<BattleTrackerChr_Wrapper> DisplayEnemyList { get; set; } = new();

        // Loaded enemy and ally
        internal ContentControl FrameEnemy { get; set; }
        internal BattleTrackerChr_Wrapper LoadedEnemy { get; set; } = new();
        internal ContentControl FrameAlly { get; set; }
        internal BattleTrackerChr_Wrapper LoadedAlly { get; set; } = new();

        public BattleTracker_DataModel(ContentControl frameAlly, ContentControl frameEnemy)
        {
            FrameAlly = frameAlly;
            FrameEnemy = frameEnemy;

            for (int i = 0; i < _allyCount; i++)
            {
                AllyList.Add(new BattleTrackerChr_Wrapper());
            }
            for (int i = 0; i < _enemyCount; i++)
            {
                EnemyList.Add(new BattleTrackerChr_Wrapper());
            }
        }

        public void ReadInfo()
        {
            ReadInBattle();

            if (InBattle)
            {
                ReadBattleData();

                ReadAllyChrs();
                ReadEnemyChrs();
                UpdateAllyList();
                UpdateEnemyList();
                LoadDisplayLists();
                DataLoaded = true;
            }
            else
            {
                DataLoaded = false;
                ClearData();
            }
        }

        public void ReadInBattle()
        {
            InBattle = (MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_BATTLE_ACTIVE) == 1);
        }
        public void ReadBattleData()
        {
            BattleName = (MemSharp_Service.Instance.ReadString(MemoryMap.ADDR_BATTLE_NAME, 13));
            BattleIndex = (MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_BATTLE_ENCOUNTER_INDEX));
        }
        public void ClearData()
        {
            BattleName = "";
            BattleIndex = 0;
            DisplayAllyList.Clear();
            DisplayEnemyList.Clear();
            LoadedAlly = null;
            LoadedEnemy = null;

            FrameAlly.Content = null;
            FrameEnemy.Content = null;
        }

        private void ReadAllyChrs()
        {
            AllyChrs.Clear();

            int allyListAddress = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_BATTLE_PLAYER_LIST);

            for (int i = 0; i < _allyCount; i++)
            {
                int chrAddress = allyListAddress + i * MemoryMap.SIZE_BATTLE_CHR_ENTRY;

                byte[] chrBytes = MemSharp_Service.Instance.Read<byte>(chrAddress, MemoryMap.SIZE_BATTLE_CHR_ENTRY, false);
                MemoryChr thisChr;
                using (MemoryStream stream = new MemoryStream(chrBytes))
                {
                    thisChr = BinaryMapping.ReadObject<MemoryChr>(stream);
                }
                AllyChrs.Add(thisChr);
            }
        }
        private void ReadEnemyChrs()
        {
            EnemyChrs.Clear();

            int enemyListAddress = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_BATTLE_ENEMY_LIST);

            for (int i = 0; i < _enemyCount; i++)
            {
                int chrAddress = enemyListAddress + i * MemoryMap.SIZE_BATTLE_CHR_ENTRY;

                byte[] chrBytes = MemSharp_Service.Instance.Read<byte>(chrAddress, MemoryMap.SIZE_BATTLE_CHR_ENTRY, false);
                MemoryChr thisChr;
                using (MemoryStream stream = new MemoryStream(chrBytes))
                {
                    thisChr = BinaryMapping.ReadObject<MemoryChr>(stream);
                }
                EnemyChrs.Add(thisChr);
            }
        }

        private void UpdateAllyList()
        {
            for (byte i = 0; i < _allyCount; i++)
            {
                MemoryChr thisChr = AllyChrs[i];
                BattleTrackerChr_Wrapper thisWrapper = BattleTrackerChr_Wrapper.Wrap(thisChr);
                thisWrapper.DictionaryId = i;
                thisWrapper.DictionaryName = (Character_Dictionary.Instance.ContainsKey((sbyte)thisWrapper.DictionaryId)) ? Character_Dictionary.Instance[(sbyte)thisWrapper.DictionaryId] : "-";

                PropertyUtil.CopyProperties(thisWrapper, AllyList[i]);
            }
        }
        private void UpdateEnemyList()
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                MemoryChr thisChr = EnemyChrs[i];
                BattleTrackerChr_Wrapper thisWrapper = BattleTrackerChr_Wrapper.Wrap(thisChr);
                thisWrapper.DictionaryId = (short)(thisChr.Id - 0x1000);
                thisWrapper.DictionaryName = (Monster_Dictionary.Instance.ContainsKey(thisWrapper.DictionaryId)) ? Monster_Dictionary.Instance[thisWrapper.DictionaryId] : "-";

                PropertyUtil.CopyProperties(thisWrapper, EnemyList[i]);
            }
        }

        private void LoadDisplayLists()
        {
            DisplayAllyList.Clear();
            DisplayEnemyList.Clear();

            // Allies
            ReadAlliesInBattle();
            foreach (sbyte allyId in AlliesInBattle)
            {
                if(allyId != -1)
                {
                    DisplayAllyList.Add(AllyList[allyId]);
                }
            }
            foreach (BattleTrackerChr_Wrapper thisWrapper in AllyList)
            {
                if (!AlliesInBattle.Contains((sbyte)thisWrapper.Id))
                {
                    DisplayAllyList.Add(thisWrapper);
                }
            }

            // Enemies
            foreach(BattleTrackerChr_Wrapper thisWrapper in EnemyList)
            {
                if (thisWrapper.DictionaryId > 0)
                {
                    DisplayEnemyList.Add(thisWrapper);
                }
            }
        }

        private void ReadAlliesInBattle()
        {
            AlliesInBattle.Clear();
        
            for(int i = 0; i < 3; i++)
            {
                AlliesInBattle.Add(MemSharp_Service.Instance.Read<sbyte>(MemoryMap.ADDR_BATTLE_FORMATION_SLOTS + i));
            }
        }

        public void LoadAlly(BattleTrackerChr_Wrapper chrWrapper)
        {
            LoadedAlly = chrWrapper;
            FrameAlly.Content = new BattleTrackerChr_Control(chrWrapper);
        }
        public void LoadEnemy(BattleTrackerChr_Wrapper chrWrapper)
        {
            LoadedEnemy = chrWrapper;
            FrameEnemy.Content = new BattleTrackerChr_Control(chrWrapper);
        }

        public void LoadIngame()
        {
            if (autoRefreshEnabled || !InBattle || !DataLoaded)
                return;

            int allyListAddress = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_BATTLE_PLAYER_LIST);
            for (byte i = 0; i < _allyCount; i++)
            {
                int chrAddress = allyListAddress + i * MemoryMap.SIZE_BATTLE_CHR_ENTRY;
                byte[] chrBytes = MemSharp_Service.Instance.Read<byte>(chrAddress, MemoryMap.SIZE_BATTLE_CHR_ENTRY, false);

                MemoryChr thisChr = AllyChrs[i];
                BattleTrackerChr_Wrapper thisWrapper = AllyList[i];
                PropertyUtil.CopyProperties(thisWrapper, thisChr);

                using (MemoryStream stream = new MemoryStream(chrBytes))
                {
                    BinaryMapping.WriteObject(stream, thisChr, 0);
                }

                MemSharp_Service.Instance.Write(chrAddress, chrBytes, false);
            }

            int enemyListAddress = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_BATTLE_ENEMY_LIST);
            for (byte i = 0; i < _enemyCount; i++)
            {
                int chrAddress = enemyListAddress + i * MemoryMap.SIZE_BATTLE_CHR_ENTRY;
                byte[] chrBytes = MemSharp_Service.Instance.Read<byte>(chrAddress, MemoryMap.SIZE_BATTLE_CHR_ENTRY, false);

                MemoryChr thisChr = EnemyChrs[i];
                BattleTrackerChr_Wrapper thisWrapper = EnemyList[i];
                PropertyUtil.CopyProperties(thisWrapper, thisChr);

                using (MemoryStream stream = new MemoryStream(chrBytes))
                {
                    BinaryMapping.WriteObject(stream, thisChr, 0);
                }

                MemSharp_Service.Instance.Write(chrAddress, chrBytes, false);
            }
        }

        /******************************************
         * REFRESH TIMER
         ******************************************/
        private Timer _timer = new Timer();
        public void StartReading()
        {
            _timer = new Timer(_timerMilliseconds); // 1-second interval
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true; // Keep running periodically
            _timer.Start();
        }

        public void StopReading()
        {
            if (_timer != null)
            {
                _timer.Elapsed -= OnTimerElapsed; // Unsubscribe event to avoid memory leaks
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                // Enforce the method to run on the UI thread to access the ContentFrames
                Dispatcher.UIThread.Post(() =>
                {
                    try
                    {
                        if (AutoRefreshEnabled)
                        {
                            try
                            {
                                ReadInfo();
                            }
                            catch (Exception ex) { }
                        }
                    }
                    catch (Exception ex) { }
                });
            }
            catch (Exception ex) { }
        }
    }
}
