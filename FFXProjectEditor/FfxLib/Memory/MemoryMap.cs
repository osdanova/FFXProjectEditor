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



        public const int ADDR_EQUIPMENT = 0xD30F2C;
        public const int SIZE_EQUIPMENT = 0x16;
        public const int COUNT_EQUIPMENT = 178;

        public const int ADDR_ARENA_LIST = 0xD30C9C; // 104 monster counts and 35 monster unlocks.

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
        public const int ADDR_SAVEDATA = 0xD2CA90;
        public const int SIZE_SAVEDATA = 0x68C0;

        public const int ADDR_SAVE_RIKKU_ALBHED = 0xD2CA90 + 0xD1; // bool

        public const int ADDR_SAVE_TEMPLE_SEALS = 0xD2CA90 + 0xC5C; // 1 byte bitfield

        public const int ADDR_SAVE_ALBHED_CHARACTERS = 0xD2CA90 + 0x3D10; // uint. Bitfield
        public const int ADDR_SAVE_YOJIMBO_COMPAT = 0xD2CA90 + 0x3DA4; // uint

        public const int ADDR_SAVE_ITEM_IDS = 0xD2CA90 + 0x3ECC; // 112 ushorts
        public const int ADDR_SAVE_ITEM_COUNTS = 0xD2CA90 + 0x40CC; // 112 bytes
        public const int COUNT_SAVE_ITEM = 112; // 112 items

        public const int ADDR_SAVE_KEY_ITEMS = 0xD2CA90 + 0x448C; // 7 bytes. Bitfield


        public const int ADDR_SAVE_SPHERE_MUSIC = 0xD2CDDA;
        public const int ADDR_SAVE_SPHERE_MOVIE = 0xD2CDDB;
        public const int ADDR_SAVE_GIL = 0xD307D8;
        public const int ADDR_SAVE_STATSHEET_TIDUS = 0xD32060;

        /******************************************
         * BLITZBALL
         ******************************************/
        public const int ADDR_BLITZ_SCORE_OWN = 0xD2E0CE; // Byte
        public const int ADDR_BLITZ_SCORE_OPPONENT = 0xD2E0CF; // Byte
        public const int ADDR_BLITZ_HALF = 0xD2E0D0; // Byte. 0 = First; 1 = Second
        public const int ADDR_BLITZ_WINS = 0xD2E1E2; // ushort
        public const int POINTER_BLITZ_TIMER = 0xF2FF14; // Points to absolute address
        public const int OFFSET_BLITZ_TIMER = 0x24C; // Short. Offset from POINTER_BLITZ_TIMER
        //public const int POINTER_BLITZ_TIMER_2 = 0xF27F08; // Alternative in case the other one doesn't work
        //public const int OFFSET_BLITZ_TIMER_2 = 0x6534;

        /******************************************
         * MINIGAMES
         ******************************************/
        public const int ADDR_LIGHT_TOTAL_ALL = 0xD2CE8C; // Ushort
        public const int ADDR_LIGHT_TOTAL_DODGED = 0xD2CE8E; // Ushort
        public const int ADDR_LIGHT_RECORD_STREAK = 0xD2CE90; // Ushort

        public const int POINTER_CHOCOBO_TIMER = 0xF2FF14; // Points to absolute address
        public const int OFFSET_CHOCOBO_TIMER = 0x1D8; // 2 bytes. Decimals, Seconds. Offset from POINTER_CHOCOBO_TIMER
        public const int OFFSET_CHOCOBO_POINTS = 0x1FB; // 4 bytes. Baloons (Own/Trainer), Hits (Own/Trainer). Offset from POINTER_CHOCOBO_TIMER
        //public const int POINTER_CHOCOBO_TIMER_2 = 0xF2FF10; // Points to absolute address
        //public const int OFFSET_CHOCOBO_TIMER_2 = 0x330; // 2 bytes. Decimals, Seconds. Offset from POINTER_CHOCOBO_TIMER

        /******************************************
         * OVERDRIVES
         ******************************************/
        public const int ADDR_TIDUS_OD_COUNT = 0xD3083C; // int
        public const int ADDR_TIDUS_OD_UNLOCK = 0xD307FC; // byte. bitflag (0,1,2,3)
        public const int ADDR_WAKKA_BATTLE_COUNT = 0xD322FC; // int
        public const int ADDR_WAKKA_OD_UNLOCK = 0xD307FE; // byte. bitflag (4,5,6,7)
        public const int ADDR_AURON_OD_UNLOCK = 0xD307FC; // byte. bitflag (4,5,6,7)
        public const int ADDR_KHIMARI_OD_UNLOCK = 0xD307FD; // byte. bitflag (4,5,6,7)
    }
}
