using Xe.BinaryMapper;
using static FFXProjectEditor.FfxLib.Common.CommonStructs;

namespace FFXProjectEditor.FfxLib.Monster
{
    public class Monster_Structs
    {
        public class MonsterHeaderFile
        {
            [Data] public int Signature { get; set; } // Could be a uint count
            [Data] public int AiFilePointer { get; set; }
            [Data] public int WorkerFilePointer { get; set; }
            [Data] public int StatSheetPointer { get; set; }
            [Data] public int SpoilsFilePointer { get; set; }
            [Data] public int LootFilePointer { get; set; }
            [Data] public int AudioFilePointer { get; set; }
            [Data] public int TextFilePointer { get; set; }
            [Data] public int FileSize { get; set; } // Size of the whole file
            [Data(Count=16)] public byte[] Padding { get; set; } // Aligns the header to 16 bytes

            public MonsterHeaderFile()
            {
                Signature = 8;
                Padding = new byte[16];
            }
        }

        public class MonsterStatSheetStruct
        {
            [Data] public TextScriptInfo NameTSInfo { get; set; }
            [Data] public TextScriptInfo SensorTSInfo { get; set; }
            [Data] public TextScriptInfo UnusedText1TSInfo { get; set; } // みしよう (unused)
            [Data] public TextScriptInfo ScanTSInfo { get; set; }
            [Data] public TextScriptInfo UnusedText2TSInfo { get; set; } // みしよう (unused)
            [Data] public Monster_StatSheet StatSheet { get; set; }
            [Data(Count = 4)] public byte[] Padding { get; set; }

            public MonsterStatSheetStruct()
            {
                NameTSInfo = new();
                SensorTSInfo = new();
                UnusedText1TSInfo = new();
                ScanTSInfo = new();
                UnusedText2TSInfo = new();
                StatSheet = new();
                Padding = new byte[4];
            }
        }
    }
}
