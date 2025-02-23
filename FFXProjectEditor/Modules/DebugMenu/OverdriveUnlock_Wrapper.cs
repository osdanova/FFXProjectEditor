using FFXProjectEditor.Utils;

namespace FFXProjectEditor.Modules.DebugMenu
{
    internal class OverdriveUnlock_Wrapper
    {
        public byte OdByte { get; set; }

        public OverdriveUnlock_Wrapper(byte odByte) { OdByte = odByte; }

        public bool Overdrive0 { get => OdByte.GetBit(0); set => OdByte = OdByte.SetBit(0, value); }
        public bool Overdrive1 { get => OdByte.GetBit(1); set => OdByte = OdByte.SetBit(1, value); }
        public bool Overdrive2 { get => OdByte.GetBit(2); set => OdByte = OdByte.SetBit(2, value); }
        public bool Overdrive3 { get => OdByte.GetBit(3); set => OdByte = OdByte.SetBit(3, value); }
        public bool Overdrive4 { get => OdByte.GetBit(4); set => OdByte = OdByte.SetBit(4, value); }
        public bool Overdrive5 { get => OdByte.GetBit(5); set => OdByte = OdByte.SetBit(5, value); }
        public bool Overdrive6 { get => OdByte.GetBit(6); set => OdByte = OdByte.SetBit(6, value); }
        public bool Overdrive7 { get => OdByte.GetBit(7); set => OdByte = OdByte.SetBit(7, value); }
    }
}
