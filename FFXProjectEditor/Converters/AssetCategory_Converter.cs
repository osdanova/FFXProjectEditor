using FFXProjectEditor.Utils;
using System.Collections.Generic;

namespace FFXProjectEditor.Converters
{
    internal class AssetCategory_Converter : BaseEnumStringConverter<byte>
    {
        public AssetCategory_Converter()
        {
            Options = new Dictionary<byte, string>
            {
                {0, "[0] -"},
                {1, "[1] Unk1"},
                {2, "[2] Unk2"},
                {3, "[3] Entity Model"},
                {4, "[4] Equipment Model"},
                {5, "[5] Equipment Name"},
            };
        }
    }
}
