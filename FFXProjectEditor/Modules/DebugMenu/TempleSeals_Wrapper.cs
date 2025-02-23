using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.Utils;
using System;

namespace FFXProjectEditor.Modules.DebugMenu
{
    public partial class TempleSeals_Wrapper : ObservableObject
    {
        [ObservableProperty] public bool besaid;
        [ObservableProperty] public bool kilika;
        [ObservableProperty] public bool djose;
        [ObservableProperty] public bool macalania;
        [ObservableProperty] public bool bevelle;
        [ObservableProperty] public bool zanarkand;
        [ObservableProperty] public bool baaj;

        public static TempleSeals_Wrapper Wrap(byte templeSeals)
        {
            TempleSealFlags flags = (TempleSealFlags)templeSeals;

            TempleSeals_Wrapper wrapper = new TempleSeals_Wrapper();
            wrapper.Besaid = BitFlag_Util.IsFlagSet(flags, TempleSealFlags.Besaid);
            wrapper.Kilika = BitFlag_Util.IsFlagSet(flags, TempleSealFlags.Kilika);
            wrapper.Djose = BitFlag_Util.IsFlagSet(flags, TempleSealFlags.Djose);
            wrapper.Macalania = BitFlag_Util.IsFlagSet(flags, TempleSealFlags.Macalania);
            wrapper.Bevelle = BitFlag_Util.IsFlagSet(flags, TempleSealFlags.Bevelle);
            wrapper.Zanarkand = BitFlag_Util.IsFlagSet(flags, TempleSealFlags.Zanarkand);
            wrapper.Baaj = BitFlag_Util.IsFlagSet(flags, TempleSealFlags.Baaj);

            return wrapper;
        }

        public byte Unwrap()
        {
            TempleSealFlags flags = new TempleSealFlags();

            flags = BitFlag_Util.SetFlag(flags, TempleSealFlags.Besaid, Besaid);
            flags = BitFlag_Util.SetFlag(flags, TempleSealFlags.Kilika, Kilika);
            flags = BitFlag_Util.SetFlag(flags, TempleSealFlags.Djose, Djose);
            flags = BitFlag_Util.SetFlag(flags, TempleSealFlags.Macalania, Macalania);
            flags = BitFlag_Util.SetFlag(flags, TempleSealFlags.Bevelle, Bevelle);
            flags = BitFlag_Util.SetFlag(flags, TempleSealFlags.Zanarkand, Zanarkand);
            flags = BitFlag_Util.SetFlag(flags, TempleSealFlags.Baaj, Baaj);

            return (byte) flags;
        }

        [Flags]
        public enum TempleSealFlags : byte
        {
            Besaid = 0x01,
            Kilika = 0x02,
            Djose = 0x04,
            Macalania = 0x08,
            Bevelle = 0x10,
            Zanarkand = 0x20,
            Baaj = 0x40,
        }
    }
}
