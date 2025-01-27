using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Common
{
    public class CommonStructs
    {
        public class FileHeader
        {
            [Data] public byte Signature { get; set; } // Could be file version
            [Data(Count = 7)] public byte[] UnknownBytes { get; set; } // Probably 4 shorts including the version
            [Data] public short PreviousFileCount { get; set; } // For split files (Eg: battle/kernel/monster1/2/3.bin)
            [Data] public short EntryCount { get; set; } // Entry count - 1 (Increase by 1 when using it)
            [Data] public short EntrySize { get; set; }
            [Data] public short EntryTableSize { get; set; } // Entry count * size
            [Data] public int EntryTableFileOffset { get; set; } // Size of the header (0x14) Could be 2 shorts
        }

        public class TextScriptInfo
        {
            [Data] public ushort Offset { get; set; }
            [Data] public ushort ScriptId { get; set; } // Possibly unused and possibly wrong
        }
    }
}
