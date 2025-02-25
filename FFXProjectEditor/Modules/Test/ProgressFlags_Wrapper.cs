using FFXProjectEditor.Utils;
using System.Diagnostics;

namespace FFXProjectEditor.Modules.Test
{
    internal class ProgressFlags_Wrapper
    {
        private ushort Bits { get; set; }

        public ProgressFlags_Wrapper(ushort bits) {  Bits = bits; }

        public bool Flag0 { get => Bits.GetBit(0); set { if (Flag0 != value) Debug.WriteLine("ProgFlag0: " + value); Bits = Bits.SetBit(0, value); } }
        public bool Flag1 { get => Bits.GetBit(1); set { if (Flag1 != value) Debug.WriteLine("ProgFlag1: " + value); Bits = Bits.SetBit(1, value); } }
        public bool Flag2 { get => Bits.GetBit(2); set { if (Flag2 != value) Debug.WriteLine("ProgFlag2: " + value); Bits = Bits.SetBit(2, value); } }
        public bool Flag3 { get => Bits.GetBit(3); set { if (Flag3 != value) Debug.WriteLine("ProgFlag3: " + value); Bits = Bits.SetBit(3, value); } }
        public bool Flag4 { get => Bits.GetBit(4); set { if (Flag4 != value) Debug.WriteLine("ProgFlag4: " + value); Bits = Bits.SetBit(4, value); } }
        public bool Flag5 { get => Bits.GetBit(5); set { if (Flag5 != value) Debug.WriteLine("ProgFlag5: " + value); Bits = Bits.SetBit(5, value); } }
        public bool Flag6 { get => Bits.GetBit(6); set { if (Flag6 != value) Debug.WriteLine("ProgFlag6: " + value); Bits = Bits.SetBit(6, value); } }
        public bool Flag7 { get => Bits.GetBit(7); set { if (Flag7 != value) Debug.WriteLine("ProgFlag7: " + value); Bits = Bits.SetBit(7, value); } }
        public bool Flag8 { get => Bits.GetBit(8); set { if (Flag8 != value) Debug.WriteLine("ProgFlag8: " + value); Bits = Bits.SetBit(8, value); } }
        public bool Flag9 { get => Bits.GetBit(9); set { if (Flag9 != value) Debug.WriteLine("ProgFlag9: " + value); Bits = Bits.SetBit(9, value); } }
        public bool Flag10 { get => Bits.GetBit(10); set { if (Flag10 != value) Debug.WriteLine("ProgFlag10: " + value); Bits = Bits.SetBit(10, value); } }
        public bool Flag11 { get => Bits.GetBit(11); set { if (Flag11 != value) Debug.WriteLine("ProgFlag11: " + value); Bits = Bits.SetBit(11, value); } }
        public bool Flag12 { get => Bits.GetBit(12); set { if (Flag12 != value) Debug.WriteLine("ProgFlag12: " + value); Bits = Bits.SetBit(12, value); } }
        public bool Flag13 { get => Bits.GetBit(13); set { if (Flag13 != value) Debug.WriteLine("ProgFlag13: " + value); Bits = Bits.SetBit(13, value); } }
        public bool Flag14 { get => Bits.GetBit(14); set { if (Flag14 != value) Debug.WriteLine("ProgFlag14: " + value); Bits = Bits.SetBit(14, value); } }
        public bool Flag15 { get => Bits.GetBit(15); set { if (Flag15 != value) Debug.WriteLine("ProgFlag15: " + value); Bits = Bits.SetBit(15, value); } }
        public bool Flag16 { get => Bits.GetBit(16); set { if (Flag16 != value) Debug.WriteLine("ProgFlag16: " + value); Bits = Bits.SetBit(16, value); } }
        public bool Flag17 { get => Bits.GetBit(17); set { if (Flag17 != value) Debug.WriteLine("ProgFlag17: " + value); Bits = Bits.SetBit(17, value); } }
        public bool Flag18 { get => Bits.GetBit(18); set { if (Flag18 != value) Debug.WriteLine("ProgFlag18: " + value); Bits = Bits.SetBit(18, value); } }
        public bool Flag19 { get => Bits.GetBit(19); set { if (Flag19 != value) Debug.WriteLine("ProgFlag19: " + value); Bits = Bits.SetBit(19, value); } }
        public bool Flag20 { get => Bits.GetBit(20); set { if (Flag20 != value) Debug.WriteLine("ProgFlag20: " + value); Bits = Bits.SetBit(20, value); } }
        public bool Flag21 { get => Bits.GetBit(21); set { if (Flag21 != value) Debug.WriteLine("ProgFlag21: " + value); Bits = Bits.SetBit(21, value); } }
        public bool Flag22 { get => Bits.GetBit(22); set { if (Flag22 != value) Debug.WriteLine("ProgFlag22: " + value); Bits = Bits.SetBit(22, value); } }
        public bool Flag23 { get => Bits.GetBit(23); set { if (Flag23 != value) Debug.WriteLine("ProgFlag23: " + value); Bits = Bits.SetBit(23, value); } }
        public bool Flag24 { get => Bits.GetBit(24); set { if (Flag24 != value) Debug.WriteLine("ProgFlag24: " + value); Bits = Bits.SetBit(24, value); } }
        public bool Flag25 { get => Bits.GetBit(25); set { if (Flag25 != value) Debug.WriteLine("ProgFlag25: " + value); Bits = Bits.SetBit(25, value); } }
        public bool Flag26 { get => Bits.GetBit(26); set { if (Flag26 != value) Debug.WriteLine("ProgFlag26: " + value); Bits = Bits.SetBit(26, value); } }
        public bool Flag27 { get => Bits.GetBit(27); set { if (Flag27 != value) Debug.WriteLine("ProgFlag27: " + value); Bits = Bits.SetBit(27, value); } }
        public bool Flag28 { get => Bits.GetBit(28); set { if (Flag28 != value) Debug.WriteLine("ProgFlag28: " + value); Bits = Bits.SetBit(28, value); } }
        public bool Flag29 { get => Bits.GetBit(29); set { if (Flag29 != value) Debug.WriteLine("ProgFlag29: " + value); Bits = Bits.SetBit(29, value); } }
        public bool Flag30 { get => Bits.GetBit(30); set { if (Flag30 != value) Debug.WriteLine("ProgFlag30: " + value); Bits = Bits.SetBit(30, value); } }
        public bool Flag31 { get => Bits.GetBit(31); set { if (Flag31 != value) Debug.WriteLine("ProgFlag31: " + value); Bits = Bits.SetBit(31, value); } }
    }
}
