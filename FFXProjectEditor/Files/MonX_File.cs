using FFXProjectEditor.Utils.Encoding;
using System.Collections.Generic;
using System.IO;
using Xe.BinaryMapper;

namespace FFXProjectEditor.Files
{
    public class MonX_File
    {
        /******************************************
         * Properties
         ******************************************/
        public Header ThisHeader = new Header();
        public List<Entry> Entries = new List<Entry>();

        /******************************************
         * Constructors
         ******************************************/
        public MonX_File()
        {
            Entries = new List<Entry>();
        }

        /******************************************
         * Functions - Static
         ******************************************/
        public static MonX_File Read(byte[] byteFile)
        {
            MonX_File file = new MonX_File();

            using (MemoryStream stream = new MemoryStream(byteFile))
            using (BinaryReader br = new BinaryReader(stream))
            {
                file.Entries = new List<Entry>();
                file.ThisHeader = BinaryMapping.ReadObject<Header>(stream);
                for (int i = 0; i < file.ThisHeader.EntryCount + 1 - file.ThisHeader.PreviousFileCount; i++)
                //for (int i = 0; i < 185; i++)
                {
                    file.Entries.Add(BinaryMapping.ReadObject<Entry>(stream));
                }

                int textFilePosition = (int)stream.Position;

                foreach (Entry entry in file.Entries)
                {
                    stream.Position = textFilePosition + entry.NameOfst;
                    List<byte> bytesName = new List<byte>();
                    while (stream.Position < stream.Length)
                    {
                        byte by = br.ReadByte();
                        if(by == 0)
                        {
                            break;
                        }
                        bytesName.Add(by);
                    }
                    entry.NameScript = FfxEncoding.DecodeScript(bytesName.ToArray());
                    entry.Name = entry.NameScript.GetString(FfxEncoding.UsDecoder, true);
                    
                    stream.Position = textFilePosition + entry.SensorOfst;
                    List<byte> bytesSensor = new List<byte>();
                    while (stream.Position < stream.Length)
                    {
                        byte by = br.ReadByte();
                        if (by == 0)
                        {
                            break;
                        }
                        bytesSensor.Add(by);
                    }
                    entry.SensorScript = FfxEncoding.DecodeScript(bytesSensor.ToArray());
                    entry.Sensor = entry.SensorScript.GetString(FfxEncoding.UsDecoder, true);

                    stream.Position = textFilePosition + entry.UnkOfst;
                    List<byte> bytesUnk = new List<byte>();
                    while (stream.Position < stream.Length)
                    {
                        byte by = br.ReadByte();
                        if (by == 0)
                        {
                            break;
                        }
                        bytesUnk.Add(by);
                    }
                    entry.UnkScript = FfxEncoding.DecodeScript(bytesUnk.ToArray());
                    entry.Unk = entry.UnkScript.GetString(FfxEncoding.UsDecoder, true);

                    stream.Position = textFilePosition + entry.ScanOfst;
                    List<byte> bytesScan = new List<byte>();
                    while (stream.Position < stream.Length)
                    {
                        byte by = br.ReadByte();
                        if (by == 0)
                        {
                            break;
                        }
                        bytesScan.Add(by);
                    }
                    entry.ScanScript = FfxEncoding.DecodeScript(bytesScan.ToArray());
                    entry.Scan = entry.ScanScript.GetString(FfxEncoding.UsDecoder, true);

                    stream.Position = textFilePosition + entry.Unk2Ofst;
                    List<byte> bytesUnk2 = new List<byte>();
                    while (stream.Position < stream.Length)
                    {
                        byte by = br.ReadByte();
                        if (by == 0)
                        {
                            break;
                        }
                        bytesUnk2.Add(by);
                    }
                    entry.Unk2Script = FfxEncoding.DecodeScript(bytesUnk2.ToArray());
                    entry.Unk2 = entry.Unk2Script.GetString(FfxEncoding.UsDecoder, true);
                }
            }

            return file;
        }

        /******************************************
         * Functions - Local
         ******************************************/
        //public byte[] GetAsByteArray()
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        BaseTable<Entry>.Write(stream, Version, 8, Entries);
        //        return stream.ToArray();
        //    }
        //}

        public class Header
        {
            [Data] public byte VersionMaybe { get; set; }
            [Data(Count=7)] public byte[] UnknownBytes { get; set; } // Probably 4 shorts including the version
            [Data] public short PreviousFileCount { get; set; }
            [Data] public short EntryCount { get; set; } // count - 1
            [Data] public short EntrySize { get; set; }
            [Data] public short EntryTableSize { get; set; }
            [Data] public int TableOffset { get; set; }
        }

        public class Entry
        {
            public FfxEncoding.TextScript NameScript { get; set; }
            public FfxEncoding.TextScript SensorScript { get; set; }
            public FfxEncoding.TextScript UnkScript { get; set; }
            public FfxEncoding.TextScript ScanScript { get; set; }
            public FfxEncoding.TextScript Unk2Script { get; set; }
            public string Name { get; set; }
            public string Sensor { get; set; }
            public string Unk { get; set; }
            public string Scan { get; set; }
            public string Unk2 { get; set; }
            [Data] public ushort NameOfst { get; set; }
            [Data] public ushort NameX { get; set; }
            [Data] public ushort SensorOfst { get; set; }
            [Data] public ushort SensorX { get; set; }
            [Data] public ushort UnkOfst { get; set; }
            [Data] public ushort UnkX { get; set; }
            [Data] public ushort ScanOfst { get; set; }
            [Data] public ushort ScanX { get; set; }
            [Data] public ushort Unk2Ofst { get; set; }
            [Data] public ushort Unk2X { get; set; }
            [Data] public uint Hp { get; set; }
            [Data] public uint Mp { get; set; }
            [Data] public uint HpOverkill { get; set; }
            [Data] public byte Strength { get; set; }
            [Data] public byte Defense { get; set; }
            [Data] public byte Magic { get; set; }
            [Data] public byte MagicDefense { get; set; }
            [Data] public byte Agility { get; set; }
            [Data] public byte Luck { get; set; }
            [Data] public byte Evasion { get; set; }
            [Data] public byte Accuracy { get; set; }
            [Data] public short PropertyFlags { get; set; }
            [Data] public byte PoisonDamage { get; set; }
            [Data] public byte ElementAbsorb { get; set; }
            [Data] public byte ElementImmune { get; set; }
            [Data] public byte ElementResist { get; set; }
            [Data] public byte ElementWeak { get; set; }
            [Data] public sbyte StatusDeath { get; set; }
            [Data] public sbyte StatusZombie { get; set; }
            [Data] public sbyte StatusPetrify { get; set; }
            [Data] public sbyte StatusPoison { get; set; }
            [Data] public sbyte StatusBreakPower { get; set; }
            [Data] public sbyte StatusBreakMagic { get; set; }
            [Data] public sbyte StatusBreakArmor { get; set; }
            [Data] public sbyte StatusBreakMental { get; set; }
            [Data] public sbyte StatusConfuse { get; set; }
            [Data] public sbyte StatusBerserk { get; set; }
            [Data] public sbyte StatusProvoke { get; set; }
            [Data] public sbyte StatusThreaten { get; set; }
            [Data] public sbyte StatusSleep { get; set; }
            [Data] public sbyte StatusSilence { get; set; }
            [Data] public sbyte StatusDarkness { get; set; }
            [Data] public sbyte StatusShell { get; set; }
            [Data] public sbyte StatusProtect { get; set; }
            [Data] public sbyte StatusReflect { get; set; }
            [Data] public sbyte StatusNulTide { get; set; }
            [Data] public sbyte StatusNulBlaze { get; set; }
            [Data] public sbyte StatusNulShock { get; set; }
            [Data] public sbyte StatusNulFrost { get; set; }
            [Data] public sbyte StatusRegen { get; set; }
            [Data] public sbyte StatusHaste { get; set; }
            [Data] public sbyte StatusSlow { get; set; }
            [Data] public short StatusFlags1 { get; set; }
            [Data] public short StatusFlags2 { get; set; }
            [Data] public short StatusFlags3 { get; set; }
            [Data] public short ExtraStatusImmunities { get; set; }
            [Data(Count=16)] public short[] Abilities { get; set; }
            [Data] public short ForcedAction { get; set; }
            [Data] public short MonsterId { get; set; }
            [Data] public short ModelId { get; set; }
            [Data] public byte IconId { get; set; }
            [Data] public sbyte DoomCount { get; set; }
            [Data] public sbyte ArenaId { get; set; }
            [Data] public byte ArenaIdPadding { get; set; }
            [Data] public short Model2Id { get; set; }
            [Data(Count=4)] public byte[] Padding { get; set; }
        }
    }
}
