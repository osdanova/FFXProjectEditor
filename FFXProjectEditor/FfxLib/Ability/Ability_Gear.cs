using FFXProjectEditor.FfxLib.Common;
using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Ability
{
    public class Ability_Gear
    {
        [Data] public byte SosFlag { get; set; }
        [Data] public byte ElementalStrike { get; set; }
        [Data] public ElementalWeaknessData ElementalWeakness { get; set; }
        [Data] public StatusSbyteList StatusChance { get; set; }
        [Data] public StatusDurationSbyteList StatusDuration { get; set; }
        [Data] public StatusSbyteList StatusResistChance { get; set; }
        [Data] public byte StatIncreaseAmount { get; set; }
        [Data] public byte Unk56 { get; set; }
        [Data] public byte StatIncreaseFlags { get; set; }
        [Data] public byte AutoStatus1 { get; set; }
        [Data] public byte AutoStatus2 { get; set; }
        [Data] public byte AutoStatus3 { get; set; }
        [Data] public byte AutoStatus4 { get; set; }
        [Data] public byte Unk5C { get; set; }
        [Data] public byte Unk5D { get; set; }
        [Data] public short StatusExtraFlags { get; set; }
        [Data] public short StatusResistExtraFlags { get; set; }
        [Data] public byte AbilitFlags1 { get; set; }
        [Data] public byte AbilitFlags2 { get; set; }
        [Data] public byte AbilitFlags3 { get; set; }
        [Data] public byte AbilitFlags4 { get; set; }
        [Data] public byte AbilitFlags5 { get; set; }
        [Data] public byte Unk67 { get; set; }
        [Data] public byte Unk68 { get; set; }
        [Data] public byte GroupIndex { get; set; }
        [Data] public byte GroupLevel { get; set; }
        [Data] public byte InternationalBonusIndex { get; set; }
    }
}
