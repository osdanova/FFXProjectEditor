using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.Utils;
using System;
using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Common
{
    // Size 0x16
    public class EquipmentStruct
    {
        [Data(0x0)] public ushort Name_id {  get; set; }
        [Data(0x2)] public bool Exists { get; set; }
        [Data(0x3)] public WeaponFlags Flags { get; set; }
        [Data(0x4)] public Character_Enum Character { get; set; }
        [Data(0x5)] public EquipmentType_Enum Type { get; set; }
        [Data(0x6)] public Character_Enum CharacterEquipped { get; set; }
        [Data(0x7)] public byte Unk7 { get; set; }
        [Data(0x8)] public DamageFormula_Enum Dmg_formula { get; set; }
        [Data(0x9)] public byte Power { get; set; }
        [Data(0xA)] public byte Crit_bonus { get; set; }
        [Data(0xB)] public byte Slot_count { get; set; }
        [Data(0xC)] public ushort Model_id { get; set; }
        [Data(0xE)] public ushort Ability1 { get; set; }
        [Data(0x10)] public ushort Ability2 { get; set; }
        [Data(0x12)] public ushort Ability3 { get; set; }
        [Data(0x14)] public ushort Ability4 { get; set; }

        [Flags]
        public enum WeaponFlags : byte
        {
            IsSummon = 0x01,
            IsHidden = 0x02,
            IsCelestial = 0x04,
            IsBrotherhood = 0x08,
        }

        public bool FlagIsSummon
        {
            get => BitFlag_Util.IsFlagSet(Flags, WeaponFlags.IsSummon);
            set => Flags = BitFlag_Util.SetFlag(Flags, WeaponFlags.IsSummon, value);
        }
        public bool FlagIsHidden
        {
            get => BitFlag_Util.IsFlagSet(Flags, WeaponFlags.IsHidden);
            set => Flags = BitFlag_Util.SetFlag(Flags, WeaponFlags.IsHidden, value);
        }
        public bool FlagIsCelestial
        {
            get => BitFlag_Util.IsFlagSet(Flags, WeaponFlags.IsCelestial);
            set => Flags = BitFlag_Util.SetFlag(Flags, WeaponFlags.IsCelestial, value);
        }
        public bool FlagIsBrotherhood
        {
            get => BitFlag_Util.IsFlagSet(Flags, WeaponFlags.IsBrotherhood);
            set => Flags = BitFlag_Util.SetFlag(Flags, WeaponFlags.IsBrotherhood, value);
        }

        public enum EquipmentType_Enum : byte
        {
            Weapon = 0,
            Armor = 1,
        }
    }
}
