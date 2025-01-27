using FFXProjectEditor.FfxLib.Monster;
using FFXProjectEditor.Utils.Encoding;
using System.IO;

namespace FFXProjectEditor.Controls.Mon
{
    internal class Mon_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal Monster_File LoadedFile { get; set; }
        public string Name { get; set; }
        public uint Hp { get; set; }
        string FilePath { get; set; }
        public ushort StealId { get; set; }
        public ushort StealRareId { get; set; }

        public Mon_DataModel(Monster_File file, string filepath)
        {
            LoadedFile = file;
            FilePath = filepath;
            Hp = LoadedFile.StatSheetFile.Hp;
            Name = FfxEncoding.DecodeScript(LoadedFile.StatSheetFile.NameScriptBytes).GetString(FfxEncoding.JpDecoder);

            StealId = LoadedFile.LootFile.StealId;
            StealRareId = LoadedFile.LootFile.StealRareId;
        }

        public void Save()
        {
            LoadedFile.StatSheetFile.Hp = Hp;
            LoadedFile.LootFile.StealId = StealId;
            LoadedFile.LootFile.StealRareId = StealRareId;
            File.WriteAllBytes(FilePath, LoadedFile.Write());
        }
    }
}
