using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.Utils;
using static FFXProjectEditor.FfxLib.Common.EquipmentStruct;

namespace FFXProjectEditor.Modules.InventoryTracker
{
    internal partial class Equipment_Wrapper : ObservableObject
    {
        [ObservableProperty] public GameIndex_Wrapper name_id;
        [ObservableProperty] public bool exists;
        [ObservableProperty] public bool flagIsSummon;
        [ObservableProperty] public bool flagIsHidden;
        [ObservableProperty] public bool flagIsCelestial;
        [ObservableProperty] public bool flagIsBrotherhood;
        [ObservableProperty] public Character_Enum character;
        [ObservableProperty] public EquipmentType_Enum type;
        [ObservableProperty] public Character_Enum characterEquipped;
        [ObservableProperty] public byte unk7;
        [ObservableProperty] public DamageFormula_Enum dmg_formula;
        [ObservableProperty] public byte power;
        [ObservableProperty] public byte crit_bonus;
        [ObservableProperty] public byte slot_count;
        [ObservableProperty] public GameIndex_Wrapper model_id;
        [ObservableProperty] public GameIndex_Wrapper ability1;
        [ObservableProperty] public GameIndex_Wrapper ability2;
        [ObservableProperty] public GameIndex_Wrapper ability3;
        [ObservableProperty] public GameIndex_Wrapper ability4;
        [ObservableProperty] public int sellPrice;

        public static Equipment_Wrapper Wrap(EquipmentStruct equipment)
        {
            Equipment_Wrapper wrapper = new();

            PropertyUtil.CopyProperties(equipment, wrapper);

            wrapper.Name_id = GameIndex_Wrapper.Wrap(equipment.Name_id);
            wrapper.Model_id = GameIndex_Wrapper.Wrap(equipment.Model_id);
            wrapper.Ability1 = GameIndex_Wrapper.Wrap(equipment.Ability1);
            wrapper.Ability2 = GameIndex_Wrapper.Wrap(equipment.Ability2);
            wrapper.Ability3 = GameIndex_Wrapper.Wrap(equipment.Ability3);
            wrapper.Ability4 = GameIndex_Wrapper.Wrap(equipment.Ability4);

            return wrapper;
        }

        public EquipmentStruct Unwrap()
        {
            EquipmentStruct equipment = new();

            PropertyUtil.CopyProperties(this, equipment);
            equipment.Name_id = Name_id.Unwrap();
            equipment.Model_id = Model_id.Unwrap();
            equipment.Ability1 = Ability1.Unwrap();
            equipment.Ability2 = Ability2.Unwrap();
            equipment.Ability3 = Ability3.Unwrap();
            equipment.Ability4 = Ability4.Unwrap();

            return equipment;
        }
    }
}
