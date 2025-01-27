using FFXProjectEditor.FfxLib.Dictionaries;
using System;

namespace FFXProjectEditor.FfxLib.Common
{
    public class FfxCommon_Util
    {
        /*
         * Operations to get and set info from game indices
         */
        public static GameCategory_Enum GetCommandCategory(ushort entry)
        {
            return (GameCategory_Enum)((entry & 0xF000) >> 12);
        }

        public static ushort GetCommandIndex(ushort entry)
        {
            return (ushort)(entry & 0x0FFF);
        }

        public static ushort SetCommandCategory(ushort entry, GameCategory_Enum valueEnum)
        {
            byte value = (byte)valueEnum;

            if (value < 0 || value > 0xF)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0x0 and 0xF.");

            // Clear the high nibble and set the new value
            entry = (ushort)((entry & 0x0FFF) | (value << 12));

            return entry;
        }

        public static ushort SetCommandIndex(ushort entry, ushort value)
        {
            if (value < 0 || value > 0xFFF)
                throw new ArgumentOutOfRangeException(nameof(value), "value must be between 0x000 and 0xFFF.");

            // Clear the low bytes and set the new value
            entry = (ushort)((entry & 0xF000) | (value & 0x0FFF));

            return entry;
        }

        public static string GetCommandName(GameCategory_Enum category, ushort index)
        {
            if (category == GameCategory_Enum.None && index == 0)
            {
                return "";
            }
            if (category == GameCategory_Enum.Items)
            {
                if (!Item_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return Item_Dictionary.Instance[index];
            }
            if (category == GameCategory_Enum.Commands)
            {
                if (!CommandCharacter_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return CommandCharacter_Dictionary.Instance[index];
            }
            if (category == GameCategory_Enum.MonMagic1)
            {
                if (!CommandMonster1_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return CommandMonster1_Dictionary.Instance[index];
            }
            if (category == GameCategory_Enum.MonMagic2)
            {
                if (!CommandMonster2_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return CommandMonster2_Dictionary.Instance[index];
            }
            if (category == GameCategory_Enum.AutoAbilities)
            {
                if (!AutoAbility_Dictionary.Instance.ContainsKey(index))
                    return "<NOT_INDEXED>";
                return AutoAbility_Dictionary.Instance[index];
            }

            throw new Exception("[FfxCommon_Util] GetCommandName: Invalid category");
        }
    }
}
