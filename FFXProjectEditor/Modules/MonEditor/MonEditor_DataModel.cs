using FFXProjectEditor.Converters;
using FFXProjectEditor.FfxLib.Monster;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FFXProjectEditor.Modules.MonEditor
{
    internal class MonEditor_DataModel
    {
        MonEditorSelector_DataModel SelectorDM { get; set; }
        Monster_File MonsterFile {  get; set; }
        string MonsterPath { get; set; }
        MonsterStatSheet_Wrapper MonsterStatSheet { get; set; }
        MonsterLoot_Wrapper MonsterLoot { get; set; }

        public List<string> CategoryOptions => new GameCategory_Converter().Options.Values.ToList();

        public MonEditor_DataModel(Monster_File monsterFile, string monsterPath, MonEditorSelector_DataModel selectorDM)
        {
            MonsterFile = monsterFile;
            MonsterPath = monsterPath;
            SelectorDM = selectorDM;
            MonsterStatSheet = MonsterStatSheet_Wrapper.Wrap(MonsterFile.StatSheetFile);
            MonsterLoot = MonsterLoot_Wrapper.Wrap(MonsterFile.LootFile);
            SelectorDM = selectorDM;
        }

        public void Save()
        {
            MonsterFile.StatSheetFile = MonsterStatSheet.Unwrap();
            MonsterFile.LootFile = MonsterLoot.Unwrap();

            File.WriteAllBytes(MonsterPath, MonsterFile.Write());
        }
    }
}
