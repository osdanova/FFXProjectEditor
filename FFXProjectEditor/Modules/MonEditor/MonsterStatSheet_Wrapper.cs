using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.FfxLib.Monster;
using FFXProjectEditor.Utils;
using FFXProjectEditor.Utils.Encoding;

namespace FFXProjectEditor.Modules.MonEditor
{
    internal partial class MonsterStatSheet_Wrapper : ObservableObject
    {
        // Stats
        [ObservableProperty] public uint hp;
        [ObservableProperty] public uint mp;
        [ObservableProperty] public uint hpOverkill;
        [ObservableProperty] public byte strength;
        [ObservableProperty] public byte defense;
        [ObservableProperty] public byte magic;
        [ObservableProperty] public byte magicDefense;
        [ObservableProperty] public byte agility;
        [ObservableProperty] public byte luck;
        [ObservableProperty] public byte evasion;
        [ObservableProperty] public byte accuracy;

        [ObservableProperty] public bool prop_Armored;
        [ObservableProperty] public bool prop_ImmunityFractionalDamage;
        [ObservableProperty] public bool prop_ImmunityLife;
        [ObservableProperty] public bool prop_ImmunitySensor;
        [ObservableProperty] public bool prop_ImmunityScanAgain_Maybe;
        [ObservableProperty] public bool prop_ImmunityPhysicalDamage;
        [ObservableProperty] public bool prop_ImmunityMagicDamage;
        [ObservableProperty] public bool prop_ImmunityAllDamage;
        [ObservableProperty] public bool prop_ImmunityDelay;
        [ObservableProperty] public bool prop_ImmunitySlice_Maybe;
        [ObservableProperty] public bool prop_ImmunityBribe_Maybe;

        [ObservableProperty] public byte poisonDamage;

        // Elements
        [ObservableProperty] public ElementalWeaknessData elementalWeakness;

        // Status
        [ObservableProperty] public StatusSbyteList statusResistance;

        [ObservableProperty] public bool auto_Death;
        [ObservableProperty] public bool auto_Zombie;
        [ObservableProperty] public bool auto_Petrify;
        [ObservableProperty] public bool auto_Poison;
        [ObservableProperty] public bool auto_BreakPower;
        [ObservableProperty] public bool auto_BreakMagic;
        [ObservableProperty] public bool auto_BreakArmor;
        [ObservableProperty] public bool auto_BreakMental;
        [ObservableProperty] public bool auto_Confuse;
        [ObservableProperty] public bool auto_Berserk;
        [ObservableProperty] public bool auto_Provoke;
        [ObservableProperty] public bool auto_Threaten;
        [ObservableProperty] public bool auto_Sleep;
        [ObservableProperty] public bool auto_Silence;
        [ObservableProperty] public bool auto_Darkness;
        [ObservableProperty] public bool auto_Shell;
        [ObservableProperty] public bool auto_Protect;
        [ObservableProperty] public bool auto_Reflect;
        [ObservableProperty] public bool auto_NulTide;
        [ObservableProperty] public bool auto_NulBlaze;
        [ObservableProperty] public bool auto_NulShock;
        [ObservableProperty] public bool auto_NulFrost;
        [ObservableProperty] public bool auto_Regen;
        [ObservableProperty] public bool auto_Haste;
        [ObservableProperty] public bool auto_Slow;
        [ObservableProperty] public bool auto_Scan;
        [ObservableProperty] public bool auto_DistillPower;
        [ObservableProperty] public bool auto_DistillMana;
        [ObservableProperty] public bool auto_DistillSpeed;
        [ObservableProperty] public bool auto_DistillAbility;
        [ObservableProperty] public bool auto_Shield;
        [ObservableProperty] public bool auto_Boost;
        [ObservableProperty] public bool auto_Eject;
        [ObservableProperty] public bool auto_AutoLife;
        [ObservableProperty] public bool auto_Curse;
        [ObservableProperty] public bool auto_Defend;
        [ObservableProperty] public bool auto_Guard;
        [ObservableProperty] public bool auto_Sentinel;
        [ObservableProperty] public bool auto_Doom;
        [ObservableProperty] public bool immunity_Scan;
        [ObservableProperty] public bool immunity_DistillPower;
        [ObservableProperty] public bool immunity_DistillMana;
        [ObservableProperty] public bool immunity_DistillSpeed;
        [ObservableProperty] public bool immunity_DistillAbility;
        [ObservableProperty] public bool immunity_Shield;
        [ObservableProperty] public bool immunity_Boost;
        [ObservableProperty] public bool immunity_Eject;
        [ObservableProperty] public bool immunity_AutoLife;
        [ObservableProperty] public bool immunity_Curse;
        [ObservableProperty] public bool immunity_Defend;
        [ObservableProperty] public bool immunity_Guard;
        [ObservableProperty] public bool immunity_Sentinel;
        [ObservableProperty] public bool immunity_Doom;

        // Abilities
        [ObservableProperty] public GameIndex_Wrapper ability1;
        [ObservableProperty] public GameIndex_Wrapper ability2;
        [ObservableProperty] public GameIndex_Wrapper ability3;
        [ObservableProperty] public GameIndex_Wrapper ability4;
        [ObservableProperty] public GameIndex_Wrapper ability5;
        [ObservableProperty] public GameIndex_Wrapper ability6;
        [ObservableProperty] public GameIndex_Wrapper ability7;
        [ObservableProperty] public GameIndex_Wrapper ability8;
        [ObservableProperty] public GameIndex_Wrapper ability9;
        [ObservableProperty] public GameIndex_Wrapper ability10;
        [ObservableProperty] public GameIndex_Wrapper ability11;
        [ObservableProperty] public GameIndex_Wrapper ability12;
        [ObservableProperty] public GameIndex_Wrapper ability13;
        [ObservableProperty] public GameIndex_Wrapper ability14;
        [ObservableProperty] public GameIndex_Wrapper ability15;
        [ObservableProperty] public GameIndex_Wrapper ability16;

        [ObservableProperty] public GameIndex_Wrapper forcedAbility;

        [ObservableProperty] public short monsterId;
        [ObservableProperty] public short modelId;
        [ObservableProperty] public byte ctbIconId;
        [ObservableProperty] public sbyte doomCount;
        [ObservableProperty] public sbyte arenaId;
        [ObservableProperty] public byte arenaIdPadding;
        [ObservableProperty] public short model2Id;


        [ObservableProperty] public byte[] nameScriptBytes;
        [ObservableProperty] public byte[] sensorScriptBytes;
        [ObservableProperty] public byte[] unusedText1ScriptBytes;
        [ObservableProperty] public byte[] scanScriptBytes;
        [ObservableProperty] public byte[] unusedText2ScriptBytes;
        // Text ids kept to keep the original data. Ideally this would be calculated.
        [ObservableProperty] public ushort nameScriptId;
        [ObservableProperty] public ushort sensorScriptId;
        [ObservableProperty] public ushort unusedText1ScriptId;
        [ObservableProperty] public ushort scanScriptId;
        [ObservableProperty] public ushort unusedText2ScriptId;

        string Name => FfxEncoding.DecodeScript(nameScriptBytes).GetString(FfxEncoding.JpDecoder);
        string Sensor => FfxEncoding.DecodeScript(sensorScriptBytes).GetString(FfxEncoding.JpDecoder);
        string Scan => FfxEncoding.DecodeScript(scanScriptBytes).GetString(FfxEncoding.JpDecoder);

        public static MonsterStatSheet_Wrapper Wrap(Monster_StatSheet sheet)
        {
            MonsterStatSheet_Wrapper wrapper = new();

            PropertyUtil.CopyProperties(sheet, wrapper);

            wrapper.Ability1 = GameIndex_Wrapper.Wrap(sheet.Abilities[0]);
            wrapper.Ability2 = GameIndex_Wrapper.Wrap(sheet.Abilities[1]);
            wrapper.Ability3 = GameIndex_Wrapper.Wrap(sheet.Abilities[2]);
            wrapper.Ability4 = GameIndex_Wrapper.Wrap(sheet.Abilities[3]);
            wrapper.Ability5 = GameIndex_Wrapper.Wrap(sheet.Abilities[4]);
            wrapper.Ability6 = GameIndex_Wrapper.Wrap(sheet.Abilities[5]);
            wrapper.Ability7 = GameIndex_Wrapper.Wrap(sheet.Abilities[6]);
            wrapper.Ability8 = GameIndex_Wrapper.Wrap(sheet.Abilities[7]);
            wrapper.Ability9 = GameIndex_Wrapper.Wrap(sheet.Abilities[8]);
            wrapper.Ability10 = GameIndex_Wrapper.Wrap(sheet.Abilities[9]);
            wrapper.Ability11 = GameIndex_Wrapper.Wrap(sheet.Abilities[10]);
            wrapper.Ability12 = GameIndex_Wrapper.Wrap(sheet.Abilities[11]);
            wrapper.Ability13 = GameIndex_Wrapper.Wrap(sheet.Abilities[12]);
            wrapper.Ability14 = GameIndex_Wrapper.Wrap(sheet.Abilities[13]);
            wrapper.Ability15 = GameIndex_Wrapper.Wrap(sheet.Abilities[14]);
            wrapper.Ability16 = GameIndex_Wrapper.Wrap(sheet.Abilities[15]);

            wrapper.ForcedAbility = GameIndex_Wrapper.Wrap(sheet.ForcedAction);

            return wrapper;
        }

        public Monster_StatSheet Unwrap()
        {
            Monster_StatSheet sheet = new();

            PropertyUtil.CopyProperties(this, sheet);

            sheet.Abilities[0] = Ability1.Unwrap();
            sheet.Abilities[1] = Ability2.Unwrap();
            sheet.Abilities[2] = Ability3.Unwrap();
            sheet.Abilities[3] = Ability4.Unwrap();
            sheet.Abilities[4] = Ability5.Unwrap();
            sheet.Abilities[5] = Ability6.Unwrap();
            sheet.Abilities[6] = Ability7.Unwrap();
            sheet.Abilities[7] = Ability8.Unwrap();
            sheet.Abilities[8] = Ability9.Unwrap();
            sheet.Abilities[9] = Ability10.Unwrap();
            sheet.Abilities[10] = Ability11.Unwrap();
            sheet.Abilities[11] = Ability12.Unwrap();
            sheet.Abilities[12] = Ability13.Unwrap();
            sheet.Abilities[13] = Ability14.Unwrap();
            sheet.Abilities[14] = Ability15.Unwrap();
            sheet.Abilities[15] = Ability16.Unwrap();

            sheet.ForcedAction = ForcedAbility.Unwrap();

            return sheet;
        }

    }
}
