using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.Utils;
using System.Collections.Generic;

namespace FFXProjectEditor.Converters
{
    public class DamageFormula_Converter : BaseEnumStringConverter<DamageFormula_Enum>
    {
        public DamageFormula_Converter()
        {
            Options = new Dictionary<DamageFormula_Enum, string>
            {
                {DamageFormula_Enum.NoDamage, "[0] No Damage"},
                {DamageFormula_Enum.Normal, "[1] Normal"},
                {DamageFormula_Enum.IgnoreDefense, "[2] Ignore Defense"},
                {DamageFormula_Enum.Magic, "[3] Magic"},
                {DamageFormula_Enum.IgnoreMagicDefense, "[4] Ignore Magic Defense"},
                {DamageFormula_Enum.TargetHp, "[5] Target Hp"},
                {DamageFormula_Enum.MultiplesOf50, "[6] Multiples Of 50"},
                {DamageFormula_Enum.Healing, "[7] Healing"},
                {DamageFormula_Enum.TargetMaxHp, "[8] Target Max Hp"},
                {DamageFormula_Enum.MultiplesOf50R, "[9] Multiples Of 50 R"},
                {DamageFormula_Enum.TargetMaxMp, "[10] Target Max Mp"},
                {DamageFormula_Enum.TargetTickSpeed, "[11] Target Tick Speed"},
                {DamageFormula_Enum.TargetMp, "[12] Target Mp"},
                {DamageFormula_Enum.TargetTickCounter, "[13] Target Tick Counter"},
                {DamageFormula_Enum.IgnoreDefenseNR, "[14] Ignore Defense NR"},
                {DamageFormula_Enum.SpecialMagic, "[15] Special Magic"},
                {DamageFormula_Enum.WielderMaxHp, "[16] Wielder Max Hp"},
                {DamageFormula_Enum.WielderHighHp, "[17] Wielder High Hp"},
                {DamageFormula_Enum.WielderHighMp, "[18] Wielder High Mp"},
                {DamageFormula_Enum.WielderLowHp, "[19] Wielder Low Hp"},
                {DamageFormula_Enum.SpecialMagicNR, "[20] Special Magic NR"},
                {DamageFormula_Enum.GilSpent, "[21] Gil Spent"},
                {DamageFormula_Enum.TargetKillCount, "[22] Target Kill Count"},
                {DamageFormula_Enum.MultiplesOf9999, "[23] Multiples Of 9999"},
            };
        }
    }
}
