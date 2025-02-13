using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Common
{
    public class StatusByteList
    {
        // 25 statuses

        // Permanent
        [Data] public byte Death { get; set; }
        [Data] public byte Zombie { get; set; }
        [Data] public byte Petrify { get; set; }
        [Data] public byte Poison { get; set; }
        [Data] public byte BreakPower { get; set; }
        [Data] public byte BreakMagic { get; set; }
        [Data] public byte BreakArmor { get; set; }
        [Data] public byte BreakMental { get; set; }
        [Data] public byte Confuse { get; set; }
        [Data] public byte Berserk { get; set; }
        [Data] public byte Provoke { get; set; }
        [Data] public byte Threaten { get; set; }

        // Temporal
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
