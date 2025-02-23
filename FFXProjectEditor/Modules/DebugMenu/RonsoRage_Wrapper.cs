using FFXProjectEditor.Utils;

namespace FFXProjectEditor.Modules.DebugMenu
{
    internal class RonsoRage_Wrapper
    {
        public ushort RonsoRages { get; set; }

        public RonsoRage_Wrapper(ushort ronsoRages) { RonsoRages = ronsoRages; }

        public bool Jump { get => RonsoRages.GetBit(0); set => RonsoRages = RonsoRages.SetBit(0, value); }
        public bool FireBreath { get => RonsoRages.GetBit(1); set => RonsoRages = RonsoRages.SetBit(1, value); }
        public bool SeedCannon { get => RonsoRages.GetBit(2); set => RonsoRages = RonsoRages.SetBit(2, value); }
        public bool SelfDestruct { get => RonsoRages.GetBit(3); set => RonsoRages = RonsoRages.SetBit(3, value); }
        public bool ThrustKick { get => RonsoRages.GetBit(4); set => RonsoRages = RonsoRages.SetBit(4, value); }
        public bool StoneBreath { get => RonsoRages.GetBit(5); set => RonsoRages = RonsoRages.SetBit(5, value); }
        public bool AquaBreath { get => RonsoRages.GetBit(6); set => RonsoRages = RonsoRages.SetBit(6, value); }
        public bool Doom { get => RonsoRages.GetBit(7); set => RonsoRages = RonsoRages.SetBit(7, value); }
        public bool WhiteWind { get => RonsoRages.GetBit(8); set => RonsoRages = RonsoRages.SetBit(8, value); }
        public bool BadBreath { get => RonsoRages.GetBit(9); set => RonsoRages = RonsoRages.SetBit(9, value); }
        public bool MightyGuard { get => RonsoRages.GetBit(10); set => RonsoRages = RonsoRages.SetBit(10, value); }
        public bool Nova { get => RonsoRages.GetBit(11); set => RonsoRages = RonsoRages.SetBit(11, value); }
    }
}
