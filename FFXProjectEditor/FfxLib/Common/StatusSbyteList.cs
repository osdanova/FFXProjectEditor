using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Common
{
    public class StatusSbyteList
    {
        // 25 statuses

        // Permanent
        [Data] public sbyte Death { get; set; }
        [Data] public sbyte Zombie { get; set; }
        [Data] public sbyte Petrify { get; set; }
        [Data] public sbyte Poison { get; set; }
        [Data] public sbyte BreakPower { get; set; }
        [Data] public sbyte BreakMagic { get; set; }
        [Data] public sbyte BreakArmor { get; set; }
        [Data] public sbyte BreakMental { get; set; }
        [Data] public sbyte Confuse { get; set; }
        [Data] public sbyte Berserk { get; set; }
        [Data] public sbyte Provoke { get; set; }
        [Data] public sbyte Threaten { get; set; }

        // Temporal
        [Data] public sbyte Sleep { get; set; }
        [Data] public sbyte Silence { get; set; }
        [Data] public sbyte Darkness { get; set; }
        [Data] public sbyte Shell { get; set; }
        [Data] public sbyte Protect { get; set; }
        [Data] public sbyte Reflect { get; set; }
        [Data] public sbyte NulTide { get; set; }
        [Data] public sbyte NulBlaze { get; set; }
        [Data] public sbyte NulShock { get; set; }
        [Data] public sbyte NulFrost { get; set; }
        [Data] public sbyte Regen { get; set; }
        [Data] public sbyte Haste { get; set; }
        [Data] public sbyte Slow { get; set; }
    }
}
