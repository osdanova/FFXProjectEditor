﻿using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Utils;

namespace FFXProjectEditor.Modules.BattleTracker
{
    public partial class BattleTrackerChr_Wrapper : ObservableObject
    {
        [ObservableProperty] public long actor_pointer;
        [ObservableProperty] public uint model_id;
        [ObservableProperty] public ushort icon_id;
        [ObservableProperty] public ushort id;
        [ObservableProperty] public byte stat_visible;
        [ObservableProperty] public byte stat_hide;
        [ObservableProperty] public sbyte stat_visible_eff;
        [ObservableProperty] public byte stat_visible_cam;
        [ObservableProperty] public byte stat_visible_out;
        [ObservableProperty] public sbyte stat_visible_out_on;
        [ObservableProperty] public bool stat_motion_dispose_flag;
        [ObservableProperty] public bool stat_model_dispose_flag;
        [ObservableProperty] public bool stat_fast_model_flag;
        [ObservableProperty] public byte stat_model;
        [ObservableProperty] public sbyte stat_shadow;
        [ObservableProperty] public bool stat_bodyhit_flag;
        [ObservableProperty] public byte stat_eternal_relife;
        [ObservableProperty] public byte death_level;
        [ObservableProperty] public byte death_pattern;
        [ObservableProperty] public bool stat_center_chr_flag;
        [ObservableProperty] public byte stat_death_return;
        [ObservableProperty] public byte motion_speed_normal;
        [ObservableProperty] public byte motion_speed_normal_init;
        [ObservableProperty] public byte stat_attack_motion_type;
        [ObservableProperty] public byte stat_return_motion_type;
        [ObservableProperty] public bool stat_attack_return_flag;
        [ObservableProperty] public byte stat_attack_normal_frame;
        [ObservableProperty] public byte stat_attack_near_frame;
        [ObservableProperty] public byte stat_attack_motion_frame;
        [ObservableProperty] public bool stat_move_flag;
        [ObservableProperty] public byte stat_move_target;
        [ObservableProperty] public bool stat_direction_fix_flag;
        [ObservableProperty] public bool stat_direction_change_flag;
        [ObservableProperty] public byte stat_direction_change_effect;
        [ObservableProperty] public bool stat_disable_move_flag;
        [ObservableProperty] public bool stat_disable_jump_flag;
        [ObservableProperty] public byte stat_motionlv;
        [ObservableProperty] public byte stat_damage_chr;
        [ObservableProperty] public bool stat_appear_invisible_flag;
        [ObservableProperty] public byte stat_appear_count;
        [ObservableProperty] public bool stat_avoid_flag;
        [ObservableProperty] public bool stat_adjust_pos_flag;
        [ObservableProperty] public bool stat_hit_terminate_flag;
        [ObservableProperty] public bool stat_neck_target_flag;
        [ObservableProperty] public byte neck_target_id;
        [ObservableProperty] public byte stat_win_pose;
        [ObservableProperty] public sbyte stat_win_se;
        [ObservableProperty] public bool stat_appear_motion_flag;
        [ObservableProperty] public byte stat_live_motion;
        [ObservableProperty] public byte stat_num_print_element;
        [ObservableProperty] public byte stat_command_type;
        [ObservableProperty] public byte stat_inv_motion;
        [ObservableProperty] public bool stat_wait_motion_flag;
        [ObservableProperty] public sbyte stat_near_motion;
        [ObservableProperty] public sbyte stat_near_motion_set;
        [ObservableProperty] public byte stat_dmg_dir;
        [ObservableProperty] public byte stat_weak_motion;
        [ObservableProperty] public byte stat_magiclv;
        [ObservableProperty] public byte stat_own_attack_near;
        [ObservableProperty] public byte stat_idle2_prob;
        [ObservableProperty] public byte stat_attack_inc_speed;
        [ObservableProperty] public byte stat_attack_dec_speed;
        [ObservableProperty] public byte stat_motion_num;
        [ObservableProperty] public ushort area;
        [ObservableProperty] public byte pos;
        [ObservableProperty] public byte stat_far;
        [ObservableProperty] public byte stat_group;
        [ObservableProperty] public bool flying;
        [ObservableProperty] public byte stat_adjust_pos;
        [ObservableProperty] public byte stat_move_area;
        [ObservableProperty] public byte stat_move_pos;
        [ObservableProperty] public byte stat_height_on;
        [ObservableProperty] public bool stat_sleep_recover_flag;
        [ObservableProperty] public byte[] name;
        [ObservableProperty] public byte gender;
        [ObservableProperty] public byte wpn_inv_idx;
        [ObservableProperty] public byte arm_inv_idx;
        [ObservableProperty] public int max_hp;
        [ObservableProperty] public int max_mp;
        [ObservableProperty] public int base_max_hp;
        [ObservableProperty] public int base_max_mp;
        [ObservableProperty] public int overkill_threshold;
        [ObservableProperty] public byte strength;
        [ObservableProperty] public byte defense;
        [ObservableProperty] public byte magic;
        [ObservableProperty] public byte magic_defense;
        [ObservableProperty] public byte agility;
        [ObservableProperty] public byte luck;
        [ObservableProperty] public byte evasion;
        [ObservableProperty] public byte accuracy;
        [ObservableProperty] public byte strength_up;
        [ObservableProperty] public byte defense_up;
        [ObservableProperty] public byte magic_up;
        [ObservableProperty] public byte magic_defense_up;
        [ObservableProperty] public byte agility_up;
        [ObservableProperty] public byte luck_up;
        [ObservableProperty] public byte evasion_up;
        [ObservableProperty] public byte accuracy_up;
        [ObservableProperty] public ushort extra_resist; //TODO: Figure out a better name for this
        [ObservableProperty] public byte poison_dmg;
        [ObservableProperty] public byte ovr_mode_selected;
        [ObservableProperty] public byte ovr_charge;
        [ObservableProperty] public byte ovr_charge_max;
        [ObservableProperty] public byte wpn_dmg_formula;
        [ObservableProperty] public byte stat_icon_number;
        [ObservableProperty] public byte provoked_by_id;
        [ObservableProperty] public byte threatened_by_id;
        [ObservableProperty] public byte wpn_power;
        [ObservableProperty] public byte doom_counter;
        [ObservableProperty] public byte doom_counter_init;
        [ObservableProperty] public bool stat_prov_command_flag;
        [ObservableProperty] public int hp;
        [ObservableProperty] public int mp;
        [ObservableProperty] public byte wpn_crit_bonus;
        [ObservableProperty] public byte elem_wpn;
        [ObservableProperty] public byte elem_absorb;
        [ObservableProperty] public byte elem_ignore;
        [ObservableProperty] public byte elem_resist;
        [ObservableProperty] public byte elem_weak;
        [ObservableProperty] public StatusByteList status_inflict;
        [ObservableProperty] public StatusDurationByteList status_duration_inflict;
        [ObservableProperty] public ushort status_inflict_extra;
        //[ObservableProperty] public ushort status_suffer;
        [ObservableProperty] public StatusDurationByteList status_suffer_turns_left;
        //[ObservableProperty] public ushort status_suffer_extra;
        [ObservableProperty] public ushort status_full_auto_1;
        [ObservableProperty] public ushort status_full_auto_2;
        [ObservableProperty] public ushort status_full_auto_3;
        [ObservableProperty] public ushort status_innate_auto_1;
        [ObservableProperty] public ushort status_innate_auto_2;
        [ObservableProperty] public ushort status_innate_auto_3;
        [ObservableProperty] public ushort status_sos_auto_1;
        [ObservableProperty] public ushort status_sos_auto_2;
        [ObservableProperty] public ushort status_sos_auto_3;
        [ObservableProperty] public byte weak_level_full;
        [ObservableProperty] public byte weak_level_hp;
        [ObservableProperty] public StatusByteList status_resist;
        [ObservableProperty] public ushort status_resist_extra;
        [ObservableProperty] public byte ctb;
        [ObservableProperty] public byte max_ctb;
        [ObservableProperty] public byte cheer_stacks;
        [ObservableProperty] public byte aim_stacks;
        [ObservableProperty] public byte focus_stacks;
        [ObservableProperty] public byte reflex_stacks;
        [ObservableProperty] public byte luck_stacks;
        [ObservableProperty] public byte jinx_stacks;
        [ObservableProperty] public AbilityStatusList abilities;
        [ObservableProperty] public ushort auto_abilities_1;
        [ObservableProperty] public ushort auto_abilities_2;
        [ObservableProperty] public ushort auto_abilities_3;
        [ObservableProperty] public byte stat_use_mp0;
        [ObservableProperty] public byte summoned_by_id;
        [ObservableProperty] public byte regen_strength;
        [ObservableProperty] public byte stat_attack_num;
        [ObservableProperty] public byte stat_command_exe_count;
        [ObservableProperty] public byte stat_consent;
        [ObservableProperty] public byte stat_energy;
        [ObservableProperty] public int current_hp;
        [ObservableProperty] public int current_mp;
        [ObservableProperty] public int current_ctb;
        [ObservableProperty] public sbyte stat_death_status;
        [ObservableProperty] public uint bribe_gil_spent;
        [ObservableProperty] public bool stat_limit_bar_flag;
        [ObservableProperty] public byte stat_limit_bar_flag_cam;
        [ObservableProperty] public int damage_hp;
        [ObservableProperty] public int damage_mp;
        [ObservableProperty] public int damage_ctb;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(InBattle))] public byte in_battle;
        [ObservableProperty] public byte stat_target_list;
        [ObservableProperty] public byte stat_death;
        [ObservableProperty] public bool stat_escape_flag;
        [ObservableProperty] public byte stat_stone;
        [ObservableProperty] public bool stat_exist_flag;
        [ObservableProperty] public byte stat_action;
        [ObservableProperty] public bool in_ctb_list;
        [ObservableProperty] public bool in_hp_list;
        [ObservableProperty] public byte stat_cursor;
        [ObservableProperty] public bool stat_effect_target_flag;
        [ObservableProperty] public bool stat_regen_damage_flag;
        [ObservableProperty] public byte stat_event_chr;
        [ObservableProperty] public bool stat_blow_exist_flag;
        [ObservableProperty] public byte steal_count;
        [ObservableProperty] public byte stat_will_die;
        [ObservableProperty] public byte stat_cursor_element;
        [ObservableProperty] public byte stat_effvar;
        [ObservableProperty] public byte stat_effect_hit_num;
        [ObservableProperty] public byte stat_magic_effect_ground;
        [ObservableProperty] public byte stat_magic_effect_water;
        [ObservableProperty] public short stat_sound_hit_num;
        [ObservableProperty] public byte stat_info_mes_id;
        [ObservableProperty] public byte stat_live_mes_id;
        [ObservableProperty] public int ptr_script_chunks;
        [ObservableProperty] public int ptr_script_data;
        [ObservableProperty] public int ptr_base_stats;
        [ObservableProperty] public int ptr_base_en_stats;
        [ObservableProperty] public int loot;


        [ObservableProperty] public bool flagStatusSufferKo;
        [ObservableProperty] public bool flagStatusSufferZombie;
        [ObservableProperty] public bool flagStatusSufferPetrification;
        [ObservableProperty] public bool flagStatusSufferPoison;
        [ObservableProperty] public bool flagStatusSufferBreakPower;
        [ObservableProperty] public bool flagStatusSufferBreakMagic;
        [ObservableProperty] public bool flagStatusSufferBreakArmor;
        [ObservableProperty] public bool flagStatusSufferBreakMental;
        [ObservableProperty] public bool flagStatusSufferConfusion;
        [ObservableProperty] public bool flagStatusSufferBerserk;
        [ObservableProperty] public bool flagStatusSufferProvoke;
        [ObservableProperty] public bool flagStatusSufferThreaten;

        [ObservableProperty] public bool flagStatusSufferExtraScan;
        [ObservableProperty] public bool flagStatusSufferExtraDistillPower;
        [ObservableProperty] public bool flagStatusSufferExtraDistillMana;
        [ObservableProperty] public bool flagStatusSufferExtraDistillSpeed;
        [ObservableProperty] public bool flagStatusSufferExtraDistillUnused;
        [ObservableProperty] public bool flagStatusSufferExtraDistillAbility;
        [ObservableProperty] public bool flagStatusSufferExtraShield;
        [ObservableProperty] public bool flagStatusSufferExtraBoost;
        [ObservableProperty] public bool flagStatusSufferExtraEject;
        [ObservableProperty] public bool flagStatusSufferExtraAutoLife;
        [ObservableProperty] public bool flagStatusSufferExtraCurse;
        [ObservableProperty] public bool flagStatusSufferExtraDefend;
        [ObservableProperty] public bool flagStatusSufferExtraGuard;
        [ObservableProperty] public bool flagStatusSufferExtraSentinel;
        [ObservableProperty] public bool flagStatusSufferExtraDoom;

        // Calculated
        public bool InBattle => In_battle > 0;
        [ObservableProperty] public short dictionaryId;
        [ObservableProperty] public string dictionaryName;

        public string DisplayName => "["+ DictionaryId + "] " + DictionaryName;

        public static BattleTrackerChr_Wrapper Wrap(MemoryChr chr)
        {
            BattleTrackerChr_Wrapper wrapper = new();

            PropertyUtil.CopyProperties(chr, wrapper);

            return wrapper;
        }
        public MemoryChr Unwrap()
        {
            MemoryChr chr = new();

            PropertyUtil.CopyProperties(this, chr);

            return chr;
        }
    }
}
