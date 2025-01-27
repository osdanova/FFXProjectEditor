using System;

namespace FFXProjectEditor.FfxLib.Dictionaries
{
    [Flags]
    public enum Element_Flags : byte
    {
        Fire = 0x01,
        Blizzard = 0x02,
        Thunder = 0x04,
        Water = 0x08,
        Holy = 0x10
    }
}
