using FFXProjectEditor.Utils;
using System.Collections.Generic;
using static FFXProjectEditor.FfxLib.Common.EquipmentStruct;

namespace FFXProjectEditor.Converters
{
    public class EquipmentType_Converter : BaseEnumStringConverter<EquipmentType_Enum>
    {
        public EquipmentType_Converter()
        {
            Options = new Dictionary<EquipmentType_Enum, string>
            {
                {EquipmentType_Enum.Weapon, "Weapon"},
                {EquipmentType_Enum.Armor, "Armor"},
            };
        }
    }
}
