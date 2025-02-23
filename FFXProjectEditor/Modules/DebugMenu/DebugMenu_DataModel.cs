using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Services;
using System.IO;
using Xe.BinaryMapper;

namespace FFXProjectEditor.Modules.DebugMenu
{
    internal partial class DebugMenu_DataModel : ObservableObject
    {
        public Process_Service ProcService { get => Process_Service.Instance; }
        public MemoryBtl.BtlDebug LoadedBtlDebug { get; set; }

        public byte BlitzballWins { get; set; }

        public bool RikkuAlbhedCostume { get; set; }
        public uint YojimboCompatibility { get; set; }

        public ushort LightningTotalAll { get; set; }
        public ushort LightningTotalDodged { get; set; }
        public ushort LightningRecordStreak { get; set; }

        public int ConditionTidusOdCount { get; set; }
        public int ConditionWakkaBattleCount { get; set; }

        public TempleSeals_Wrapper TempleSeals { get; set; }
        public AlbhedCharacters_Wrapper AlbhedCharacters { get; set; }
        public OverdriveUnlock_Wrapper TidusOdUnlock { get; set; }
        public OverdriveUnlock_Wrapper WakkaOdUnlock { get; set; }
        public OverdriveUnlock_Wrapper AuronOdUnlock { get; set; }
        public RonsoRage_Wrapper RonsoRageUnlock { get; set; }

        public DebugMenu_DataModel()
        {
            LoadBtlDebug();
            BlitzballWins = ReadBliztballWins();
            ReadTempleSeals();
            ReadAlbhedCharacters();
            ReadOverdriveData();
            ReadOtherData();
        }

        public void LoadBtlDebug()
        {
            byte[] btlDebugBytes = ReadBtlDebug();
            using (MemoryStream stream = new MemoryStream(btlDebugBytes))
                LoadedBtlDebug = BinaryMapping.ReadObject<MemoryBtl.BtlDebug>(stream);
        }

        public byte[] ReadBtlDebug()
        {
            return MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_BTL_DEBUG_SETTINGS, 0x28);
        }

        public void WriteBtlDebug()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryMapping.WriteObject(stream, LoadedBtlDebug);
                MemSharp_Service.Instance.Write(MemoryMap.ADDR_BTL_DEBUG_SETTINGS, stream.ToArray());
            }
        }


        public byte ReadBliztballWins()
        {
            return MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_BLITZ_WINS);
        }
        public void WriteBliztballWins()
        {
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_BLITZ_WINS, BlitzballWins);
        }
        public void WinBlitzballGame(bool wholeGame = true)
        {
            // Win by 1
            byte score = MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_BLITZ_SCORE_OPPONENT);
            score++;
            MemSharp_Service.Instance.Write<byte>(MemoryMap.ADDR_BLITZ_SCORE_OWN, score);

            // Set phase to second half
            if(wholeGame)MemSharp_Service.Instance.Write<byte>(MemoryMap.ADDR_BLITZ_HALF, 1);

            // Timer to 5 minutes to end phase
            int blitzDataPointer = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_BLITZ_TIMER);
            MemSharp_Service.Instance.Write<ushort>(blitzDataPointer + MemoryMap.OFFSET_BLITZ_TIMER, 300, false);
        }
        public void WinChocoboRace()
        {
            int chocoboDataPointer = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_CHOCOBO_TIMER);

            ChocoboData_Wrapper chocoboData = new ChocoboData_Wrapper();
            chocoboData.bytes = MemSharp_Service.Instance.Read<byte>(chocoboDataPointer + MemoryMap.OFFSET_CHOCOBO_POINTS, 4, false);

            chocoboData.BalloonsOwn = 50;
            chocoboData.HitsOwn = 0;

            MemSharp_Service.Instance.Write(chocoboDataPointer + MemoryMap.OFFSET_CHOCOBO_POINTS, chocoboData.bytes, false);
        }
        public void ResetChocoboTimer()
        {
            int chocoboDataPointer = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_CHOCOBO_TIMER);
            MemSharp_Service.Instance.Write(chocoboDataPointer + MemoryMap.OFFSET_CHOCOBO_TIMER + 1, 0, false);
        }
        public void ReadOverdriveData()
        {
            ConditionTidusOdCount = MemSharp_Service.Instance.Read<int>(MemoryMap.ADDR_TIDUS_OD_COUNT);
            ConditionWakkaBattleCount = MemSharp_Service.Instance.Read<int>(MemoryMap.ADDR_WAKKA_BATTLE_COUNT);
            TidusOdUnlock = new OverdriveUnlock_Wrapper(MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_TIDUS_OD_UNLOCK));
            WakkaOdUnlock = new OverdriveUnlock_Wrapper(MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_WAKKA_OD_UNLOCK));
            AuronOdUnlock = new OverdriveUnlock_Wrapper(MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_AURON_OD_UNLOCK));
            RonsoRageUnlock = new RonsoRage_Wrapper(MemSharp_Service.Instance.Read<ushort>(MemoryMap.ADDR_KHIMARI_OD_UNLOCK));
        }
        public void WriteOverdriveData()
        {
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_TIDUS_OD_COUNT, ConditionTidusOdCount);
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_WAKKA_BATTLE_COUNT, ConditionWakkaBattleCount);
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_TIDUS_OD_UNLOCK, TidusOdUnlock.OdByte);
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_WAKKA_OD_UNLOCK, WakkaOdUnlock.OdByte);
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_AURON_OD_UNLOCK, AuronOdUnlock.OdByte);
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_KHIMARI_OD_UNLOCK, RonsoRageUnlock.RonsoRages);
        }

        public void ReadOtherData()
        {
            RikkuAlbhedCostume = MemSharp_Service.Instance.Read<bool>(MemoryMap.ADDR_SAVE_RIKKU_ALBHED);
            YojimboCompatibility = MemSharp_Service.Instance.Read<uint>(MemoryMap.ADDR_SAVE_YOJIMBO_COMPAT);

            LightningTotalAll = MemSharp_Service.Instance.Read<ushort>(MemoryMap.ADDR_LIGHT_TOTAL_ALL);
            LightningTotalDodged = MemSharp_Service.Instance.Read<ushort>(MemoryMap.ADDR_LIGHT_TOTAL_DODGED);
            LightningRecordStreak = MemSharp_Service.Instance.Read<ushort>(MemoryMap.ADDR_LIGHT_RECORD_STREAK);
        }
        public void WriteOtherData()
        {
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_SAVE_RIKKU_ALBHED, RikkuAlbhedCostume);
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_SAVE_YOJIMBO_COMPAT, YojimboCompatibility);

            MemSharp_Service.Instance.Write(MemoryMap.ADDR_LIGHT_TOTAL_ALL, LightningTotalAll);
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_LIGHT_TOTAL_DODGED, LightningTotalDodged);
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_LIGHT_RECORD_STREAK, LightningRecordStreak);
        }

        public void ReadTempleSeals()
        {
            TempleSeals = TempleSeals_Wrapper.Wrap(MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_SAVE_TEMPLE_SEALS));
        }
        public void WriteTempleSeals()
        {
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_SAVE_TEMPLE_SEALS, TempleSeals.Unwrap());
        }
        public void ReadAlbhedCharacters()
        {
            AlbhedCharacters = new AlbhedCharacters_Wrapper();
            AlbhedCharacters.AlbhedBytes = MemSharp_Service.Instance.Read<uint>(MemoryMap.ADDR_SAVE_ALBHED_CHARACTERS);
        }
        public void WriteAlbhedCharacters()
        {
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_SAVE_ALBHED_CHARACTERS, AlbhedCharacters.AlbhedBytes);
        }
    }
}
