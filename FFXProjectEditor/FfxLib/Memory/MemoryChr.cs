using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.Utils;
using System;
using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Memory
{
    public class MemoryChr
    {
        [Data(0x000)] public       long              Actor_pointer { get; set; }
        [Data(0x008)] public       uint              Model_id { get; set; }
        [Data(0x00C)] public       ushort            Icon_id { get; set; }
        [Data(0x00E)] public       ushort            Id { get; set; }
        [Data(0x016)] public       byte              Stat_visible { get; set; }
        [Data(0x017)] public       byte              Stat_hide { get; set; }
        [Data(0x018)] public       sbyte             Stat_visible_eff { get; set; }
        [Data(0x019)] public       byte              Stat_visible_cam { get; set; }
        [Data(0x01B)] public       byte              Stat_visible_out { get; set; }
        [Data(0x01C)] public       sbyte             Stat_visible_out_on { get; set; }
        [Data(0x021)] public       bool              Stat_motion_dispose_flag { get; set; }
        [Data(0x022)] public       bool              Stat_model_dispose_flag { get; set; }
        [Data(0x023)] public       bool              Stat_fast_model_flag { get; set; }
        [Data(0x024)] public       byte              Stat_model { get; set; }
        [Data(0x026)] public       sbyte             Stat_shadow { get; set; }
        [Data(0x02D)] public       bool              Stat_bodyhit_flag { get; set; }
        [Data(0x03B)] public       byte              Stat_eternal_relife { get; set; }
        [Data(0x3F4)] public       byte              Death_level { get; set; }
        [Data(0x3F5)] public       byte              Death_pattern { get; set; }
        [Data(0x3F8)] public       bool              Stat_center_chr_flag { get; set; }
        [Data(0x3F9)] public       byte              Stat_death_return { get; set; }
        [Data(0x400)] public       byte              Motion_speed_normal { get; set; }
        [Data(0x405)] public       byte              Motion_speed_normal_init { get; set; }
        [Data(0x408)] public       byte              Stat_attack_motion_type { get; set; }
        [Data(0x409)] public       byte              Stat_return_motion_type { get; set; }
        [Data(0x40A)] public       bool              Stat_attack_return_flag { get; set; }
        [Data(0x40C)] public       byte              Stat_attack_normal_frame { get; set; }
        [Data(0x40D)] public       byte              Stat_attack_near_frame { get; set; }
        [Data(0x40E)] public       byte              Stat_attack_motion_frame { get; set; }
        [Data(0x412)] public       bool              Stat_move_flag { get; set; }
        [Data(0x416)] public       byte              Stat_move_target { get; set; }
        [Data(0x41B)] public       bool              Stat_direction_fix_flag { get; set; }
        [Data(0x41C)] public       bool              Stat_direction_change_flag { get; set; }
        [Data(0x41D)] public       byte              Stat_direction_change_effect { get; set; }
        [Data(0x41E)] public       bool              Stat_disable_move_flag { get; set; }
        [Data(0x41F)] public       bool              Stat_disable_jump_flag { get; set; }
        [Data(0x420)] public       byte              Stat_motionlv { get; set; }
        [Data(0x422)] public       byte              Stat_damage_chr { get; set; }
        [Data(0x423)] public       bool              Stat_appear_invisible_flag { get; set; }
        [Data(0x424)] public       byte              Stat_appear_count { get; set; }
        [Data(0x425)] public       bool              Stat_avoid_flag { get; set; }
        [Data(0x426)] public       bool              Stat_adjust_pos_flag { get; set; }
        [Data(0x433)] public       bool              Stat_hit_terminate_flag { get; set; }
        [Data(0x437)] public       bool              Stat_neck_target_flag { get; set; }
        [Data(0x438)] public       byte              Seck_target_id { get; set; }
        [Data(0x43B)] public       byte              Stat_win_pose { get; set; }
        [Data(0x43C)] public       sbyte             Stat_win_se { get; set; }
        [Data(0x43D)] public       bool              Stat_appear_motion_flag { get; set; }
        [Data(0x43E)] public       byte              Stat_live_motion { get; set; }
        [Data(0x442)] public       byte              Stat_num_print_element { get; set; }
        [Data(0x446)] public       byte              Stat_command_type { get; set; }
        [Data(0x447)] public       byte              Stat_inv_motion { get; set; }
        [Data(0x448)] public       bool              Stat_wait_motion_flag { get; set; }
        [Data(0x44A)] public       sbyte             Stat_near_motion { get; set; }
        [Data(0x44B)] public       sbyte             Stat_near_motion_set { get; set; }
        [Data(0x44E)] public       byte              Stat_dmg_dir { get; set; }
        [Data(0x44F)] public       byte              Stat_weak_motion { get; set; }
        [Data(0x451)] public       byte              Stat_magiclv { get; set; }
        [Data(0x4B4)] public       byte              Stat_own_attack_near { get; set; }
        [Data(0x4B8)] public       byte              Stat_idle2_prob { get; set; }
        [Data(0x4B9)] public       byte              Stat_attack_inc_speed { get; set; }
        [Data(0x4BA)] public       byte              Stat_attack_dec_speed { get; set; }
        [Data(0x4BB)] public       byte              Stat_motion_num { get; set; }
        [Data(0x4FC)] public       ushort            Area { get; set; }
        [Data(0x4FE)] public       byte              Pos { get; set; }
        [Data(0x4FF)] public       byte              Stat_far { get; set; }
        [Data(0x504)] public       byte              Stat_group { get; set; }
        [Data(0x505)] public       bool              Flying { get; set; }
        [Data(0x508)] public       byte              Stat_adjust_pos { get; set; }
        [Data(0x509)] public       byte              Stat_move_area { get; set; }
        [Data(0x50B)] public       byte              Stat_move_pos { get; set; }
        [Data(0x50D)] public       byte              Stat_height_on { get; set; }
        [Data(0x50E)] public       bool              Stat_sleep_recover_flag { get; set; }
        [Data(0x540,Count=40)]	  public byte[] 	 Name { get; set; }
        [Data(0x590)] public       byte              Gender { get; set; }
        [Data(0x592)] public       byte              Wpn_inv_idx { get; set; }
        [Data(0x593)] public       byte              Arm_inv_idx { get; set; }
        [Data(0x594)] public       int               Max_hp { get; set; }
        [Data(0x598)] public       int               Max_mp { get; set; }
        [Data(0x59C)] public       int               Base_max_hp { get; set; }
        [Data(0x5A0)] public       int               Base_max_mp { get; set; }
        [Data(0x5A4)] public       int               Overkill_threshold { get; set; }
        [Data(0x5A8)] public       byte              Strength { get; set; }
        [Data(0x5A9)] public       byte              Defense { get; set; }
        [Data(0x5AA)] public       byte              Magic { get; set; }
        [Data(0x5AB)] public       byte              Magic_defense { get; set; }
        [Data(0x5AC)] public       byte              Agility { get; set; }
        [Data(0x5AD)] public       byte              Luck { get; set; }
        [Data(0x5AE)] public       byte              Evasion { get; set; }
        [Data(0x5AF)] public       byte              Accuracy { get; set; }
        [Data(0x5B0)] public       byte              Strength_up { get; set; }
        [Data(0x5B1)] public       byte              Defense_up { get; set; }
        [Data(0x5B2)] public       byte              Magic_up { get; set; }
        [Data(0x5B3)] public       byte              Magic_defense_up { get; set; }
        [Data(0x5B4)] public       byte              Agility_up { get; set; }
        [Data(0x5B5)] public       byte              Luck_up { get; set; }
        [Data(0x5B6)] public       byte              Evasion_up { get; set; }
        [Data(0x5B7)] public       byte              Accuracy_up { get; set; }
        [Data(0x5B8)] public       ushort            Extra_resist { get; set; } //TODO: Figure out a better name for this
        [Data(0x5BA)] public       byte              Poison_dmg { get; set; }
        [Data(0x5BB)] public       byte              Ovr_mode_selected { get; set; }
        [Data(0x5BC)] public       byte              Ovr_charge { get; set; }
        [Data(0x5BD)] public       byte              Ovr_charge_max { get; set; }
        [Data(0x5C1)] public       byte              Wpn_dmg_formula { get; set; }
        [Data(0x5C3)] public       byte              Stat_icon_number { get; set; }
        [Data(0x5C4)] public       byte              Provoked_by_id { get; set; }
        [Data(0x5C5)] public       byte              Threatened_by_id { get; set; }
        [Data(0x5C7)] public       byte              Wpn_power { get; set; }
        [Data(0x5C8)] public       byte              Doom_counter { get; set; }
        [Data(0x5C9)] public       byte              Doom_counter_init { get; set; }
        [Data(0x5CB)] public       bool              Stat_prov_command_flag { get; set; }
        [Data(0x5D0)] public       int               Hp { get; set; }
        [Data(0x5D4)] public       int               Mp { get; set; }
        [Data(0x5D8)] public       byte              Wpn_crit_bonus { get; set; }
        [Data(0x5D9)] public       byte              Elem_wpn { get; set; }
        [Data(0x5DA)] public       byte              Elem_absorb { get; set; }
        [Data(0x5DB)] public       byte              Elem_ignore { get; set; }
        [Data(0x5DC)] public       byte              Elem_resist { get; set; }
        [Data(0x5DD)] public       byte              Elem_weak { get; set; }
        [Data(0x5DE)] public       StatusByteList         Status_inflict { get; set; }
        [Data(0x5F7)] public       StatusDurationByteList Status_duration_inflict { get; set; }
        [Data(0x604)] public       ushort            Status_inflict_extra { get; set; }
        [Data(0x606)] public       StatusSufferFlags Status_suffer { get; set; }
        [Data(0x608)] public       StatusDurationByteList Status_suffer_turns_left { get; set; }
        [Data(0x616)] public       StatusSufferExtraFlags Status_suffer_extra { get; set; }
        [Data(0x62A)] public       ushort            Status_full_auto_1 { get; set; }
        [Data(0x62C)] public       ushort            Status_full_auto_2 { get; set; }
        [Data(0x62E)] public       ushort            Status_full_auto_3 { get; set; }
        [Data(0x630)] public       ushort            Status_innate_auto_1 { get; set; }
        [Data(0x632)] public       ushort            Status_innate_auto_2 { get; set; }
        [Data(0x634)] public       ushort            Status_innate_auto_3 { get; set; }
        [Data(0x636)] public       ushort            Status_sos_auto_1 { get; set; }
        [Data(0x638)] public       ushort            Status_sos_auto_2 { get; set; }
        [Data(0x63A)] public       ushort            Status_sos_auto_3 { get; set; }
        [Data(0x63D)] public       byte              Weak_level_full { get; set; }
        [Data(0x63E)] public       byte              Weak_level_hp { get; set; }
        [Data(0x641)] public       StatusByteList   Status_resist { get; set; }
        [Data(0x65A)] public       ushort            Status_resist_extra { get; set; }
        [Data(0x65C)] public       byte              Ctb { get; set; }
        [Data(0x65D)] public       byte              Max_ctb { get; set; }
        [Data(0x65E)] public       byte              Cheer_stacks { get; set; }
        [Data(0x65F)] public       byte              Aim_stacks { get; set; }
        [Data(0x660)] public       byte              Focus_stacks { get; set; }
        [Data(0x661)] public       byte              Reflex_stacks { get; set; }
        [Data(0x662)] public       byte              Luck_stacks { get; set; }
        [Data(0x663)] public       byte              Jinx_stacks { get; set; }
        [Data(0x664)] public       AbilityStatusList Abilities { get; set; }
        [Data(0x6BC)] public       ushort            Auto_abilities_1 { get; set; }
        [Data(0x6BE)] public       ushort            Auto_abilities_2 { get; set; }
        [Data(0x6C0)] public       ushort            Auto_abilities_3 { get; set; }
        [Data(0x6CE)] public       byte              Stat_use_mp0 { get; set; }
        [Data(0x6D1)] public       byte              Summoned_by_id { get; set; }
        [Data(0x6D2)] public       byte              Regen_strength { get; set; }
        [Data(0x6DB)] public       byte              Stat_attack_num { get; set; }
        [Data(0x6DF)] public       byte              Stat_command_exe_count { get; set; }
        [Data(0x6E0)] public       byte              Stat_consent { get; set; }
        [Data(0x6E1)] public       byte              Stat_energy { get; set; }
        [Data(0x6E4)] public       int               Current_hp { get; set; }
        [Data(0x6E8)] public       int               Current_mp { get; set; }
        [Data(0x6EC)] public       int               Current_ctb { get; set; }
        [Data(0x700)] public       sbyte             Stat_death_status { get; set; }
        [Data(0x704)] public       uint              Bribe_gil_spent { get; set; }
        [Data(0x718)] public       bool              Stat_limit_bar_flag { get; set; }
        [Data(0x719)] public       byte              Stat_limit_bar_flag_cam { get; set; }
        [Data(0xD34)] public       int               Damage_hp { get; set; }
        [Data(0xD38)] public       int               Damage_mp { get; set; }
        [Data(0xD3C)] public       int               Damage_ctb { get; set; }
        [Data(0xDC8)] public       byte              In_battle { get; set; }
        [Data(0xDCA)] public       byte              Stat_target_list { get; set; }
        [Data(0xDCC)] public       byte              Stat_death { get; set; }
        [Data(0xDCD)] public       bool              Stat_escape_flag { get; set; }
        [Data(0xDCE)] public       byte              Stat_stone { get; set; }
        [Data(0xDD2)] public       bool              Stat_exist_flag { get; set; }
        [Data(0xDD6)] public       byte              Stat_action { get; set; }
        [Data(0xDD7)] public       bool              In_ctb_list { get; set; }
        [Data(0xDD8)] public       bool              In_hp_list { get; set; }
        [Data(0xDD9)] public       byte              Stat_cursor { get; set; }
        [Data(0xDDA)] public       bool              Stat_effect_target_flag { get; set; }
        [Data(0xDDB)] public       bool              Stat_regen_damage_flag { get; set; }
        [Data(0xDDD)] public       byte              Stat_event_chr { get; set; }
        [Data(0xDDE)] public       bool              Stat_blow_exist_flag { get; set; }
        [Data(0xDEB)] public       byte              Steal_count { get; set; }
        [Data(0xDEC)] public       byte              Stat_will_die { get; set; }
        [Data(0xDF9)] public       byte              Stat_cursor_element { get; set; }
        [Data(0xE0C)] public       byte              Stat_effvar { get; set; }
        [Data(0xE0E)] public       byte              Stat_effect_hit_num { get; set; }
        [Data(0xE10)] public       byte              Stat_magic_effect_ground { get; set; }
        [Data(0xE11)] public       byte              Stat_magic_effect_water { get; set; }
        [Data(0xE1A)] public       short             Stat_sound_hit_num { get; set; }
        [Data(0xF74)] public       byte              Stat_info_mes_id { get; set; }
        [Data(0xF75)] public       byte              Stat_live_mes_id { get; set; }
        [Data(0xF78)] public       int               Ptr_script_chunks { get; set; }
        [Data(0xF7C)] public       int               Ptr_script_data { get; set; }
        [Data(0xF80)] public       int               Ptr_base_stats { get; set; }
        [Data(0xF84)] public       int               Ptr_base_en_stats { get; set; }
        [Data(0xF88)] public       int          	 Loot { get; set; }

        [Flags]
        public enum StatusSufferFlags : ushort
        {
            Ko = 0x01,
            Zombie = 0x02,
            Petrification = 0x04,
            Poison = 0x08,
            BreakPower = 0x10,
            BreakMagic = 0x20,
            BreakArmor = 0x40,
            BreakMental = 0x80,
            Confusion = 0x100,
            Berserk = 0x200,
            Provoke = 0x400,
            Threaten = 0x800,
        }
        public bool FlagStatusSufferKo
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.Ko);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.Ko, value);
        }
        public bool FlagStatusSufferZombie
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.Zombie);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.Zombie, value);
        }
        public bool FlagStatusSufferPetrification
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.Petrification);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.Petrification, value);
        }
        public bool FlagStatusSufferPoison
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.Poison);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.Poison, value);
        }
        public bool FlagStatusSufferBreakPower
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.BreakPower);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.BreakPower, value);
        }
        public bool FlagStatusSufferBreakMagic
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.BreakMagic);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.BreakMagic, value);
        }
        public bool FlagStatusSufferBreakArmor
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.BreakArmor);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.BreakArmor, value);
        }
        public bool FlagStatusSufferBreakMental
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.BreakMental);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.BreakMental, value);
        }
        public bool FlagStatusSufferConfusion
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.Confusion);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.Confusion, value);
        }
        public bool FlagStatusSufferBerserk
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.Berserk);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.Berserk, value);
        }
        public bool FlagStatusSufferProvoke
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.Provoke);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.Provoke, value);
        }
        public bool FlagStatusSufferThreaten
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer, StatusSufferFlags.Threaten);
            set => Status_suffer = BitFlag_Util.SetFlag(Status_suffer, StatusSufferFlags.Threaten, value);
        }
        [Flags]
        public enum StatusSufferExtraFlags : ushort
        {
            Scan = 0x01,
            DistillPower = 0x02,
            DistillMana = 0x04,
            DistillSpeed = 0x08,
            DistillUnused = 0x10,
            DistillAbility = 0x20,
            Shield = 0x40,
            Boost = 0x80,
            Eject = 0x100,
            AutoLife = 0x200,
            Curse = 0x400,
            Defend = 0x800,
            Guard = 0x1000,
            Sentinel = 0x2000,
            Doom = 0x4000,
        }
        public bool FlagStatusSufferExtraScan
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.Scan);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.Scan, value);
        }
        public bool FlagStatusSufferExtraDistillPower
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.DistillPower);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.DistillPower, value);
        }
        public bool FlagStatusSufferExtraDistillMana
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.DistillMana);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.DistillMana, value);
        }
        public bool FlagStatusSufferExtraDistillSpeed
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.DistillSpeed);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.DistillSpeed, value);
        }
        public bool FlagStatusSufferExtraDistillUnused
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.DistillUnused);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.DistillUnused, value);
        }
        public bool FlagStatusSufferExtraDistillAbility
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.DistillAbility);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.DistillAbility, value);
        }
        public bool FlagStatusSufferExtraShield
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.Shield);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.Shield, value);
        }
        public bool FlagStatusSufferExtraBoost
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.Boost);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.Boost, value);
        }
        public bool FlagStatusSufferExtraEject
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.Eject);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.Eject, value);
        }
        public bool FlagStatusSufferExtraAutoLife
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.AutoLife);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.AutoLife, value);
        }
        public bool FlagStatusSufferExtraCurse
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.Curse);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.Curse, value);
        }
        public bool FlagStatusSufferExtraDefend
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.Defend);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.Defend, value);
        }
        public bool FlagStatusSufferExtraGuard
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.Guard);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.Guard, value);
        }
        public bool FlagStatusSufferExtraSentinel
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.Sentinel);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.Sentinel, value);
        }
        public bool FlagStatusSufferExtraDoom
        {
            get => BitFlag_Util.IsFlagSet(Status_suffer_extra, StatusSufferExtraFlags.Doom);
            set => Status_suffer_extra = BitFlag_Util.SetFlag(Status_suffer_extra, StatusSufferExtraFlags.Doom, value);
        }
    }
}
