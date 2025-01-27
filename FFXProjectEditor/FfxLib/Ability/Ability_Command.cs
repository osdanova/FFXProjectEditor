using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.Utils.Encoding;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;
using static FFXProjectEditor.FfxLib.Ability.Ability_Structs;

namespace FFXProjectEditor.FfxLib.Ability
{
    /*
     * Length: 96
     * Command: Has extra
     * Item: Has extra
     * MonMagic: Doesn't have extra
     */
    public class Ability_Command
    {
        [Data] public short Anim1Id { get; set; }
        [Data] public short Anim2Id { get; set; }
        [Data] public byte IconId { get; set; }
        [Data] public byte CasterAnimId { get; set; }
        [Data] public byte MenuProperties { get; set; }
        [Data] public byte SubSubMenuCategorization { get; set; }
        [Data] public byte SubMenuCategorization { get; set; }
        [Data] public sbyte CharacterUser { get; set; }
        [Data] public byte TargetingFlags { get; set; }
        [Data] public byte TargetsAllowed { get; set; } // Apparently
        [Data] public byte VariousProperties1 { get; set; }
        [Data] public byte VariousProperties2 { get; set; }
        [Data] public byte VariousProperties3 { get; set; }
        [Data] public byte AnimProperties { get; set; }
        [Data] public byte DamageProperties { get; set; }
        [Data] public byte StealGil { get; set; }
        [Data] public byte PartyPreview { get; set; }
        [Data] public byte DamageType { get; set; }
        [Data] public byte MoveRank { get; set; }
        [Data] public byte CostMp { get; set; }
        [Data] public byte CostOverdrive { get; set; }
        [Data] public byte AttackCritBonus { get; set; }
        [Data] public byte DamageFormula { get; set; }
        [Data] public byte AttackAccuracy { get; set; }
        [Data] public byte AttackPower { get; set; }
        [Data] public byte HitCount { get; set; }
        [Data] public byte ShatterChance { get; set; }
        [Data] public byte ElementFlags { get; set; }
        [Data] public StatsusSbyteList StatusChance { get; set; }
        [Data] public StatsusDurationSbyteList StatusDuration { get; set; }
        [Data] public short StatusExtraFlags { get; set; }
        [Data] public short StatBuffFlags { get; set; }
        [Data] public byte OverdriveCategory { get; set; }
        [Data] public byte StatBuffValue { get; set; }
        [Data] public short SpecialBuffFlags { get; set; }
        public ExtraCommandInfo ExtraInfo { get; set; }
        //[Data] public byte OrderingIndexInMenu { get; set; }
        //[Data] public byte SphereTypeForSphereGrid { get; set; }
        //[Data] public byte Unk1 { get; set; }
        //[Data] public byte Unk2 { get; set; }
        public byte[] NameScriptBytes { get; set; }
        public byte[] UnusedText1ScriptBytes { get; set; }
        public byte[] DescriptionScriptBytes { get; set; }
        public byte[] UnusedText2ScriptBytes { get; set; }
        // Text ids kept to keep the original data. Ideally this would be calculated.
        public ushort NameScriptId { get; set; }
        public ushort UnusedText1ScriptId { get; set; }
        public ushort DescriptionScriptId { get; set; }
        public ushort UnusedText2ScriptId { get; set; }

        public Ability_Command()
        {
            StatusChance = new();
            StatusDuration = new();
        }

        public class ExtraCommandInfo
        {
            [Data] public byte OrderingIndexInMenu { get; set; }
            [Data] public byte SphereTypeForSphereGrid { get; set; }
            [Data] public byte Unk1 { get; set; }
            [Data] public byte Unk2 { get; set; }
        }

        public static Ability_Command ReadSingle(byte[] byteFile, bool hasExtraInfo)
        {
            Ability_Command command;
            using (MemoryStream stream = new MemoryStream(byteFile))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                Ability_CommandStruct commandStruct = BinaryMapping.ReadObject<Ability_CommandStruct>(stream);
                if (hasExtraInfo) {
                    commandStruct.AbilityInfo.ExtraInfo = BinaryMapping.ReadObject<ExtraCommandInfo>(stream);
                }
                byte[] textFile = reader.ReadBytes((int)(byteFile.Length - stream.Position));

                command = commandStruct.AbilityInfo;
                command.NameScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(textFile, commandStruct.NameTSInfo.Offset);
                command.UnusedText1ScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(textFile, commandStruct.UnusedText1TSInfo.Offset);
                command.DescriptionScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(textFile, commandStruct.DescriptionTSInfo.Offset);
                command.UnusedText2ScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(textFile, commandStruct.UnusedText2TSInfo.Offset);
                command.NameScriptId = commandStruct.NameTSInfo.ScriptId;
                command.UnusedText1ScriptId = commandStruct.UnusedText1TSInfo.ScriptId;
                command.DescriptionScriptId = commandStruct.DescriptionTSInfo.ScriptId;
                command.UnusedText2ScriptId = commandStruct.UnusedText2TSInfo.ScriptId;
            }

            return command;
        }

        public static List<Ability_Command> ReadList(byte[] byteFile, bool hasExtraInfo)
        {
            EntryListFile listFile = EntryListFile.Unpack(byteFile);

            List<Ability_Command> commandList = new();
            using (MemoryStream stream = new MemoryStream(listFile.FirstFile))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                for(int i = 0; i < listFile.Header.RealEntryCount; i++)
                {
                    Ability_CommandStruct commandStruct = BinaryMapping.ReadObject<Ability_CommandStruct>(stream);
                    if (hasExtraInfo) {
                        commandStruct.AbilityInfo.ExtraInfo = BinaryMapping.ReadObject<ExtraCommandInfo>(stream);
                    }
                    Ability_Command command = new();

                    command = commandStruct.AbilityInfo;
                    command.NameScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(listFile.SecondFile, commandStruct.NameTSInfo.Offset);
                    command.UnusedText1ScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(listFile.SecondFile, commandStruct.UnusedText1TSInfo.Offset);
                    command.DescriptionScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(listFile.SecondFile, commandStruct.DescriptionTSInfo.Offset);
                    command.UnusedText2ScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(listFile.SecondFile, commandStruct.UnusedText2TSInfo.Offset);
                    command.NameScriptId = commandStruct.NameTSInfo.ScriptId;
                    command.UnusedText1ScriptId = commandStruct.UnusedText1TSInfo.ScriptId;
                    command.DescriptionScriptId = commandStruct.DescriptionTSInfo.ScriptId;
                    command.UnusedText2ScriptId = commandStruct.UnusedText2TSInfo.ScriptId;

                    commandList.Add(command);
                }
            }

            return commandList;
        }


        public byte[] WriteSingle(bool hasExtraInfo)
        {
            Ability_CommandStruct commandStruct = new();
            commandStruct.AbilityInfo = this;

            // Text File
            byte[] textFile = new byte[0];

            commandStruct.NameTSInfo.Offset = (ushort)textFile.Length;
            commandStruct.NameTSInfo.ScriptId = NameScriptId;
            textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, NameScriptBytes);

            commandStruct.UnusedText1TSInfo.Offset = (ushort)textFile.Length;
            commandStruct.UnusedText1TSInfo.ScriptId = UnusedText1ScriptId;
            textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, UnusedText1ScriptBytes);

            commandStruct.DescriptionTSInfo.Offset = (ushort)textFile.Length;
            commandStruct.DescriptionTSInfo.ScriptId = DescriptionScriptId;
            textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, DescriptionScriptBytes);

            commandStruct.UnusedText2TSInfo.Offset = (ushort)textFile.Length;
            commandStruct.UnusedText2TSInfo.ScriptId = UnusedText2ScriptId;
            textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, UnusedText2ScriptBytes);

            using (MemoryStream stream = new MemoryStream())
            {
                // Stat sheet
                BinaryMapping.WriteObject(stream, commandStruct);
                if (hasExtraInfo) {
                    BinaryMapping.WriteObject(stream, commandStruct.AbilityInfo.ExtraInfo);
                }

                return stream.ToArray().Concat(textFile).ToArray();
            }
        }

        public static byte[] WriteList(List<Ability_Command> commandList, bool hasExtraInfo)
        {
            List<Ability_CommandStruct> commandStructList = new();

            // Text File
            byte[] textFile = new byte[0];
            foreach (Ability_Command command in commandList)
            {
                Ability_CommandStruct commandStruct = new();

                commandStruct.AbilityInfo = command;

                commandStruct.NameTSInfo.Offset = (ushort)textFile.Length;
                commandStruct.NameTSInfo.ScriptId = command.NameScriptId;
                textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, command.NameScriptBytes);

                commandStruct.UnusedText1TSInfo.Offset = (ushort)textFile.Length;
                commandStruct.UnusedText1TSInfo.ScriptId = command.UnusedText1ScriptId;
                textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, command.UnusedText1ScriptBytes);

                commandStruct.DescriptionTSInfo.Offset = (ushort)textFile.Length;
                commandStruct.DescriptionTSInfo.ScriptId = command.DescriptionScriptId;
                textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, command.DescriptionScriptBytes);

                commandStruct.UnusedText2TSInfo.Offset = (ushort)textFile.Length;
                commandStruct.UnusedText2TSInfo.ScriptId = command.UnusedText2ScriptId;
                textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, command.UnusedText2ScriptBytes);

                commandStructList.Add(commandStruct);
            }

            byte[] listFile;
            using (MemoryStream stream = new MemoryStream())
            {
                foreach (Ability_CommandStruct commandStruct in commandStructList)
                {
                    // Stat sheet
                    BinaryMapping.WriteObject(stream, commandStruct);
                    if (hasExtraInfo) {
                        BinaryMapping.WriteObject(stream, commandStruct.AbilityInfo.ExtraInfo);
                    }
                }

                listFile = stream.ToArray().ToArray();
            }

            return EntryListFile.Pack(0x60, (short)commandList.Count, listFile, textFile);
        }
    }
}
