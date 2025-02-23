using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FFXProjectEditor.Modules.ArenaTracker
{
    internal class ArenaTracker_DataModel
    {
        ObservableCollection<byte> ArenaCounts { get; set; } = new();
        ObservableCollection<bool> ArenaUnlocks { get; set; } = new();

        public ArenaTracker_DataModel()
        {
            LoadArenaData();
        }

        public void LoadArenaData()
        {
            ArenaCounts.Clear();
            byte[] arenaData = ReadArenaData();

            foreach (byte monsterCount in arenaData.Take(104))
            {
                ArenaCounts.Add(monsterCount);
            }
            foreach (bool monsterUnlock in arenaData.Skip(104).Select(b => b != 0))
            {
                ArenaUnlocks.Add(monsterUnlock);
            }
        }

        public byte[] ReadArenaData()
        {
            return MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_ARENA_LIST, 139);
        }
        public void WriteArenaData()
        {
            List<byte> arenaData = new List<byte>(ArenaCounts);
            foreach(bool unlock in ArenaUnlocks)
            {
                arenaData.Add(Convert.ToByte(unlock));
            }
            MemSharp_Service.Instance.Write<byte>(MemoryMap.ADDR_ARENA_LIST, arenaData.ToArray());
        }
    }
}
