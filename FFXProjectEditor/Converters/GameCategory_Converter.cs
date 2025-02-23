using FFXProjectEditor.Utils;
using System.Collections.Generic;

namespace FFXProjectEditor.Converters
{
    internal class GameCategory_Converter : BaseEnumStringConverter<byte>
    {
        public GameCategory_Converter()
        {
            Options = new Dictionary<byte, string>
            {
                {0, "[0] -"},
                {1, "[1] Models"},
                {2, "[2] Items"},
                {3, "[3] Commands"},
                {4, "[4] Monster Commands 1"},
                {5, "[5] Cat5"},
                {6, "[6] Monster Commands 2"},
                {7, "[7] Cat7"},
                {8, "[8] Auto Abilities"},
                {9, "[8] Cat9"},
                {10, "[10] Key Items"},
            };
        }
    }
}
