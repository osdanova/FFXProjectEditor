using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Services;

namespace FFXProjectEditor.Utils
{
    public class MemoryBattle_Util
    {
        public static int MonsterListCount = 11;

        public static int GetPlayerListPointer()
        {
            return MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_BATTLE_PLAYER_LIST);
        }
        public static int GetMonsterListPointer()
        {
            return MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_BATTLE_ENEMY_LIST);
        }

        public static int GetPlayerAddress(int playerPosition)
        {
            return GetMonsterListPointer() + playerPosition * MemoryMap.SIZE_BATTLE_CHR_ENTRY;
        }
        public static int GetMonsterAddress(int monsterPosition)
        {
            return GetMonsterListPointer() + monsterPosition * MemoryMap.SIZE_BATTLE_CHR_ENTRY;
        }
    }
}
