namespace FFXProjectEditor.FfxLib.Dictionaries
{
    public enum DamageFormula_Enum : byte
    {
        NoDamage = 0,
        Normal = 1,
        IgnoreDefense = 2,
        Magic = 3,
        IgnoreMagicDefense = 4,
        TargetHp = 5,
        MultiplesOf50 = 6,
        Healing = 7,
        TargetMaxHp = 8,
        MultiplesOf50R = 9,
        TargetMaxMp = 10,
        TargetTickSpeed = 11,
        TargetMp = 12,
        TargetTickCounter = 13,
        IgnoreDefenseNR = 14,
        SpecialMagic = 15,
        WielderMaxHp = 16,
        WielderHighHp = 17,
        WielderHighMp = 18,
        WielderLowHp = 19,
        SpecialMagicNR = 20,
        GilSpent = 21,
        TargetKillCount = 22,
        MultiplesOf9999 = 23,
    }
}
