using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Common
{
    public class EntryListFile
    {
        public FileHeader Header { get; set; }
        public byte[] FirstFile { get; set; }
        public byte[] SecondFile { get; set; }

        public EntryListFile()
        {
            Header = new();
        }

        public class FileHeader
        {
            [Data] public byte Signature { get; set; } // Could be file version
            [Data(Count = 7)] public byte[] UnknownBytes { get; set; } // Probably 4 shorts including the version
            [Data] public short PreviousFileCount { get; set; } // For split files (Eg: battle/kernel/monster1/2/3.bin)
            [Data] public short EntryCount { get; set; } // Entry count - 1 (Increase by 1 when using it)
            [Data] public short EntrySize { get; set; }
            [Data] public short EntryTableSize { get; set; } // Entry count * size
            [Data] public int EntryTableFileOffset { get; set; } // Size of the header (0x14) Could be 2 shorts
            public int RealEntryCount => (EntryCount + 1) - PreviousFileCount;

            public FileHeader()
            {
                UnknownBytes = new byte[7];
            }
        }

        public static EntryListFile Unpack(byte[] byteFile)
        {
            EntryListFile file = new();

            using (MemoryStream stream = new MemoryStream(byteFile))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                file.Header = BinaryMapping.ReadObject<FileHeader>(stream);

                file.FirstFile = reader.ReadBytes(file.Header.RealEntryCount * file.Header.EntrySize);
                if(file.Header.EntryTableSize > 0)
                {
                    file.SecondFile = reader.ReadBytes((int)(byteFile.Length - stream.Position));
                }
            }
            return file;
        }

        public static byte[] Pack(short entrySize, short entryCount, byte[] firstFile, byte[] secondFile = null, byte signature = 1, short previousFileCount = 0)
        {
            FileHeader header = new();
            header.Signature = signature;
            header.PreviousFileCount = previousFileCount;
            header.EntryCount = (short)(entryCount - 1);
            header.EntrySize = entrySize;
            header.EntryTableSize = ClampSize(entryCount * entrySize);
            header.EntryTableFileOffset = 0x14;

            byte[] byteFile;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryMapping.WriteObject<FileHeader>(stream, header);
                byteFile = stream.ToArray();
            }

            byteFile = byteFile.Concat(firstFile).ToArray();

            if(secondFile != null) {
                byteFile = byteFile.Concat(secondFile).ToArray();
            }

            return byteFile;
        }

        // Filesize uses 2 bytes. If the size is bigger than what a short can store extra bytes are removed. Eg: /battle/kernel/item_get.bin
        private static short ClampSize(int size)
        {
            // Mask the lower 2 bytes (16 bits) using 0xFFFF
            int lowerTwoBytes = size & 0xFFFF;

            // Cast to short and return
            return (short)lowerTwoBytes;
        }
    }
}
