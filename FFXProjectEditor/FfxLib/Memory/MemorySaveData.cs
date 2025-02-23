using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Memory
{
    // Size = 0x68C0
    public class MemorySaveData
    {
        [Data(0x0)] public ushort current_room_id { get; set; }
        [Data(0x2)] public ushort last_room_id { get; set; }
        [Data(0x4)] public ushort now_eventjump_map_no { get; set; }
        [Data(0x6)] public ushort last_eventjump_map_no { get; set; }
        [Data(0x8)] public ushort now_eventjump_map_id { get; set; }
        [Data(0xA)] public ushort last_eventjump_map_id { get; set; }
        [Data(0xC)] public byte current_spawnpoint { get; set; }
        [Data(0xD)] public byte last_spawnpoint { get; set; }
        [Data(0xE)] public ushort atel_save_dic_index { get; set; }
        [Data(0x10)] public byte atel_battle_scene_group { get; set; }
        [Data(0x20)] public byte atel_is_push_member { get; set; }
        [Data(0x21, Count = 3)] public byte[] atel_push_frontline { get; set; }
        [Data(0x24)] public byte atel_push_party { get; set; }
        [Data(0x28)] public byte is_cam_underwater { get; set; }
        [Data(0x29)] public byte is_map_underwater { get; set; }
        [Data(0x2B)] public byte tk_event_new_game { get; set; }
        [Data(0x2C, Count = 8)] public uint[] affection { get; set; }
        [Data(0xD1)] public byte albhed_rikku { get; set; }
        [Data(0xD6)] public byte atel_force_place_id { get; set; }
        [Data(0xD7)] public byte atel_water_btl_effect { get; set; }
        [Data(0xD8)] public uint on_memory_movie_file_no { get; set; }
        [Data(0xDC)] public uint on_memory_movie_mode { get; set; }
        [Data(0xE0)] public uint on_memory_movie { get; set; }
        [Data(0xE4)] public int rand_encounter_modifiers { get; set; }
        [Data(0xE8)] public ushort btl_end_tag_always { get; set; }
        [Data(0xEA)] public ushort sphere_monitor { get; set; }
        [Data(0xBEC)] public ushort story_progress { get; set; }
        [Data(0xC81)] public ushort unlocked_airship_destinations { get; set; }
        [Data(0x3D0C)] public uint config { get; set; }
        [Data(0x3D10)] public uint unlocked_primers { get; set; }
        [Data(0x3D14)] public uint battle_count { get; set; }
        [Data(0x3D48)] public uint gil { get; set; }
        [Data(0x3D58, Count = 7)] public byte[] party_order { get; set; }
        [Data(0x3DA4)] public uint yojimbo_compatibility { get; set; }
        [Data(0x3DB0)] public uint successful_rikku_steals { get; set; }
        [Data(0x3DB4)] public uint bribe_gil_spent { get; set; }
        [Data(0x3ECC, Count = 112)] public ushort[] inventory_ids { get; set; }
        [Data(0x40CC, Count = 112)] public byte[] inventory_counts { get; set; }
        [Data(0x448C)] public uint ptr_important_bin { get; set; }
        //[Data(0x55CC)] public PlySave ply_tidus { get; set; }
        //[Data(0x5660)] public PlySave ply_yuna { get; set; }
        //[Data(0x56F4)] public PlySave ply_auron { get; set; }
        //[Data(0x5788)] public PlySave ply_kimahri { get; set; }
        //[Data(0x581C)] public PlySave ply_wakka { get; set; }
        //[Data(0x58B0)] public PlySave ply_lulu { get; set; }
        //[Data(0x5944)] public PlySave ply_rikku { get; set; }
        //[Data(0x59D8)] public PlySave ply_seymour { get; set; }
        //[Data(0x5A6C)] public PlySave ply_valefor { get; set; }
        //[Data(0x5B00)] public PlySave ply_ifrit { get; set; }
        //[Data(0x5B94)] public PlySave ply_ixion { get; set; }
        //[Data(0x5C28)] public PlySave ply_shiva { get; set; }
        //[Data(0x5CBC)] public PlySave ply_bahamut { get; set; }
        //[Data(0x5D50)] public PlySave ply_anima { get; set; }
        //[Data(0x5DE4)] public PlySave ply_yojimbo { get; set; }
        //[Data(0x5E78)] public PlySave ply_cindy { get; set; }
        //[Data(0x5F0C)] public PlySave ply_sandy { get; set; }
        //[Data(0x5FA0)] public PlySave ply_mindy { get; set; }
        [Data(0x634C, Count = 360)] public byte[] character_names { get; set; } // each name is at most 20 bytes long. C# won't let me make a 2D array
    }
}
