using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.Utils;
using System.Collections.Generic;

namespace FFXProjectEditor.Converters
{
    public class Character_Converter : BaseEnumStringConverter<Character_Enum>
    {
        public Character_Converter()
        {
            Options = new Dictionary<Character_Enum, string>
            {
                {Character_Enum.None, "[-1] -"},
                {Character_Enum.Tidus, "[0] Tidus"},
                {Character_Enum.Yuna, "[1] Yuna"},
                {Character_Enum.Auron, "[2] Auron"},
                {Character_Enum.Kimahri, "[3] Kimahri"},
                {Character_Enum.Wakka, "[4] Wakka"},
                {Character_Enum.Lulu, "[5] Lulu"},
                {Character_Enum.Rikku, "[6] Rikku"},
                {Character_Enum.Seymour, "[7] Seymour"},
                {Character_Enum.Valefor, "[8] Valefor"},
                {Character_Enum.Ifrit, "[9] Ifrit"},
                {Character_Enum.Ixion, "[10] Ixion"},
                {Character_Enum.Shiva, "[11] Shiva"},
                {Character_Enum.Bahamut, "[12] Bahamut"},
                {Character_Enum.Anima, "[13] Anima"},
                {Character_Enum.Yojimbo, "[14] Yojimbo"},
                {Character_Enum.Cindy, "[15] Cindy"},
                {Character_Enum.Sandy, "[16] Sandy"},
                {Character_Enum.Mindy, "[17] Mindy"},
            };
        }
    }
}
