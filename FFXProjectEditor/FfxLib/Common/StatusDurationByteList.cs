using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Common
{
    public class StatusDurationByteList
    {
        // 13 statuses
        [Data] public byte Sleep { get; set; }
        [Data] public byte Silence { get; set; }
        [Data] public byte Darkness { get; set; }
        [Data] public byte Shell { get; set; }
        [Data] public byte Protect { get; set; }
        [Data] public byte Reflect { get; set; }
        [Data] public byte NulTide { get; set; }
        [Data] public byte NulBlaze { get; set; }
        [Data] public byte NulShock { get; set; }
        [Data] public byte NulFrost { get; set; }
        [Data] public byte Regen { get; set; }
        [Data] public byte Haste { get; set; }
        [Data] public byte Slow { get; set; }
    }
}
