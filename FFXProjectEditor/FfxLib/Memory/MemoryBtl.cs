using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Memory
{
    public class MemoryBtl
    {
        [Data(0x10)]			public byte		battle_state { get; set; }
        [Data(0x12)]			public byte		battle_trigger { get; set; }
        
        [Data(0x28)]			public BtlDebug debug_settings { get; set; }
        
        [Data(0x5C)]			public long		ptr_command_bin { get; set; }
        [Data(0x60)]			public long		ptr_monmagic1_bin { get; set; }
        [Data(0x64)]			public long		ptr_monmagic2_bin { get; set; }
        [Data(0x68)]			public long		ptr_ply_rom_bin { get; set; }
        [Data(0x70)]			public long		ptr_item_bin { get; set; }
        [Data(0x74)]			public long		ptr_a_ability_bin { get; set; }
        [Data(0x78)]			public long		ptr_sum_assure_bin { get; set; }
        [Data(0x7C)]			public long		ptr_ctb_base_bin { get; set; }
        [Data(0x80)]			public long		ptr_magic_bin { get; set; }
        [Data(0x84)]			public long		ptr_mot_bin { get; set; }
        [Data(0x88)]			public long		ptr_st_number_bin { get; set; }
        [Data(0x90)]			public long		ptr_sum_grow_bin { get; set; }
        [Data(0x94)]			public long		ptr_kaizou_bin { get; set; }
        
        [Data(0x98)]			public ushort	size_command_bin { get; set; }
        [Data(0x9A)]			public ushort	size_ply_rom_bin { get; set; }
        [Data(0x9E)]			public ushort	size_item_bin { get; set; }
        [Data(0xA0)]			public ushort	size_a_ability_bin { get; set; }
        [Data(0xA2)]			public ushort	size_sum_assure_bin { get; set; }
        [Data(0xA4)]			public ushort	size_ctb_base_bin { get; set; }
        [Data(0xA6)]			public ushort	size_magic_bin { get; set; }
        [Data(0xA8)]			public ushort	size_st_number_bin { get; set; }
        [Data(0xAA)]			public ushort	size_mot_bin { get; set; }
        [Data(0xAE)]			public ushort	size_sum_grow_bin { get; set; }
        [Data(0xB0)]			public ushort	size_kaizou_bin { get; set; }
        
        [Data(0xF4)]			public uint		ptr_btl_bin { get; set; }
        [Data(0xF8)]			public uint		ptr_btl_bin_fields { get; set; }
        [Data(0xFC)]			public uint		ptr_btl_bin_encounters { get; set; }
        [Data(0x100)]			public ushort	btl_bin_field_count { get; set; }
        [Data(0x102)]			public ushort	size_btl_bin { get; set; }
        
        [Data(0x106)]			public  byte	grace { get; set; }
        [Data(0x108)]			public  float	walked_dist { get; set; }
        [Data(0x10C)]			public  float	walked_dist_total { get; set; }
        
        [Data(0x120)]			public uint		ptr_btl_bin_cur_field { get; set; }
        [Data(0x124)]			public uint		ptr_btl_bin_cur_encounter { get; set; }
        [Data(0x128)]			public uint		ptr_btl_bin_cur_group { get; set; }
        [Data(0x12C)]			public uint		ptr_btl_bin_cur_formation { get; set; }
        [Data(0x15C0)]			public uint		chosen_gil { get; set; }
        [Data(0x1984)]			public ushort	battlefield_id { get; set; }
        [Data(0x1986)]			public ushort	field_idx { get; set; }
        [Data(0x1988)]			public byte		group_idx { get; set; }
        [Data(0x1989)]			public byte		formation_idx { get; set; }
        [Data(0x198A,Count=8)]	public byte[]	field_name { get; set; }
        
        [Data(0x1FC5,Count=3)]	public byte[]	frontline { get; set; }
        [Data(0x1FD3,Count=4)]	public byte[]	backline { get; set; }
        
        [Data(0x2008)]			public uint		last_com { get; set; }
        [Data(0x210C)]			public byte		ambush_state { get; set; }
        [Data(0x2121)]			public byte		battle_end_type { get; set; }

        public class BtlDebug
        {
            [Data(0x00)] public bool debug_invincible_mon { get; set; }
            [Data(0x01)] public bool debug_invincible_ply { get; set; }
            [Data(0x02)] public bool debug_mon_control { get; set; }
            [Data(0x04)] public bool debug_free_camera { get; set; }
            [Data(0x08)] public bool debug_no_magic_effects { get; set; }
            [Data(0x09)] public bool debug_no_mp_cost { get; set; }
            [Data(0x10)] public bool debug_no_variance { get; set; }
            [Data(0x11)] public bool debug_never_crit { get; set; }
            [Data(0x12)] public bool debug_always_hit { get; set; }
            [Data(0x14)] public bool debug_always_available_overdrive { get; set; }
            [Data(0x15)] public bool debug_always_crit { get; set; }
            [Data(0x16)] public bool debug_always_1_dmg { get; set; }
            [Data(0x17)] public bool debug_always_9999_dmg { get; set; }
            [Data(0x18)] public bool debug_always_99999_dmg { get; set; }
            [Data(0x19)] public bool debug_always_rare_steal { get; set; }
            [Data(0x1C)] public bool debug_never_overkill { get; set; }
            [Data(0x1E)] public bool debug_never_charge_overdrive { get; set; }
            [Data(0x27)] public bool debug_never_hit { get; set; }
        }
    }
}
