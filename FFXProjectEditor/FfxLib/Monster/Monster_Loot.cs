using System.IO;
using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Monster
{
    public class Monster_Loot
    {
        [Data] public short Gil { get; set; }
        [Data] public short Ap { get; set; }
        [Data] public short ApOverkill { get; set; }
        [Data] public ushort RonsoRageId { get; set; }

        // Drops
        [Data] public byte Drop1Chance { get; set; }
        [Data] public byte Drop2Chance { get; set; }
        [Data] public byte StealChance { get; set; }
        [Data] public byte GearChance { get; set; }

        [Data] public ushort Drop1Id { get; set; }
        [Data] public ushort Drop1RareId { get; set; }
        [Data] public ushort Drop2Id { get; set; }
        [Data] public ushort Drop2RareId { get; set; }
        [Data] public byte Drop1Count { get; set; }
        [Data] public byte Drop1RareCount { get; set; }
        [Data] public byte Drop2Count { get; set; }
        [Data] public byte Drop2RareCount { get; set; }

        // Overkills
        [Data] public ushort DropOverkillId { get; set; }
        [Data] public ushort DropOverkillRareId { get; set; }
        [Data] public ushort DropOverkill2Id { get; set; }
        [Data] public ushort DropOverkill2RareId { get; set; }
        [Data] public byte DropOverkillCount { get; set; }
        [Data] public byte DropOverkillRareCount { get; set; }
        [Data] public byte DropOverkill2Count { get; set; }
        [Data] public byte DropOverkill2RareCount { get; set; }

        // Steals
        [Data] public ushort StealId { get; set; }
        [Data] public ushort StealRareId { get; set; }
        [Data] public byte StealCount { get; set; }
        [Data] public byte StealRareCount { get; set; }
        [Data] public ushort BribeId { get; set; }
        [Data] public byte BribeCount { get; set; }

        // Gear
        [Data] public byte GearSlotCount { get; set; }
        [Data] public byte GearFormula { get; set; }
        [Data] public byte GearCrit { get; set; }
        [Data] public byte GearAttack { get; set; }
        [Data] public byte GearAbilityCount { get; set; }
        [Data] public LootGearAbilities TidusAbilities { get; set; }
        [Data] public LootGearAbilities YunaAbilities { get; set; }
        [Data] public LootGearAbilities AuronAbilities { get; set; }
        [Data] public LootGearAbilities KimahriAbilities { get; set; }
        [Data] public LootGearAbilities WakkaAbilities { get; set; }
        [Data] public LootGearAbilities LuluAbilities { get; set; }
        [Data] public LootGearAbilities RikkuAbilities { get; set; }

        // Extra
        [Data] public byte ZanmatoLevel { get; set; }
        [Data] public byte Unk1 { get; set; }
        [Data] public byte Unk2 { get; set; }
        [Data] public byte Unk3 { get; set; }
        [Data(Count=3)] public byte[] Padding { get; set; }

        public Monster_Loot()
        {
            TidusAbilities = new();
            YunaAbilities = new();
            AuronAbilities = new();
            KimahriAbilities = new();
            WakkaAbilities = new();
            LuluAbilities = new();
            RikkuAbilities = new();
            Padding = new byte[3];
        }

        public class LootGearAbilities
        {
            [Data(Count=8)] public ushort[] WeaponAbilities { get; set; }
            [Data(Count=8)] public ushort[] ArmorAbilities { get; set; }

            public LootGearAbilities()
            {
                WeaponAbilities = new ushort[8];
                ArmorAbilities = new ushort[8];
            }
        }

        public static Monster_Loot ReadSingle(byte[] byteFile)
        {
            using (MemoryStream stream = new MemoryStream(byteFile))
            {
                return BinaryMapping.ReadObject<Monster_Loot>(stream);
            }
        }

        public byte[] WriteSingle()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryMapping.WriteObject<Monster_Loot>(stream, this);
                return stream.ToArray();
            }
        }
    }
}
