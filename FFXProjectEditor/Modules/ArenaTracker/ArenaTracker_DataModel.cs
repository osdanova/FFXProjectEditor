using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;

namespace FFXProjectEditor.Modules.ArenaTracker
{
    internal partial class ArenaTracker_DataModel : ObservableObject
    {
        private const int _timerMilliseconds = 3000;
        [ObservableProperty] public bool autoRefreshEnabled;

        ObservableCollection<byte> ArenaCounts { get; set; } = new();
        ObservableCollection<bool> ArenaUnlocks { get; set; } = new();

        public ArenaTracker_DataModel()
        {
            ArenaCounts = new ObservableCollection<byte>(Enumerable.Repeat((byte)0, 104));
            ArenaUnlocks = new ObservableCollection<bool>(Enumerable.Repeat(false, 35));
            LoadArenaData();
        }

        public void LoadArenaData()
        {
            byte[] arenaData = ReadArenaData();

            byte[] arenaCounts = arenaData.Take(104).ToArray();
            for(int i = 0; i < 104; i++)
            {
                ArenaCounts[i] = arenaData[i];
            }
            bool[] arenaUnlocks = arenaData.Skip(104).Select(b => b != 0).ToArray();
            for (int i = 0; i < 35; i++)
            {
                ArenaUnlocks[i] = arenaUnlocks[i];
            }
        }

        public byte[] ReadArenaData()
        {
            return MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_ARENA_LIST, 139);
        }
        public void WriteArenaData()
        {
            List<byte> arenaData = new List<byte>(ArenaCounts);
            foreach(bool unlock in ArenaUnlocks)
            {
                arenaData.Add(Convert.ToByte(unlock));
            }
            MemSharp_Service.Instance.Write<byte>(MemoryMap.ADDR_ARENA_LIST, arenaData.ToArray());
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
                                LoadArenaData();
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
