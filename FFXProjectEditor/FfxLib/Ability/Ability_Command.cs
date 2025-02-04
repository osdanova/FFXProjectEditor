using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.Utils;
using FFXProjectEditor.Utils.Encoding;
using System;
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
        [Data] public MenuFlags MenuFlgs { get; set; }
        [Data] public byte SubSubMenuCategorization { get; set; }
        [Data] public byte SubMenuCategorization { get; set; }
        [Data] public Character_Enum CharacterUser { get; set; }
        [Data] public TargetFlags TargetFlgs { get; set; }
        [Data] public byte TargetsAllowed { get; set; } // Apparently
        [Data] public Misc1Flags Misc1Flgs { get; set; }
        [Data] public Misc2Flags Misc2Flgs { get; set; }
        [Data] public Misc3Flags Misc3Flgs { get; set; }
        [Data] public Misc4Flags Misc4Flgs { get; set; }
        [Data] public DamageFlags DamageFlgs { get; set; }
        [Data] public bool StealGil { get; set; }
        [Data] public PreviewFlags PreviewFlgs { get; set; }
        [Data] public DamageTypeFlags DamageTypeFlgs { get; set; }
        [Data] public byte MoveRank { get; set; }
        [Data] public byte CostMp { get; set; }
        [Data] public byte CostOverdrive { get; set; }
        [Data] public byte AttackCritBonus { get; set; }
        [Data] public byte DamageFormula { get; set; }
        [Data] public byte AttackAccuracy { get; set; }
        [Data] public byte AttackPower { get; set; }
        [Data] public byte HitCount { get; set; }
        [Data] public byte ShatterChance { get; set; }
        [Data] public ElementFlags ElementFlgs { get; set; }
        [Data] public StatusSbyteList StatusChance { get; set; }
        [Data] public StatusDurationSbyteList StatusDuration { get; set; }
        [Data] public StatusFlags StatusFlgs { get; set; }
        [Data] public StatBuffFlags StatBuffFlgs { get; set; }
        [Data] public byte OverdriveCategory { get; set; }
        [Data] public byte StatBuffValue { get; set; }
        [Data] public SpecialBuffFlags SpecialBuffFlgs { get; set; }
        public ExtraCommandInfo ExtraInfo { get; set; }
        public byte[] NameScriptBytes { get; set; }
        public byte[] UnusedText1ScriptBytes { get; set; }
        public byte[] DescriptionScriptBytes { get; set; }
        public byte[] UnusedText2ScriptBytes { get; set; }
        // Text ids kept to keep the original data. Ideally this would be calculated.
        public ushort NameScriptId { get; set; }
        public ushort UnusedText1ScriptId { get; set; }
        public ushort DescriptionScriptId { get; set; }
        public ushort UnusedText2ScriptId { get; set; }


        [Flags]
        public enum MenuFlags : byte
        {
            MainMenu = 0x01,
            OpenCommandMenu = 0x08,
            OpenSpecialMenu = 0x10,
        }
        public bool FlagMenuMainMenu
        {
            get => BitFlag_Util.IsFlagSet(MenuFlgs, MenuFlags.MainMenu);
            set => MenuFlgs = BitFlag_Util.SetFlag(MenuFlgs, MenuFlags.MainMenu, value);
        }
        public bool FlagMenuOpenCommandMenu
        {
            get => BitFlag_Util.IsFlagSet(MenuFlgs, MenuFlags.OpenCommandMenu);
            set => MenuFlgs = BitFlag_Util.SetFlag(MenuFlgs, MenuFlags.OpenCommandMenu, value);
        }
        public bool FlagMenuOpenSpecialMenu
        {
            get => BitFlag_Util.IsFlagSet(MenuFlgs, MenuFlags.OpenSpecialMenu);
            set => MenuFlgs = BitFlag_Util.SetFlag(MenuFlgs, MenuFlags.OpenSpecialMenu, value);
        }

        [Flags]
        public enum TargetFlags : byte
        {
            Enabled = 0x01,
            Enemies = 0x02,
            Multi = 0x04,
            SelfOnly = 0x08,
            Unk10 = 0x10,
            EitherTeam = 0x20,
            Dead = 0x40,
            LongRange = 0x80,
        }
        public bool FlagTargetEnabled
        {
            get => BitFlag_Util.IsFlagSet(TargetFlgs, TargetFlags.Enabled);
            set => TargetFlgs = BitFlag_Util.SetFlag(TargetFlgs, TargetFlags.Enabled, value);
        }
        public bool FlagTargetEnemies
        {
            get => BitFlag_Util.IsFlagSet(TargetFlgs, TargetFlags.Enemies);
            set => TargetFlgs = BitFlag_Util.SetFlag(TargetFlgs, TargetFlags.Enemies, value);
        }
        public bool FlagTargetMulti
        {
            get => BitFlag_Util.IsFlagSet(TargetFlgs, TargetFlags.Multi);
            set => TargetFlgs = BitFlag_Util.SetFlag(TargetFlgs, TargetFlags.Multi, value);
        }
        public bool FlagTargetSelfOnly
        {
            get => BitFlag_Util.IsFlagSet(TargetFlgs, TargetFlags.SelfOnly);
            set => TargetFlgs = BitFlag_Util.SetFlag(TargetFlgs, TargetFlags.SelfOnly, value);
        }
        public bool FlagTargetUnk10
        {
            get => BitFlag_Util.IsFlagSet(TargetFlgs, TargetFlags.Unk10);
            set => TargetFlgs = BitFlag_Util.SetFlag(TargetFlgs, TargetFlags.Unk10, value);
        }
        public bool FlagTargetEitherTeam
        {
            get => BitFlag_Util.IsFlagSet(TargetFlgs, TargetFlags.EitherTeam);
            set => TargetFlgs = BitFlag_Util.SetFlag(TargetFlgs, TargetFlags.EitherTeam, value);
        }
        public bool FlagTargetDead
        {
            get => BitFlag_Util.IsFlagSet(TargetFlgs, TargetFlags.Dead);
            set => TargetFlgs = BitFlag_Util.SetFlag(TargetFlgs, TargetFlags.Dead, value);
        }
        public bool FlagTargetLongRange
        {
            get => BitFlag_Util.IsFlagSet(TargetFlgs, TargetFlags.LongRange);
            set => TargetFlgs = BitFlag_Util.SetFlag(TargetFlgs, TargetFlags.LongRange, value);
        }

        [Flags]
        public enum Misc1Flags : byte
        {
            UseOutsideCombat = 0x01,
            UseInCombat = 0x02,
            DisplayMoveName = 0x04,
            AffectedByDarkness = 0x40,
            AffectedByReflect = 0x80,
        }
        public bool FlagMisc1UseOutsideCombat
        {
            get => BitFlag_Util.IsFlagSet(Misc1Flgs, Misc1Flags.UseOutsideCombat);
            set => Misc1Flgs = BitFlag_Util.SetFlag(Misc1Flgs, Misc1Flags.UseOutsideCombat, value);
        }
        public bool FlagMisc1UseInCombat
        {
            get => BitFlag_Util.IsFlagSet(Misc1Flgs, Misc1Flags.UseInCombat);
            set => Misc1Flgs = BitFlag_Util.SetFlag(Misc1Flgs, Misc1Flags.UseInCombat, value);
        }
        public bool FlagMisc1DisplayMoveName
        {
            get => BitFlag_Util.IsFlagSet(Misc1Flgs, Misc1Flags.DisplayMoveName);
            set => Misc1Flgs = BitFlag_Util.SetFlag(Misc1Flgs, Misc1Flags.DisplayMoveName, value);
        }
        public bool FlagMisc1AffectedByDarkness
        {
            get => BitFlag_Util.IsFlagSet(Misc1Flgs, Misc1Flags.AffectedByDarkness);
            set => Misc1Flgs = BitFlag_Util.SetFlag(Misc1Flgs, Misc1Flags.AffectedByDarkness, value);
        }
        public bool FlagMisc1AffectedByReflect
        {
            get => BitFlag_Util.IsFlagSet(Misc1Flgs, Misc1Flags.AffectedByReflect);
            set => Misc1Flgs = BitFlag_Util.SetFlag(Misc1Flgs, Misc1Flags.AffectedByReflect, value);
        }
        public HitCalcType FlagMisc1HitCalcType
        {
            get => (HitCalcType) (((byte)Misc1Flgs >> 3) & 0b00000111);
            set
            {
                byte valueIn = (byte)((byte)value & 0b00000111);
                byte finalValue = (byte)Misc1Flgs;
                finalValue &= 0b11000111;
                finalValue |= (byte)(valueIn << 3);
                Misc1Flgs = (Misc1Flags)finalValue;
            }
        }
        public enum HitCalcType : byte
        {
            Always = 0,
            AttackAccuracy = 1,
            AttackAccuracy_2 = 2,
            Accuracy = 3,
            Accuracy_2 = 4,
            Accuracy25 = 5,
            Accuracy15 = 6,
            Accuracy05 = 7,
        }

        [Flags]
        public enum Misc2Flags : byte
        {
            AbsorbDamage = 0x01,
            StealItem = 0x02,
            MenuUse = 0x04,
            MenuRight = 0x08,
            MenuLeft = 0x10,
            DelayS = 0x20,
            DelayL = 0x40,
            RandomTargets = 0x80,
        }
        public bool FlagMisc2AbsorbDamage
        {
            get => BitFlag_Util.IsFlagSet(Misc2Flgs, Misc2Flags.AbsorbDamage);
            set => Misc2Flgs = BitFlag_Util.SetFlag(Misc2Flgs, Misc2Flags.AbsorbDamage, value);
        }
        public bool FlagMisc2StealItem
        {
            get => BitFlag_Util.IsFlagSet(Misc2Flgs, Misc2Flags.StealItem);
            set => Misc2Flgs = BitFlag_Util.SetFlag(Misc2Flgs, Misc2Flags.StealItem, value);
        }
        public bool FlagMisc2MenuUse
        {
            get => BitFlag_Util.IsFlagSet(Misc2Flgs, Misc2Flags.MenuUse);
            set => Misc2Flgs = BitFlag_Util.SetFlag(Misc2Flgs, Misc2Flags.MenuUse, value);
        }
        public bool FlagMisc2MenuRight
        {
            get => BitFlag_Util.IsFlagSet(Misc2Flgs, Misc2Flags.MenuRight);
            set => Misc2Flgs = BitFlag_Util.SetFlag(Misc2Flgs, Misc2Flags.MenuRight, value);
        }
        public bool FlagMisc2MenuLeft
        {
            get => BitFlag_Util.IsFlagSet(Misc2Flgs, Misc2Flags.MenuLeft);
            set => Misc2Flgs = BitFlag_Util.SetFlag(Misc2Flgs, Misc2Flags.MenuLeft, value);
        }
        public bool FlagMisc2DelayS
        {
            get => BitFlag_Util.IsFlagSet(Misc2Flgs, Misc2Flags.DelayS);
            set => Misc2Flgs = BitFlag_Util.SetFlag(Misc2Flgs, Misc2Flags.DelayS, value);
        }
        public bool FlagMisc2DelayL
        {
            get => BitFlag_Util.IsFlagSet(Misc2Flgs, Misc2Flags.DelayL);
            set => Misc2Flgs = BitFlag_Util.SetFlag(Misc2Flgs, Misc2Flags.DelayL, value);
        }
        public bool FlagMisc2RandomTargets
        {
            get => BitFlag_Util.IsFlagSet(Misc2Flgs, Misc2Flags.RandomTargets);
            set => Misc2Flgs = BitFlag_Util.SetFlag(Misc2Flgs, Misc2Flags.RandomTargets, value);
        }

        [Flags]
        public enum Misc3Flags : byte
        {
            Piercing = 0x01,
            AffectedBySilence = 0x02,
            UseWeaponProps = 0x04,
            TriggerCommand = 0x08,
            CastAnimS = 0x10,
            CastAnimL = 0x20,
            DestroyCaster = 0x40,
            MissToAlive = 0x80,
        }
        public bool FlagMisc3Piercing
        {
            get => BitFlag_Util.IsFlagSet(Misc3Flgs, Misc3Flags.Piercing);
            set => Misc3Flgs = BitFlag_Util.SetFlag(Misc3Flgs, Misc3Flags.Piercing, value);
        }
        public bool FlagMisc3AffectedBySilence
        {
            get => BitFlag_Util.IsFlagSet(Misc3Flgs, Misc3Flags.AffectedBySilence);
            set => Misc3Flgs = BitFlag_Util.SetFlag(Misc3Flgs, Misc3Flags.AffectedBySilence, value);
        }
        public bool FlagMisc3UseWeaponProps
        {
            get => BitFlag_Util.IsFlagSet(Misc3Flgs, Misc3Flags.UseWeaponProps);
            set => Misc3Flgs = BitFlag_Util.SetFlag(Misc3Flgs, Misc3Flags.UseWeaponProps, value);
        }
        public bool FlagMisc3TriggerCommand
        {
            get => BitFlag_Util.IsFlagSet(Misc3Flgs, Misc3Flags.TriggerCommand);
            set => Misc3Flgs = BitFlag_Util.SetFlag(Misc3Flgs, Misc3Flags.TriggerCommand, value);
        }
        public bool FlagMisc3CastAnimS
        {
            get => BitFlag_Util.IsFlagSet(Misc3Flgs, Misc3Flags.CastAnimS);
            set => Misc3Flgs = BitFlag_Util.SetFlag(Misc3Flgs, Misc3Flags.CastAnimS, value);
        }
        public bool FlagMisc3CastAnimL
        {
            get => BitFlag_Util.IsFlagSet(Misc3Flgs, Misc3Flags.CastAnimL);
            set => Misc3Flgs = BitFlag_Util.SetFlag(Misc3Flgs, Misc3Flags.CastAnimL, value);
        }
        public bool FlagMisc3DestroyCaster
        {
            get => BitFlag_Util.IsFlagSet(Misc3Flgs, Misc3Flags.DestroyCaster);
            set => Misc3Flgs = BitFlag_Util.SetFlag(Misc3Flgs, Misc3Flags.DestroyCaster, value);
        }
        public bool FlagMisc3MissToAlive
        {
            get => BitFlag_Util.IsFlagSet(Misc3Flgs, Misc3Flags.MissToAlive);
            set => Misc3Flgs = BitFlag_Util.SetFlag(Misc3Flgs, Misc3Flags.MissToAlive, value);
        }

        [Flags]
        public enum Misc4Flags : byte
        {
            ChargeWarriorHealer = 0x01,
            EmptyOverdrive = 0x02,
            ShowSpellcastAura = 0x04,
            RunOffScreen = 0x08,
            CopycatEnabled = 0x10,
            Unk20 = 0x20,
            AeonOverdrive = 0x40,
            Bribe = 0x80,
        }
        public bool FlagMisc4ChargeWarriorHealer
        {
            get => BitFlag_Util.IsFlagSet(Misc4Flgs, Misc4Flags.ChargeWarriorHealer);
            set => Misc4Flgs = BitFlag_Util.SetFlag(Misc4Flgs, Misc4Flags.ChargeWarriorHealer, value);
        }
        public bool FlagMisc4EmptyOverdrive
        {
            get => BitFlag_Util.IsFlagSet(Misc4Flgs, Misc4Flags.EmptyOverdrive);
            set => Misc4Flgs = BitFlag_Util.SetFlag(Misc4Flgs, Misc4Flags.EmptyOverdrive, value);
        }
        public bool FlagMisc4ShowSpellcastAura
        {
            get => BitFlag_Util.IsFlagSet(Misc4Flgs, Misc4Flags.ShowSpellcastAura);
            set => Misc4Flgs = BitFlag_Util.SetFlag(Misc4Flgs, Misc4Flags.ShowSpellcastAura, value);
        }
        public bool FlagMisc4RunOffScreen
        {
            get => BitFlag_Util.IsFlagSet(Misc4Flgs, Misc4Flags.RunOffScreen);
            set => Misc4Flgs = BitFlag_Util.SetFlag(Misc4Flgs, Misc4Flags.RunOffScreen, value);
        }
        public bool FlagMisc4CopycatEnabled
        {
            get => BitFlag_Util.IsFlagSet(Misc4Flgs, Misc4Flags.CopycatEnabled);
            set => Misc4Flgs = BitFlag_Util.SetFlag(Misc4Flgs, Misc4Flags.CopycatEnabled, value);
        }
        public bool FlagMisc4Unk20
        {
            get => BitFlag_Util.IsFlagSet(Misc4Flgs, Misc4Flags.Unk20);
            set => Misc4Flgs = BitFlag_Util.SetFlag(Misc4Flgs, Misc4Flags.Unk20, value);
        }
        public bool FlagMisc4AeonOverdrive
        {
            get => BitFlag_Util.IsFlagSet(Misc4Flgs, Misc4Flags.AeonOverdrive);
            set => Misc4Flgs = BitFlag_Util.SetFlag(Misc4Flgs, Misc4Flags.AeonOverdrive, value);
        }
        public bool FlagMisc4Bribe
        {
            get => BitFlag_Util.IsFlagSet(Misc4Flgs, Misc4Flags.Bribe);
            set => Misc4Flgs = BitFlag_Util.SetFlag(Misc4Flgs, Misc4Flags.Bribe, value);
        }

        [Flags]
        public enum DamageFlags : byte
        {
            Physical = 0x01,
            Magical = 0x02,
            CanCrit = 0x04,
            GearCritBonus = 0x08,
            Heals = 0x10,
            CleansesStatuses = 0x20,
            SupressBreakDamageLimit = 0x40,
            BreaksDamageLimit = 0x80,
        }
        public bool FlagDamagePhysical
        {
            get => BitFlag_Util.IsFlagSet(DamageFlgs, DamageFlags.Physical);
            set => DamageFlgs = BitFlag_Util.SetFlag(DamageFlgs, DamageFlags.Physical, value);
        }
        public bool FlagDamageMagical
        {
            get => BitFlag_Util.IsFlagSet(DamageFlgs, DamageFlags.Magical);
            set => DamageFlgs = BitFlag_Util.SetFlag(DamageFlgs, DamageFlags.Magical, value);
        }
        public bool FlagDamageCanCrit
        {
            get => BitFlag_Util.IsFlagSet(DamageFlgs, DamageFlags.CanCrit);
            set => DamageFlgs = BitFlag_Util.SetFlag(DamageFlgs, DamageFlags.CanCrit, value);
        }
        public bool FlagDamageGearCritBonus
        {
            get => BitFlag_Util.IsFlagSet(DamageFlgs, DamageFlags.GearCritBonus);
            set => DamageFlgs = BitFlag_Util.SetFlag(DamageFlgs, DamageFlags.GearCritBonus, value);
        }
        public bool FlagDamageHeals
        {
            get => BitFlag_Util.IsFlagSet(DamageFlgs, DamageFlags.Heals);
            set => DamageFlgs = BitFlag_Util.SetFlag(DamageFlgs, DamageFlags.Heals, value);
        }
        public bool FlagDamageCleansesStatuses
        {
            get => BitFlag_Util.IsFlagSet(DamageFlgs, DamageFlags.CleansesStatuses);
            set => DamageFlgs = BitFlag_Util.SetFlag(DamageFlgs, DamageFlags.CleansesStatuses, value);
        }
        public bool FlagDamageSupressBreakDamageLimit
        {
            get => BitFlag_Util.IsFlagSet(DamageFlgs, DamageFlags.SupressBreakDamageLimit);
            set => DamageFlgs = BitFlag_Util.SetFlag(DamageFlgs, DamageFlags.SupressBreakDamageLimit, value);
        }
        public bool FlagDamageBreaksDamageLimit
        {
            get => BitFlag_Util.IsFlagSet(DamageFlgs, DamageFlags.BreaksDamageLimit);
            set => DamageFlgs = BitFlag_Util.SetFlag(DamageFlgs, DamageFlags.BreaksDamageLimit, value);
        }

        [Flags]
        public enum PreviewFlags : byte
        {
            Active = 0x01,
            HealMp = 0x02,
            HealStatuses = 0x04,
            IsMap = 0x08,
            IsRenameCard = 0x10,
            IsSphere = 0x20,
            HealHp = 0x40,
            IsRenameCard2 = 0x80,
        }
        public bool FlagPreviewActive
        {
            get => BitFlag_Util.IsFlagSet(PreviewFlgs, PreviewFlags.Active);
            set => PreviewFlgs = BitFlag_Util.SetFlag(PreviewFlgs, PreviewFlags.Active, value);
        }
        public bool FlagPreviewHealMp
        {
            get => BitFlag_Util.IsFlagSet(PreviewFlgs, PreviewFlags.HealMp);
            set => PreviewFlgs = BitFlag_Util.SetFlag(PreviewFlgs, PreviewFlags.HealMp, value);
        }
        public bool FlagPreviewHealStatuses
        {
            get => BitFlag_Util.IsFlagSet(PreviewFlgs, PreviewFlags.HealStatuses);
            set => PreviewFlgs = BitFlag_Util.SetFlag(PreviewFlgs, PreviewFlags.HealStatuses, value);
        }
        public bool FlagPreviewIsMap
        {
            get => BitFlag_Util.IsFlagSet(PreviewFlgs, PreviewFlags.IsMap);
            set => PreviewFlgs = BitFlag_Util.SetFlag(PreviewFlgs, PreviewFlags.IsMap, value);
        }
        public bool FlagPreviewIsRenameCard
        {
            get => BitFlag_Util.IsFlagSet(PreviewFlgs, PreviewFlags.IsRenameCard);
            set => PreviewFlgs = BitFlag_Util.SetFlag(PreviewFlgs, PreviewFlags.IsRenameCard, value);
        }
        public bool FlagPreviewIsSphere
        {
            get => BitFlag_Util.IsFlagSet(PreviewFlgs, PreviewFlags.IsSphere);
            set => PreviewFlgs = BitFlag_Util.SetFlag(PreviewFlgs, PreviewFlags.IsSphere, value);
        }
        public bool FlagPreviewHealHp
        {
            get => BitFlag_Util.IsFlagSet(PreviewFlgs, PreviewFlags.HealHp);
            set => PreviewFlgs = BitFlag_Util.SetFlag(PreviewFlgs, PreviewFlags.HealHp, value);
        }
        public bool FlagPreviewIsRenameCard2
        {
            get => BitFlag_Util.IsFlagSet(PreviewFlgs, PreviewFlags.IsRenameCard2);
            set => PreviewFlgs = BitFlag_Util.SetFlag(PreviewFlgs, PreviewFlags.IsRenameCard2, value);
        }

        [Flags]
        public enum StatusFlags : ushort
        {
            Scan = 0x01,
            DistillPower = 0x02,
            DistillMana = 0x04,
            DistillSpeed = 0x08,
            DistillUnused = 0x10,
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
        public bool FlagStatusScan
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.Scan);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.Scan, value);
        }
        public bool FlagStatusDistillPower
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.DistillPower);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.DistillPower, value);
        }
        public bool FlagStatusDistillMana
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.DistillMana);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.DistillMana, value);
        }
        public bool FlagStatusDistillSpeed
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.DistillSpeed);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.DistillSpeed, value);
        }
        public bool FlagStatusDistillUnused
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.DistillUnused);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.DistillUnused, value);
        }
        public bool FlagStatusDistillAbility
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.DistillAbility);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.DistillAbility, value);
        }
        public bool FlagStatusShield
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.Shield);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.Shield, value);
        }
        public bool FlagStatusBoost
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.Boost);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.Boost, value);
        }
        public bool FlagStatusEject
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.Eject);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.Eject, value);
        }
        public bool FlagStatusAutoLife
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.AutoLife);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.AutoLife, value);
        }
        public bool FlagStatusCurse
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.Curse);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.Curse, value);
        }
        public bool FlagStatusDefend
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.Defend);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.Defend, value);
        }
        public bool FlagStatusGuard
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.Guard);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.Guard, value);
        }
        public bool FlagStatusSentinel
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.Sentinel);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.Sentinel, value);
        }
        public bool FlagStatusDoom
        {
            get => BitFlag_Util.IsFlagSet(StatusFlgs, StatusFlags.Doom);
            set => StatusFlgs = BitFlag_Util.SetFlag(StatusFlgs, StatusFlags.Doom, value);
        }

        [Flags]
        public enum StatBuffFlags : ushort
        {
            Cheer = 0x01,
            Aim = 0x02,
            Focus = 0x04,
            Reflex = 0x08,
            Luck = 0x10,
            Jinx = 0x20,
        }
        public bool FlagStatBuffCheer
        {
            get => BitFlag_Util.IsFlagSet(StatBuffFlgs, StatBuffFlags.Cheer);
            set => StatBuffFlgs = BitFlag_Util.SetFlag(StatBuffFlgs, StatBuffFlags.Cheer, value);
        }
        public bool FlagStatBuffAim
        {
            get => BitFlag_Util.IsFlagSet(StatBuffFlgs, StatBuffFlags.Aim);
            set => StatBuffFlgs = BitFlag_Util.SetFlag(StatBuffFlgs, StatBuffFlags.Aim, value);
        }
        public bool FlagStatBuffFocus
        {
            get => BitFlag_Util.IsFlagSet(StatBuffFlgs, StatBuffFlags.Focus);
            set => StatBuffFlgs = BitFlag_Util.SetFlag(StatBuffFlgs, StatBuffFlags.Focus, value);
        }
        public bool FlagStatBuffReflex
        {
            get => BitFlag_Util.IsFlagSet(StatBuffFlgs, StatBuffFlags.Reflex);
            set => StatBuffFlgs = BitFlag_Util.SetFlag(StatBuffFlgs, StatBuffFlags.Reflex, value);
        }
        public bool FlagStatBuffLuck
        {
            get => BitFlag_Util.IsFlagSet(StatBuffFlgs, StatBuffFlags.Luck);
            set => StatBuffFlgs = BitFlag_Util.SetFlag(StatBuffFlgs, StatBuffFlags.Luck, value);
        }
        public bool FlagStatBuffJinx
        {
            get => BitFlag_Util.IsFlagSet(StatBuffFlgs, StatBuffFlags.Jinx);
            set => StatBuffFlgs = BitFlag_Util.SetFlag(StatBuffFlgs, StatBuffFlags.Jinx, value);
        }

        [Flags]
        public enum SpecialBuffFlags : ushort
        {
            DoubleHp = 0x01,
            DoubleMp = 0x02,
            MpCost0 = 0x04,
            Quartet = 0x08,
            AlwaysCrit = 0x10,
            Overdrive150 = 0x20,
            Overdrive200 = 0x40,
        }
        public bool FlagSpecialBuffDoubleHp
        {
            get => BitFlag_Util.IsFlagSet(SpecialBuffFlgs, SpecialBuffFlags.DoubleHp);
            set => SpecialBuffFlgs = BitFlag_Util.SetFlag(SpecialBuffFlgs, SpecialBuffFlags.DoubleHp, value);
        }
        public bool FlagSpecialBuffDoubleMp
        {
            get => BitFlag_Util.IsFlagSet(SpecialBuffFlgs, SpecialBuffFlags.DoubleMp);
            set => SpecialBuffFlgs = BitFlag_Util.SetFlag(SpecialBuffFlgs, SpecialBuffFlags.DoubleMp, value);
        }
        public bool FlagSpecialBuffMpCost0
        {
            get => BitFlag_Util.IsFlagSet(SpecialBuffFlgs, SpecialBuffFlags.MpCost0);
            set => SpecialBuffFlgs = BitFlag_Util.SetFlag(SpecialBuffFlgs, SpecialBuffFlags.MpCost0, value);
        }
        public bool FlagSpecialBuffQuartet
        {
            get => BitFlag_Util.IsFlagSet(SpecialBuffFlgs, SpecialBuffFlags.Quartet);
            set => SpecialBuffFlgs = BitFlag_Util.SetFlag(SpecialBuffFlgs, SpecialBuffFlags.Quartet, value);
        }
        public bool FlagSpecialBuffAlwaysCrit
        {
            get => BitFlag_Util.IsFlagSet(SpecialBuffFlgs, SpecialBuffFlags.AlwaysCrit);
            set => SpecialBuffFlgs = BitFlag_Util.SetFlag(SpecialBuffFlgs, SpecialBuffFlags.AlwaysCrit, value);
        }
        public bool FlagSpecialBuffOverdrive150
        {
            get => BitFlag_Util.IsFlagSet(SpecialBuffFlgs, SpecialBuffFlags.Overdrive150);
            set => SpecialBuffFlgs = BitFlag_Util.SetFlag(SpecialBuffFlgs, SpecialBuffFlags.Overdrive150, value);
        }
        public bool FlagSpecialBuffOverdrive200
        {
            get => BitFlag_Util.IsFlagSet(SpecialBuffFlgs, SpecialBuffFlags.Overdrive200);
            set => SpecialBuffFlgs = BitFlag_Util.SetFlag(SpecialBuffFlgs, SpecialBuffFlags.Overdrive200, value);
        }

        [Flags]
        public enum DamageTypeFlags : byte
        {
            Hp = 0x01,
            Mp = 0x02,
            Ctb = 0x04,
        }
        public bool FlagDamageTypeHp
        {
            get => BitFlag_Util.IsFlagSet(DamageTypeFlgs, DamageTypeFlags.Hp);
            set => DamageTypeFlgs = BitFlag_Util.SetFlag(DamageTypeFlgs, DamageTypeFlags.Hp, value);
        }
        public bool FlagDamageTypeMp
        {
            get => BitFlag_Util.IsFlagSet(DamageTypeFlgs, DamageTypeFlags.Mp);
            set => DamageTypeFlgs = BitFlag_Util.SetFlag(DamageTypeFlgs, DamageTypeFlags.Mp, value);
        }
        public bool FlagDamageTypeCtb
        {
            get => BitFlag_Util.IsFlagSet(DamageTypeFlgs, DamageTypeFlags.Ctb);
            set => DamageTypeFlgs = BitFlag_Util.SetFlag(DamageTypeFlgs, DamageTypeFlags.Ctb, value);
        }

        [Flags]
        public enum ElementFlags : byte
        {
            Fire = 0x01,
            Blizzard = 0x02,
            Thunder = 0x04,
            Water = 0x08,
            Holy = 0x10,
        }
        public bool FlagElementFire
        {
            get => BitFlag_Util.IsFlagSet(ElementFlgs, ElementFlags.Fire);
            set => ElementFlgs = BitFlag_Util.SetFlag(ElementFlgs, ElementFlags.Fire, value);
        }
        public bool FlagElementBlizzard
        {
            get => BitFlag_Util.IsFlagSet(ElementFlgs, ElementFlags.Blizzard);
            set => ElementFlgs = BitFlag_Util.SetFlag(ElementFlgs, ElementFlags.Blizzard, value);
        }
        public bool FlagElementThunder
        {
            get => BitFlag_Util.IsFlagSet(ElementFlgs, ElementFlags.Thunder);
            set => ElementFlgs = BitFlag_Util.SetFlag(ElementFlgs, ElementFlags.Thunder, value);
        }
        public bool FlagElementWater
        {
            get => BitFlag_Util.IsFlagSet(ElementFlgs, ElementFlags.Water);
            set => ElementFlgs = BitFlag_Util.SetFlag(ElementFlgs, ElementFlags.Water, value);
        }
        public bool FlagElementHoly
        {
            get => BitFlag_Util.IsFlagSet(ElementFlgs, ElementFlags.Holy);
            set => ElementFlgs = BitFlag_Util.SetFlag(ElementFlgs, ElementFlags.Holy, value);
        }

        public Ability_Command()
        {
            StatusChance = new();
            StatusDuration = new();
        }

        public class ExtraCommandInfo
        {
            [Data] public byte OrderingIndexInMenu { get; set; }
            [Data] public sbyte SphereTypeForSphereGrid { get; set; }
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

                listFile = stream.ToArray();
            }

            short entrySize = (short) (hasExtraInfo ? 0x60 : 0x5C);

            return EntryListFile.Pack(entrySize, (short)commandList.Count, listFile, textFile);
        }
    }
}
