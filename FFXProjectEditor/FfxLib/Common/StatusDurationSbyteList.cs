using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Common
{
    public class StatusDurationSbyteList
    {
        // 13 statuses
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
