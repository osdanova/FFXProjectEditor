namespace FFXProjectEditor.FfxLib.Memory
{
    public class MemoryMap
    {
        public const int ADDR_ENEMY_CONTROL = 0xD2A8FA;

        public const int POINTER_FILE_COMMAND = 0xD2A92C; // Points to absolute address
        public const int POINTER_FILE_MONMAGIC1 = 0xD2A930; // Points to absolute address
        public const int POINTER_FILE_MONMAGIC2 = 0xD2A934; // Points to absolute address
        public const int POINTER_FILE_PLY_ROM = 0xD2A938; // Points to absolute address
        public const int POINTER_FILE_ITEM = 0xD2A940; // Points to absolute address
        public const int POINTER_FILE_A_ABILITY = 0xD2A944; // Points to absolute address
        public const int POINTER_FILE_SUM_ASSURE = 0xD2A948; // Points to absolute address
        public const int POINTER_FILE_ST_NUMBER = 0xD2A958; // Points to absolute address
        public const int POINTER_FILE_TAKARA = 0x00D35FEC; // Points to absolute address
        public const int POINTER_FILE_MONSTER1 = 0xD2CA6C; // Points to absolute address
        public const int POINTER_FILE_MONSTER2 = 0xD2CA70; // Points to absolute address
        public const int POINTER_FILE_MONSTER3 = 0xD2CA74; // Points to absolute address



        public const int SIZE_BATTLE_CHR_ENTRY = 0xF90;
        public const int ADDR_BATTLE_ENEMY_COUNT = POINTER_BATTLE_ENEMY_LIST + 93;
        public const int OFFSET_BATTLE_ENEMY_SCALE_V4 = 931;


        /******************************************
         * BATTLE
         ******************************************/

        public const int ADDR_BATTLE_ACTIVE = 0xD2A8E0; // Bool
        public const int ADDR_BATTLE_TRIGGER = 0xD2A8E2; // Random, Scripted
        public const int ADDR_BATTLE_NAME = 0xD2C25A; // String 13
        public const int ADDR_BATTLE_ENCOUNTER_INDEX = 0xD2C259; // Byte

        public const int ADDR_BATTLE_FORMATION_SLOTS = 0xD2c895; // 1 sbyte each. 0xFF = nobody

        public const int ADDR_BTL = 0xD2A8D0;

        public const int ADDR_BTL_DEBUG_SETTINGS = ADDR_BTL + 0x28;

        public const int DEBUG_INVINCIBLE_MON = ADDR_BTL_DEBUG_SETTINGS + 0;
        public const int DEBUG_INVINCIBLE_PLY = ADDR_BTL_DEBUG_SETTINGS + 1;
        public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 2;
        //public const int DEBUG_UNK3 = ADDR_BTL_DEBUG_SETTINGS + 3;
        public const int DEBUG_FREE_CAMERA = ADDR_BTL_DEBUG_SETTINGS + 4;
        //public const int DEBUG_UNK5 = ADDR_BTL_DEBUG_SETTINGS + 5;
        //public const int DEBUG_UNK6 = ADDR_BTL_DEBUG_SETTINGS + 6;
        //public const int DEBUG_UNK7 = ADDR_BTL_DEBUG_SETTINGS + 7;
        public const int DEBUG_NO_MAGIC_EFFECTS = ADDR_BTL_DEBUG_SETTINGS + 8;
        public const int DEBUG_NO_MP_COST = ADDR_BTL_DEBUG_SETTINGS + 9;
        //public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 10;
        //public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 11;
        //public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 12;
        //public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 13;
        //public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 14;
        //public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 15;
        //public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 16;
        //public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 17;
        //public const int DEBUG_MON_CONTROL = ADDR_BTL_DEBUG_SETTINGS + 18;


        public const int POINTER_BATTLE_PLAYER_LIST = 0xD334CC; // Points to absolute address
        public const int POINTER_BATTLE_ENEMY_LIST = 0xD34460; // Points to absolute address

        /******************************************
         * SAVE DATA
         ******************************************/
        public const int ADDR_SAVE_GIL = 0xD307D8;
        public const int ADDR_SAVE_SPHERE_MOVIE = 0xD2CDDB;
        public const int ADDR_SAVE_SPHERE_MUSIC = 0xD2CDDA;
        public const int ADDR_SAVE_STATSHEET_TIDUS = 0xD32060;
    }
}
