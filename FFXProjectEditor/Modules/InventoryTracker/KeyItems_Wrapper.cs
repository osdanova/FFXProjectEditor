using FFXProjectEditor.Utils;

namespace FFXProjectEditor.Modules.InventoryTracker
{
    internal class KeyItems_Wrapper
    {
        public byte[] KeyItemBytes { get; set; } = new byte[7];

        public bool WitheredBouquet { get => KeyItemBytes.GetBit(0); set => KeyItemBytes.SetBit(0, value); }
        public bool Flint { get => KeyItemBytes.GetBit(1); set => KeyItemBytes.SetBit(1, value); }
        public bool CloudyMirror { get => KeyItemBytes.GetBit(2); set => KeyItemBytes.SetBit(2, value); }
        public bool CelestialMirror { get => KeyItemBytes.GetBit(3); set => KeyItemBytes.SetBit(3, value); }
        public bool Primer1 { get => KeyItemBytes.GetBit(4); set => KeyItemBytes.SetBit(4, value); }
        public bool Primer2 { get => KeyItemBytes.GetBit(5); set => KeyItemBytes.SetBit(5, value); }
        public bool Primer3 { get => KeyItemBytes.GetBit(6); set => KeyItemBytes.SetBit(6, value); }
        public bool Primer4 { get => KeyItemBytes.GetBit(7); set => KeyItemBytes.SetBit(7, value); }
        public bool Primer5 { get => KeyItemBytes.GetBit(8); set => KeyItemBytes.SetBit(8, value); }
        public bool Primer6 { get => KeyItemBytes.GetBit(9); set => KeyItemBytes.SetBit(9, value); }
        public bool Primer7 { get => KeyItemBytes.GetBit(10); set => KeyItemBytes.SetBit(10, value); }
        public bool Primer8 { get => KeyItemBytes.GetBit(11); set => KeyItemBytes.SetBit(11, value); }
        public bool Primer9 { get => KeyItemBytes.GetBit(12); set => KeyItemBytes.SetBit(12, value); }
        public bool Primer10 { get => KeyItemBytes.GetBit(13); set => KeyItemBytes.SetBit(13, value); }
        public bool Primer11 { get => KeyItemBytes.GetBit(14); set => KeyItemBytes.SetBit(14, value); }
        public bool Primer12 { get => KeyItemBytes.GetBit(15); set => KeyItemBytes.SetBit(15, value); }
        public bool Primer13 { get => KeyItemBytes.GetBit(16); set => KeyItemBytes.SetBit(16, value); }
        public bool Primer14 { get => KeyItemBytes.GetBit(17); set => KeyItemBytes.SetBit(17, value); }
        public bool Primer15 { get => KeyItemBytes.GetBit(18); set => KeyItemBytes.SetBit(18, value); }
        public bool Primer16 { get => KeyItemBytes.GetBit(19); set => KeyItemBytes.SetBit(19, value); }
        public bool Primer17 { get => KeyItemBytes.GetBit(20); set => KeyItemBytes.SetBit(20, value); }
        public bool Primer18 { get => KeyItemBytes.GetBit(21); set => KeyItemBytes.SetBit(21, value); }
        public bool Primer19 { get => KeyItemBytes.GetBit(22); set => KeyItemBytes.SetBit(22, value); }
        public bool Primer20 { get => KeyItemBytes.GetBit(23); set => KeyItemBytes.SetBit(23, value); }
        public bool Primer21 { get => KeyItemBytes.GetBit(24); set => KeyItemBytes.SetBit(24, value); }
        public bool Primer22 { get => KeyItemBytes.GetBit(25); set => KeyItemBytes.SetBit(25, value); }
        public bool Primer23 { get => KeyItemBytes.GetBit(26); set => KeyItemBytes.SetBit(26, value); }
        public bool Primer24 { get => KeyItemBytes.GetBit(27); set => KeyItemBytes.SetBit(27, value); }
        public bool Primer25 { get => KeyItemBytes.GetBit(28); set => KeyItemBytes.SetBit(28, value); }
        public bool Primer26 { get => KeyItemBytes.GetBit(29); set => KeyItemBytes.SetBit(29, value); }
        public bool SummonersSoul { get => KeyItemBytes.GetBit(30); set => KeyItemBytes.SetBit(30, value); }
        public bool AeonsSoul { get => KeyItemBytes.GetBit(31); set => KeyItemBytes.SetBit(31, value); }
        public bool JechtsSphere { get => KeyItemBytes.GetBit(32); set => KeyItemBytes.SetBit(32, value); }
        public bool RustySword { get => KeyItemBytes.GetBit(33); set => KeyItemBytes.SetBit(33, value); }
        // ???
        public bool SunCrest { get => KeyItemBytes.GetBit(35); set => KeyItemBytes.SetBit(35, value); }
        public bool SunSigil { get => KeyItemBytes.GetBit(36); set => KeyItemBytes.SetBit(36, value); }
        public bool MoonCrest { get => KeyItemBytes.GetBit(37); set => KeyItemBytes.SetBit(37, value); }
        public bool MoonSigil { get => KeyItemBytes.GetBit(38); set => KeyItemBytes.SetBit(38, value); }
        public bool MarsCrest { get => KeyItemBytes.GetBit(39); set => KeyItemBytes.SetBit(39, value); }
        public bool MarsSigil { get => KeyItemBytes.GetBit(40); set => KeyItemBytes.SetBit(40, value); }
        public bool MarkOfConquest { get => KeyItemBytes.GetBit(41); set => KeyItemBytes.SetBit(41, value); }
        public bool SaturnCrest { get => KeyItemBytes.GetBit(42); set => KeyItemBytes.SetBit(42, value); }
        public bool SaturnSigil { get => KeyItemBytes.GetBit(43); set => KeyItemBytes.SetBit(43, value); }
        public bool JupiterCrest { get => KeyItemBytes.GetBit(44); set => KeyItemBytes.SetBit(44, value); }
        public bool JupiterSigil { get => KeyItemBytes.GetBit(45); set => KeyItemBytes.SetBit(45, value); }
        public bool VenusCrest { get => KeyItemBytes.GetBit(46); set => KeyItemBytes.SetBit(46, value); }
        public bool VenusSigil { get => KeyItemBytes.GetBit(47); set => KeyItemBytes.SetBit(47, value); }
        public bool MercuryCrest { get => KeyItemBytes.GetBit(48); set => KeyItemBytes.SetBit(48, value); }
        public bool MercurySigil { get => KeyItemBytes.GetBit(49); set => KeyItemBytes.SetBit(49, value); }
        public bool BlossomCrown { get => KeyItemBytes.GetBit(50); set => KeyItemBytes.SetBit(50, value); }
        public bool FlowerScepter { get => KeyItemBytes.GetBit(51); set => KeyItemBytes.SetBit(51, value); }
    }
}
