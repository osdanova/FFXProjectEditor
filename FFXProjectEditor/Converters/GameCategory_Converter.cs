using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.Utils;
using System.Collections.Generic;

namespace FFXProjectEditor.Converters
{
    internal class GameCategory_Converter : BaseEnumStringConverter<GameCategory_Enum>
    {
        public GameCategory_Converter()
        {
            Options = new Dictionary<GameCategory_Enum, string>
            {
                {GameCategory_Enum.None, "[0] -"},
                {GameCategory_Enum.Models, "[1] Models"},
                {GameCategory_Enum.Items, "[2] Items"},
                {GameCategory_Enum.Commands, "[3] Commands"},
                {GameCategory_Enum.MonMagic1, "[4] Monster Commands 1"},
                {GameCategory_Enum.Cat5, "[5] Cat5"},
                {GameCategory_Enum.MonMagic2, "[6] Monster Commands 2"},
                {GameCategory_Enum.Cat7, "[7] Cat7"},
                {GameCategory_Enum.AutoAbilities, "[8] Auto Abilities"},
                {GameCategory_Enum.Cat9, "[8] Cat9"},
                {GameCategory_Enum.KeyItems, "[10] Key Items"},
            };
        }
    }
}
