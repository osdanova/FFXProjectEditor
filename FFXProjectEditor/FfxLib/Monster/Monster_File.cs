using System.IO;
using Xe.BinaryMapper;
using static FFXProjectEditor.FfxLib.Monster.Monster_Structs;

namespace FFXProjectEditor.FfxLib.Monster
{
    public class Monster_File
    {
        public byte[] AiFile {  get; set; }
        public byte[] WorkerFile {  get; set; }
        public Monster_StatSheet StatSheetFile {  get; set; }
        public byte[] UnkFile {  get; set; }
        public Monster_Loot LootFile {  get; set; }
        public byte[] AudioFile {  get; set; }
        public byte[] TextFile {  get; set; }

        public static Monster_File Read(byte[] fileByte)
        {
            Monster_File file = new();

            byte[] statSheetByteFile = [];
            byte[] lootByteFile = [];
            using (MemoryStream stream = new MemoryStream(fileByte))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                MonsterHeaderFile header = BinaryMapping.ReadObject<MonsterHeaderFile>(stream);

                int currentEofIndex = header.FileSize;

                if (header.TextFilePointer > 0)
                {
                    stream.Position = header.TextFilePointer;
                    file.TextFile = reader.ReadBytes(currentEofIndex - header.TextFilePointer);
                    currentEofIndex = header.TextFilePointer;
                }

                if (header.AudioFilePointer > 0)
                {
                    stream.Position = header.AudioFilePointer;
                    file.AudioFile = reader.ReadBytes(currentEofIndex - header.AudioFilePointer);
                    currentEofIndex = header.AudioFilePointer;
                }

                if (header.LootFilePointer > 0)
                {
                    stream.Position = header.LootFilePointer;
                    lootByteFile = reader.ReadBytes(currentEofIndex - header.LootFilePointer);
                    currentEofIndex = header.LootFilePointer;
                }

                if (header.SpoilsFilePointer > 0)
                {
                    stream.Position = header.SpoilsFilePointer;
                    file.UnkFile = reader.ReadBytes(currentEofIndex - header.SpoilsFilePointer);
                    currentEofIndex = header.SpoilsFilePointer;
                }

                if (header.StatSheetPointer > 0)
                {
                    stream.Position = header.StatSheetPointer;
                    statSheetByteFile = reader.ReadBytes(currentEofIndex - header.StatSheetPointer);
                    currentEofIndex = header.StatSheetPointer;
                }

                if (header.WorkerFilePointer > 0)
                {
                    stream.Position = header.WorkerFilePointer;
                    file.WorkerFile = reader.ReadBytes(currentEofIndex - header.WorkerFilePointer);
                    currentEofIndex = header.WorkerFilePointer;
                }

                if (header.AiFilePointer > 0)
                {
                    stream.Position = header.AiFilePointer;
                    file.AiFile = reader.ReadBytes(currentEofIndex - header.AiFilePointer);
                }
            }

            if(statSheetByteFile.Length > 0) {
                file.StatSheetFile = Monster_StatSheet.ReadSingle(statSheetByteFile);
            }
            if (lootByteFile.Length > 0)
            {
                file.LootFile = Monster_Loot.ReadSingle(lootByteFile);
            }

            return file;
        }

        public byte[] Write()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                MonsterHeaderFile header = new();

                stream.Position = 0x30;

                if(AiFile != null && AiFile.Length > 0)
                {
                    header.AiFilePointer = (int)stream.Position;
                    writer.Write(AiFile);
                }
                if (WorkerFile != null && WorkerFile.Length > 0)
                {
                    header.WorkerFilePointer = WorkerFile.Length == 0 ? 0 : (int)stream.Position;
                    writer.Write(WorkerFile);
                }
                if (StatSheetFile != null)
                {
                    header.StatSheetPointer = StatSheetFile == null ? 0 : (int)stream.Position;
                    writer.Write(StatSheetFile.WriteSingle());
                    // Note: Files may be aligned to 4 or 8 bytes using 0xFF
                }
                if (UnkFile != null && UnkFile.Length > 0)
                {
                    header.SpoilsFilePointer = UnkFile.Length == 0 ? 0 : (int)stream.Position;
                    writer.Write(UnkFile);
                }
                if (LootFile != null)
                {
                    header.LootFilePointer = LootFile == null ? 0 : (int)stream.Position;
                    writer.Write(LootFile.WriteSingle());
                }
                if (AudioFile != null && AudioFile.Length > 0)
                {
                    header.AudioFilePointer = AudioFile.Length == 0 ? 0 : (int)stream.Position;
                    writer.Write(AudioFile);
                }
                if (TextFile != null && TextFile.Length > 0)
                {
                    header.TextFilePointer = TextFile.Length == 0 ? 0 : (int)stream.Position;
                    writer.Write(TextFile);
                }

                header.FileSize = (int)stream.Length;

                stream.Position = 0;
                BinaryMapping.WriteObject<MonsterHeaderFile>(stream, header);

                return stream.ToArray();
            }
        }
    }
}
