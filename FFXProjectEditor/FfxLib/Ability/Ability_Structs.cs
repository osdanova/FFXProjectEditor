using Xe.BinaryMapper;
using static FFXProjectEditor.FfxLib.Common.CommonStructs;

namespace FFXProjectEditor.FfxLib.Ability
{
    public class Ability_Structs
    {
        public class Ability_CommandStruct
        {
            [Data] public TextScriptInfo NameTSInfo { get; set; }
            [Data] public TextScriptInfo UnusedText1TSInfo { get; set; } // みしよう (unused)
            [Data] public TextScriptInfo DescriptionTSInfo { get; set; }
            [Data] public TextScriptInfo UnusedText2TSInfo { get; set; } // みしよう (unused)
            [Data] public Ability_Command AbilityInfo { get; set; }

            public Ability_CommandStruct()
            {
                NameTSInfo = new();
                UnusedText1TSInfo = new();
                DescriptionTSInfo = new();
                UnusedText2TSInfo = new();
            }
        }
        public class Ability_GearStruct
        {
            [Data] public TextScriptInfo NameTSInfo { get; set; }
            [Data] public TextScriptInfo UnusedText1TSInfo { get; set; } // みしよう (unused)
            [Data] public TextScriptInfo DescriptionTSInfo { get; set; }
            [Data] public TextScriptInfo UnusedText2TSInfo { get; set; } // みしよう (unused)
            [Data] public Ability_Gear AbilityInfo { get; set; }

            public Ability_GearStruct()
            {
                NameTSInfo = new();
                UnusedText1TSInfo = new();
                DescriptionTSInfo = new();
                UnusedText2TSInfo = new();
            }
        }
    }
}
