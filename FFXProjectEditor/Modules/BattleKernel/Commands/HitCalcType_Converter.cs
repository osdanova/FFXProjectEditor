using FFXProjectEditor.Utils;
using System.Collections.Generic;
using static FFXProjectEditor.FfxLib.Ability.Ability_Command;

namespace FFXProjectEditor.Modules.BattleKernel.Commands
{
    public class HitCalcType_Converter : BaseEnumStringConverter<HitCalcType>
    {
        public HitCalcType_Converter()
        {
            Options = new Dictionary<HitCalcType, string>
            {
                {HitCalcType.Always, "[0] Always"},
                {HitCalcType.AttackAccuracy, "[1] Attack Accuracy"},
                {HitCalcType.AttackAccuracy_2, "[2] Attack Accuracy"},
                {HitCalcType.Accuracy, "[3] Player Accuracy"},
                {HitCalcType.Accuracy_2, "[4] Player Accuracy"},
                {HitCalcType.Accuracy25, "[5] Player Accuracy * 2.5"},
                {HitCalcType.Accuracy15, "[6] Player Accuracy * 1.5"},
                {HitCalcType.Accuracy05, "[7] Player Accuracy * 0.5"},
            };
        }
    }
}
