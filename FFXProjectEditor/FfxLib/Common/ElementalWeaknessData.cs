using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.Utils;
using Xe.BinaryMapper;

namespace FFXProjectEditor.FfxLib.Common
{
    public class ElementalWeaknessData
    {
        [Data] public Element_Flags Absorb { get; set; }
        [Data] public Element_Flags Immune { get; set; }
        [Data] public Element_Flags Resist { get; set; }
        [Data] public Element_Flags Weak { get; set; }

        public bool AbsorbFire
        {
            get => BitFlag_Util.IsFlagSet(Absorb, Element_Flags.Fire);
            set => Absorb = BitFlag_Util.SetFlag(Absorb, Element_Flags.Fire, value);
        }
        public bool AbsorbBlizzard
        {
            get => BitFlag_Util.IsFlagSet(Absorb, Element_Flags.Blizzard);
            set => Absorb = BitFlag_Util.SetFlag(Absorb, Element_Flags.Blizzard, value);
        }
        public bool AbsorbThunder
        {
            get => BitFlag_Util.IsFlagSet(Absorb, Element_Flags.Thunder);
            set => Absorb = BitFlag_Util.SetFlag(Absorb, Element_Flags.Thunder, value);
        }
        public bool AbsorbWater
        {
            get => BitFlag_Util.IsFlagSet(Absorb, Element_Flags.Water);
            set => Absorb = BitFlag_Util.SetFlag(Absorb, Element_Flags.Water, value);
        }
        public bool AbsorbHoly
        {
            get => BitFlag_Util.IsFlagSet(Absorb, Element_Flags.Holy);
            set => Absorb = BitFlag_Util.SetFlag(Absorb, Element_Flags.Holy, value);
        }

        public bool ImmuneFire
        {
            get => BitFlag_Util.IsFlagSet(Immune, Element_Flags.Fire);
            set => Immune = BitFlag_Util.SetFlag(Immune, Element_Flags.Fire, value);
        }
        public bool ImmuneBlizzard
        {
            get => BitFlag_Util.IsFlagSet(Immune, Element_Flags.Blizzard);
            set => Immune = BitFlag_Util.SetFlag(Immune, Element_Flags.Blizzard, value);
        }
        public bool ImmuneThunder
        {
            get => BitFlag_Util.IsFlagSet(Immune, Element_Flags.Thunder);
            set => Immune = BitFlag_Util.SetFlag(Immune, Element_Flags.Thunder, value);
        }
        public bool ImmuneWater
        {
            get => BitFlag_Util.IsFlagSet(Immune, Element_Flags.Water);
            set => Immune = BitFlag_Util.SetFlag(Immune, Element_Flags.Water, value);
        }
        public bool ImmuneHoly
        {
            get => BitFlag_Util.IsFlagSet(Immune, Element_Flags.Holy);
            set => Immune = BitFlag_Util.SetFlag(Immune, Element_Flags.Holy, value);
        }

        public bool ResistFire
        {
            get => BitFlag_Util.IsFlagSet(Resist, Element_Flags.Fire);
            set => Resist = BitFlag_Util.SetFlag(Resist, Element_Flags.Fire, value);
        }
        public bool ResistBlizzard
        {
            get => BitFlag_Util.IsFlagSet(Resist, Element_Flags.Blizzard);
            set => Resist = BitFlag_Util.SetFlag(Resist, Element_Flags.Blizzard, value);
        }
        public bool ResistThunder
        {
            get => BitFlag_Util.IsFlagSet(Resist, Element_Flags.Thunder);
            set => Resist = BitFlag_Util.SetFlag(Resist, Element_Flags.Thunder, value);
        }
        public bool ResistWater
        {
            get => BitFlag_Util.IsFlagSet(Resist, Element_Flags.Water);
            set => Resist = BitFlag_Util.SetFlag(Resist, Element_Flags.Water, value);
        }
        public bool ResistHoly
        {
            get => BitFlag_Util.IsFlagSet(Resist, Element_Flags.Holy);
            set => Resist = BitFlag_Util.SetFlag(Resist, Element_Flags.Holy, value);
        }

        public bool WeakFire
        {
            get => BitFlag_Util.IsFlagSet(Weak, Element_Flags.Fire);
            set => Weak = BitFlag_Util.SetFlag(Weak, Element_Flags.Fire, value);
        }
        public bool WeakBlizzard
        {
            get => BitFlag_Util.IsFlagSet(Weak, Element_Flags.Blizzard);
            set => Weak = BitFlag_Util.SetFlag(Weak, Element_Flags.Blizzard, value);
        }
        public bool WeakThunder
        {
            get => BitFlag_Util.IsFlagSet(Weak, Element_Flags.Thunder);
            set => Weak = BitFlag_Util.SetFlag(Weak, Element_Flags.Thunder, value);
        }
        public bool WeakWater
        {
            get => BitFlag_Util.IsFlagSet(Weak, Element_Flags.Water);
            set => Weak = BitFlag_Util.SetFlag(Weak, Element_Flags.Water, value);
        }
        public bool WeakHoly
        {
            get => BitFlag_Util.IsFlagSet(Weak, Element_Flags.Holy);
            set => Weak = BitFlag_Util.SetFlag(Weak, Element_Flags.Holy, value);
        }
    }
}
