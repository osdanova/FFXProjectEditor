using FFXProjectEditor.FfxLib.Dictionaries;
using System.Collections.Generic;
using System.Linq;

namespace FFXProjectEditor.FfxLib.Common
{
    public class EquipmentPrice_Util
    {
        public static int GetEquipmentPrice(EquipmentStruct equipment, List<int> autoAbilityPrices = null)
        {
            if(autoAbilityPrices == null || autoAbilityPrices.Count == 0)
                autoAbilityPrices = AutoAbilityPrice_Dictionary.Instance.Values.ToList();

            int price = 0;
            if(equipment.Slot_count == 1)
            {
                ushort autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability1);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);

                price += 12;
            }
            if (equipment.Slot_count == 2)
            {
                ushort autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability1);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);
                autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability2);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);

                price = (int)(price * 1.5);
                price += 18;
            }
            if (equipment.Slot_count == 3)
            {
                int abilityCount = 0;
                ushort autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability1);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);
                if (autoAbilityId != 255) abilityCount++;
                autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability2);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);
                if (autoAbilityId != 255) abilityCount++;
                autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability3);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);
                if (autoAbilityId != 255) abilityCount++;

                price = (int)(price * 4.5);
                price += 56;
                if(abilityCount > 1)
                    price = (int)(price / 1.5);
            }
            if (equipment.Slot_count == 4)
            {
                int abilityCount = 0;
                ushort autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability1);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);
                if (autoAbilityId != 255) abilityCount++;
                autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability2);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);
                if (autoAbilityId != 255) abilityCount++;
                autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability3);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);
                if (autoAbilityId != 255) abilityCount++;
                autoAbilityId = FfxCommon_Util.GetGameIndex(equipment.Ability4);
                price += GetSellPrice(autoAbilityId, autoAbilityPrices);
                if (autoAbilityId != 255) abilityCount++;

                price = (int)(price * 15);
                price += 187;
                if (abilityCount == 2)
                    price = (int)(price / 2);
                if (abilityCount > 2)
                    price = (int)(price / 3);
            }

            return price;
        }

        private static int GetSellPrice(ushort abilityId, List<int> autoAbilityPrices)
        {
            if (abilityId == 255)
                return 0;

            return (autoAbilityPrices[abilityId] / 4);
        }
    }
}
