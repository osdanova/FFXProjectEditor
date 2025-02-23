using FFXProjectEditor.FfxLib.Dictionaries;
using System;

namespace FFXProjectEditor.FfxLib.Common
{
    public class FfxCommon_Util
    {
        /*
         * Operations to get and set info from game indices
         */
        public static byte GetGameCategory(ushort entry)
        {
            return (byte)((entry & 0xF000) >> 12);
        }

        public static ushort GetGameIndex(ushort entry)
        {
            return (ushort)(entry & 0x0FFF);
        }

        public static ushort SetGameCategory(ushort entry, byte valueEnum)
        {
            byte value = valueEnum;

            if (value < 0 || value > 0xF)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0x0 and 0xF.");

            // Clear the high nibble and set the new value
            entry = (ushort)((entry & 0x0FFF) | (value << 12));

            return entry;
        }

        public static ushort SetGameIndex(ushort entry, ushort value)
        {
            if (value < 0 || value > 0xFFF)
                throw new ArgumentOutOfRangeException(nameof(value), "value must be between 0x000 and 0xFFF.");

            // Clear the low bytes and set the new value
            entry = (ushort)((entry & 0xF000) | (value & 0x0FFF));

            return entry;
        }

        public static string GetGameIndexName(byte category, ushort index)
        {
            GameCategory_Enum categoryEnum = (GameCategory_Enum)category;

            if (categoryEnum == GameCategory_Enum.None && (index == 0 || index == 255))
            {
                return "";
            }
            if (categoryEnum == GameCategory_Enum.Items)
            {
                if (!Item_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return Item_Dictionary.Instance[index];
            }
            if (categoryEnum == GameCategory_Enum.Commands)
            {
                if (!CommandCharacter_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return CommandCharacter_Dictionary.Instance[index];
            }
            if (categoryEnum == GameCategory_Enum.MonMagic1)
            {
                if (!CommandMonster1_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return CommandMonster1_Dictionary.Instance[index];
            }
            if (categoryEnum == GameCategory_Enum.MonMagic2)
            {
                if (!CommandMonster2_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return CommandMonster2_Dictionary.Instance[index];
            }
            if (categoryEnum == GameCategory_Enum.AutoAbilities)
            {
                if (!AutoAbility_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return AutoAbility_Dictionary.Instance[index];
            }

            throw new Exception("[FfxCommon_Util] GetGameIndexName: Invalid category");
        }

        public static string GetAssetIndexName(byte category, ushort index)
        {
            AssetCategory_Enum categoryEnum = (AssetCategory_Enum)category;

            if (categoryEnum == AssetCategory_Enum.None && (index == 0 || index == 255))
            {
                return "";
            }
            if (categoryEnum == AssetCategory_Enum.EquipmentModel)
            {
                return "<TODO>";
            }
            if (categoryEnum == AssetCategory_Enum.EquipmentName)
            {
                return "<TODO>";
            }

            throw new Exception("[FfxCommon_Util] GetAssetIndexName: Invalid category");
        }
    }
}
