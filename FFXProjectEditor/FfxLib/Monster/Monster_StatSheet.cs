using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.Utils;
using FFXProjectEditor.Utils.Encoding;
using System;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;
using static FFXProjectEditor.FfxLib.Monster.Monster_Structs;

namespace FFXProjectEditor.FfxLib.Monster
{
    public class Monster_StatSheet
    {
        // Stats
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

        [Data] public PropertyFlags Property_Flags { get; set; }
        [Data] public byte PoisonDamage { get; set; }

        // Elements
        [Data] public ElementalWeaknessData ElementalWeakness { get; set; }

        // Status
        [Data] public StatusByteList StatusResistance { get; set; }

        [Data] public AutoStatusFlags1 AutoStatus_Flags1 { get; set; }
        [Data] public AutoStatusFlags2 AutoStatus_Flags2 { get; set; }
        [Data] public AutoStatusFlags3 AutoStatus_Flags3 { get; set; }
        [Data] public ExtraImmunitiesFlags ExtraImmunities_Flags { get; set; }

        // Abilities
        [Data(Count = 16)] public ushort[] Abilities { get; set; }

        [Data] public ushort ForcedAction { get; set; }
        [Data] public short MonsterId { get; set; }
        [Data] public short ModelId { get; set; }
        [Data] public byte CtbIconId { get; set; }
        [Data] public sbyte DoomCount { get; set; }
        [Data] public sbyte ArenaId { get; set; }
        [Data] public byte ArenaIdPadding { get; set; }
        [Data] public short Model2Id { get; set; }
        public byte[] NameScriptBytes { get; set; }
        public byte[] SensorScriptBytes { get; set; }
        public byte[] UnusedText1ScriptBytes { get; set; }
        public byte[] ScanScriptBytes { get; set; }
        public byte[] UnusedText2ScriptBytes { get; set; }
        // Text ids kept to keep the original data. Ideally this would be calculated.
        public ushort NameScriptId { get; set; }
        public ushort SensorScriptId { get; set; }
        public ushort UnusedText1ScriptId { get; set; }
        public ushort ScanScriptId { get; set; }
        public ushort UnusedText2ScriptId { get; set; }

        public bool Prop_Armored
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.Armored);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.Armored, value);
        }
        public bool Prop_ImmunityFractionalDamage
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunityFractionalDamage);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunityFractionalDamage, value);
        }
        public bool Prop_ImmunityLife
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunityLife);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunityLife, value);
        }
        public bool Prop_ImmunitySensor
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunitySensor);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunitySensor, value);
        }
        public bool Prop_ImmunityScanAgain_Maybe
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunityScanAgain_Maybe);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunityScanAgain_Maybe, value);
        }
        public bool Prop_ImmunityPhysicalDamage
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunityPhysicalDamage);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunityPhysicalDamage, value);
        }
        public bool Prop_ImmunityMagicDamage
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunityMagicDamage);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunityMagicDamage, value);
        }
        public bool Prop_ImmunityAllDamage
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunityAllDamage);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunityAllDamage, value);
        }
        public bool Prop_ImmunityDelay
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunityDelay);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunityDelay, value);
        }
        public bool Prop_ImmunitySlice_Maybe
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunitySlice_Maybe);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunitySlice_Maybe, value);
        }
        public bool Prop_ImmunityBribe_Maybe
        {
            get => BitFlag_Util.IsFlagSet(Property_Flags, PropertyFlags.ImmunityBribe_Maybe);
            set => Property_Flags = BitFlag_Util.SetFlag(Property_Flags, PropertyFlags.ImmunityBribe_Maybe, value);
        }
        // Auto status flags
        public bool Auto_Death
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.Death);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.Death, value);
        }
        public bool Auto_Zombie
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.Zombie);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.Zombie, value);
        }
        public bool Auto_Petrify
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.Petrify);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.Petrify, value);
        }
        public bool Auto_Poison
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.Poison);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.Poison, value);
        }
        public bool Auto_BreakPower
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.BreakPower);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.BreakPower, value);
        }
        public bool Auto_BreakMagic
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.BreakMagic);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.BreakMagic, value);
        }
        public bool Auto_BreakArmor
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.BreakArmor);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.BreakArmor, value);
        }
        public bool Auto_BreakMental
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.BreakMental);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.BreakMental, value);
        }
        public bool Auto_Confuse
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.Confuse);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.Confuse, value);
        }
        public bool Auto_Berserk
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.Berserk);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.Berserk, value);
        }
        public bool Auto_Provoke
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.Provoke);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.Provoke, value);
        }
        public bool Auto_Threaten
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags1, AutoStatusFlags1.Threaten);
            set => AutoStatus_Flags1 = BitFlag_Util.SetFlag(AutoStatus_Flags1, AutoStatusFlags1.Threaten, value);
        }
        public bool Auto_Sleep
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.Sleep);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.Sleep, value);
        }
        public bool Auto_Silence
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.Silence);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.Silence, value);
        }
        public bool Auto_Darkness
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.Darkness);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.Darkness, value);
        }
        public bool Auto_Shell
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.Shell);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.Shell, value);
        }
        public bool Auto_Protect
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.Protect);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.Protect, value);
        }
        public bool Auto_Reflect
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.Reflect);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.Reflect, value);
        }
        public bool Auto_NulTide
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.NulTide);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.NulTide, value);
        }
        public bool Auto_NulBlaze
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.NulBlaze);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.NulBlaze, value);
        }
        public bool Auto_NulShock
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.NulShock);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.NulShock, value);
        }
        public bool Auto_NulFrost
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.NulFrost);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.NulFrost, value);
        }
        public bool Auto_Regen
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.Regen);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.Regen, value);
        }
        public bool Auto_Haste
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.Haste);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.Haste, value);
        }
        public bool Auto_Slow
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags2, AutoStatusFlags2.Slow);
            set => AutoStatus_Flags2 = BitFlag_Util.SetFlag(AutoStatus_Flags2, AutoStatusFlags2.Slow, value);
        }
        public bool Auto_Scan
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Scan);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Scan, value);
        }
        public bool Auto_DistillPower
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.DistillPower);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.DistillPower, value);
        }
        public bool Auto_DistillMana
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.DistillMana);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.DistillMana, value);
        }
        public bool Auto_DistillSpeed
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.DistillSpeed);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.DistillSpeed, value);
        }
        public bool Auto_Unused3_04
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Unused3_04);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Unused3_04, value);
        }
        public bool Auto_DistillAbility
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.DistillAbility);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.DistillAbility, value);
        }
        public bool Auto_Shield
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Shield);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Shield, value);
        }
        public bool Auto_Boost
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Boost);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Boost, value);
        }
        public bool Auto_Eject
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Eject);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Eject, value);
        }
        public bool Auto_AutoLife
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.AutoLife);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.AutoLife, value);
        }
        public bool Auto_Curse
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Curse);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Curse, value);
        }
        public bool Auto_Defend
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Defend);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Defend, value);
        }
        public bool Auto_Guard
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Guard);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Guard, value);
        }
        public bool Auto_Sentinel
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Sentinel);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Sentinel, value);
        }
        public bool Auto_Doom
        {
            get => BitFlag_Util.IsFlagSet(AutoStatus_Flags3, AutoStatusFlags3.Doom);
            set => AutoStatus_Flags3 = BitFlag_Util.SetFlag(AutoStatus_Flags3, AutoStatusFlags3.Doom, value);
        }
        public bool Immunity_Scan
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Scan);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Scan, value);
        }
        public bool Immunity_DistillPower
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.DistillPower);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.DistillPower, value);
        }
        public bool Immunity_DistillMana
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.DistillMana);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.DistillMana, value);
        }
        public bool Immunity_DistillSpeed
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.DistillSpeed);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.DistillSpeed, value);
        }
        public bool Immunity_Unused3_04
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Unused3_04);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Unused3_04, value);
        }
        public bool Immunity_DistillAbility
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.DistillAbility);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.DistillAbility, value);
        }
        public bool Immunity_Shield
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Shield);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Shield, value);
        }
        public bool Immunity_Boost
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Boost);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Boost, value);
        }
        public bool Immunity_Eject
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Eject);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Eject, value);
        }
        public bool Immunity_AutoLife
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.AutoLife);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.AutoLife, value);
        }
        public bool Immunity_Curse
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Curse);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Curse, value);
        }
        public bool Immunity_Defend
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Defend);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Defend, value);
        }
        public bool Immunity_Guard
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Guard);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Guard, value);
        }
        public bool Immunity_Sentinel
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Sentinel);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Sentinel, value);
        }
        public bool Immunity_Doom
        {
            get => BitFlag_Util.IsFlagSet(ExtraImmunities_Flags, ExtraImmunitiesFlags.Doom);
            set => ExtraImmunities_Flags = BitFlag_Util.SetFlag(ExtraImmunities_Flags, ExtraImmunitiesFlags.Doom, value);
        }


        [Flags]
        public enum PropertyFlags : short
        {
            Armored = 0x01,
            ImmunityFractionalDamage = 0x02,
            ImmunityLife = 0x04,
            ImmunitySensor = 0x08,
            ImmunityScanAgain_Maybe = 0x10,
            ImmunityPhysicalDamage = 0x20,
            ImmunityMagicDamage = 0x40,
            ImmunityAllDamage = 0x80,
            ImmunityDelay = 0x100,
            ImmunitySlice_Maybe = 0x200,
            ImmunityBribe_Maybe = 0x400,
        }

        [Flags]
        public enum AutoStatusFlags1 : ushort
        {
            Death = 0x01,
            Zombie = 0x02,
            Petrify = 0x04,
            Poison = 0x08,
            BreakPower = 0x10,
            BreakMagic = 0x20,
            BreakArmor = 0x40,
            BreakMental = 0x80,
            Confuse = 0x0100,
            Berserk = 0x0200,
            Provoke = 0x0400,
            Threaten = 0x0800,
        }
        [Flags]
        public enum AutoStatusFlags2 : ushort
        {
            Sleep = 0x01,
            Silence = 0x02,
            Darkness = 0x04,
            Shell = 0x08,
            Protect = 0x10,
            Reflect = 0x20,
            NulTide = 0x40,
            NulBlaze = 0x80,
            NulShock = 0x0100,
            NulFrost = 0x0200,
            Regen = 0x0400,
            Haste = 0x0800,
            Slow = 0x1000,
        }
        [Flags]
        public enum AutoStatusFlags3 : ushort
        {
            Scan = 0x01,
            DistillPower = 0x02,
            DistillMana = 0x04,
            DistillSpeed = 0x08,
            Unused3_04 = 0x10,
            DistillAbility = 0x20,
            Shield = 0x40,
            Boost = 0x80,
            Eject = 0x0100,
            AutoLife = 0x0200,
            Curse = 0x0400,
            Defend = 0x0800,
            Guard = 0x1000,
            Sentinel = 0x2000,
            Doom = 0x4000,
        }
        [Flags]
        public enum ExtraImmunitiesFlags : ushort
        {
            Scan = 0x01,
            DistillPower = 0x02,
            DistillMana = 0x04,
            DistillSpeed = 0x08,
            Unused3_04 = 0x10,
            DistillAbility = 0x20,
            Shield = 0x40,
            Boost = 0x80,
            Eject = 0x0100,
            AutoLife = 0x0200,
            Curse = 0x0400,
            Defend = 0x0800,
            Guard = 0x1000,
            Sentinel = 0x2000,
            Doom = 0x4000,
        }

        public Monster_StatSheet()
        {
            ElementalWeakness = new();
            Abilities = new ushort[16];
        }

        public static Monster_StatSheet ReadSingle(byte[] byteFile)
        {
            Monster_StatSheet statSheet;
            using (MemoryStream stream = new MemoryStream(byteFile))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                MonsterStatSheetStruct statSheetStruct = BinaryMapping.ReadObject<MonsterStatSheetStruct>(stream);
                byte[] textFile = reader.ReadBytes((int)(byteFile.Length - stream.Position));

                statSheet = statSheetStruct.StatSheet;
                statSheet.NameScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(textFile, statSheetStruct.NameTSInfo.Offset);
                statSheet.SensorScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(textFile, statSheetStruct.SensorTSInfo.Offset);
                statSheet.UnusedText1ScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(textFile, statSheetStruct.UnusedText1TSInfo.Offset);
                statSheet.ScanScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(textFile, statSheetStruct.ScanTSInfo.Offset);
                statSheet.UnusedText2ScriptBytes = FfxEncoding.GetScriptBytesFromTextFile(textFile, statSheetStruct.UnusedText2TSInfo.Offset);
                statSheet.NameScriptId = statSheetStruct.NameTSInfo.ScriptId;
                statSheet.SensorScriptId = statSheetStruct.SensorTSInfo.ScriptId;
                statSheet.UnusedText1ScriptId = statSheetStruct.UnusedText1TSInfo.ScriptId;
                statSheet.ScanScriptId = statSheetStruct.ScanTSInfo.ScriptId;
                statSheet.UnusedText2ScriptId = statSheetStruct.UnusedText2TSInfo.ScriptId;
            }

            return statSheet;
        }

        public byte[] WriteSingle()
        {
            MonsterStatSheetStruct statSheetStruct = new();
            statSheetStruct.StatSheet = this;

            // Text File
            byte[] textFile = new byte[0];

            statSheetStruct.NameTSInfo.Offset = (ushort)textFile.Length;
            statSheetStruct.NameTSInfo.ScriptId = NameScriptId;
            textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, NameScriptBytes);

            statSheetStruct.SensorTSInfo.Offset = (ushort)textFile.Length;
            statSheetStruct.SensorTSInfo.ScriptId = SensorScriptId;
            textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, SensorScriptBytes);

            statSheetStruct.UnusedText1TSInfo.Offset = (ushort)textFile.Length;
            statSheetStruct.UnusedText1TSInfo.ScriptId = UnusedText1ScriptId;
            textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, UnusedText1ScriptBytes);

            statSheetStruct.ScanTSInfo.Offset = (ushort)textFile.Length;
            statSheetStruct.ScanTSInfo.ScriptId = ScanScriptId;
            textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, ScanScriptBytes);

            statSheetStruct.UnusedText2TSInfo.Offset = (ushort)textFile.Length;
            statSheetStruct.UnusedText2TSInfo.ScriptId = UnusedText2ScriptId;
            textFile = FfxEncoding.WriteBytesIntoTextFile(textFile, UnusedText2ScriptBytes);

            using (MemoryStream stream = new MemoryStream())
            {
                // Stat sheet
                BinaryMapping.WriteObject<MonsterStatSheetStruct>(stream, statSheetStruct);

                return stream.ToArray().Concat(textFile).ToArray();
            }
        }
    }
}
