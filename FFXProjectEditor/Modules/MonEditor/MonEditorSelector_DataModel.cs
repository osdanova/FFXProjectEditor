using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.FfxLib.Monster;
using FFXProjectEditor.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FFXProjectEditor.Modules.MonEditor
{
    public partial class MonEditorSelector_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<MonsterListEntry> LoadedMonsters { get; set; } = new();
        internal ObservableCollection<MonsterListEntry> DisplayedMonsters { get; set; } = new();

        string FilterText { get; set; } = "";

        [ObservableProperty] public bool infoExpanded = true;
        [ObservableProperty] public bool statsExpanded = true;
        [ObservableProperty] public bool propertiesExpanded = true;
        [ObservableProperty] public bool elementalWeaknessesExpanded = true;
        [ObservableProperty] public bool statusExpanded = true;
        [ObservableProperty] public bool menuAbilitiesExpanded = true;
        [ObservableProperty] public bool identifiersExpanded = true;

        [ObservableProperty] public bool lootStatsExpanded = true;
        [ObservableProperty] public bool lootDropsExpanded = true;
        [ObservableProperty] public bool lootStealExpanded = true;
        [ObservableProperty] public bool lootGearExpanded = true;
        [ObservableProperty] public int selectedTab = 0;

        public MonEditorSelector_DataModel()
        {
            LoadEntries();
            ApplyFilter();
        }

        public void LoadEntries()
        {
            if (!Project_Service.Instance.IsProjectLoaded)
            {
                return;
            }

            // Regex pattern to match folder names like "_mXXX" where XXX is a number
            Regex regex = new Regex(@"^_m(\d+)$");

            // Get all subdirectories and extract numbers
            List<int> indices = Directory.GetDirectories(Project_Service.Instance.Path_Mon)
                .Select(Path.GetFileName) // Get folder names only
                .Where(name => name != null && regex.IsMatch(name)) // Match the pattern
                .Select(name => int.Parse(regex.Match(name).Groups[1].Value)) // Extract and parse the number
                .ToList();

            LoadedMonsters.Clear();
            foreach (int i in indices)
            {
                LoadedMonsters.Add(new MonsterListEntry(i));
            }
        }

        public void ApplyFilter()
        {
            DisplayedMonsters.Clear();
            foreach(MonsterListEntry monster in LoadedMonsters)
            {
                if (FilterText == "" || monster.Name.ToLower().Contains(FilterText.ToLower()))
                {
                    DisplayedMonsters.Add(monster);
                }
            }
        }

        public void LoadMonster(MonsterListEntry monsterEntry, ContentControl contentFrame)
        {
            string monsterPath = Project_Service.Instance.GetPathMon(monsterEntry.Index);

            byte[] byteFile = File.ReadAllBytes(monsterPath);

            //contentFrame.Content = new Mon_Control(Monster_File.Read(byteFile), monsterPath);
            contentFrame.Content = new MonEditor_Control(Monster_File.Read(byteFile), monsterPath, this);
        }

        public class MonsterListEntry
        {
            public int Index { get; set; }
            public string Name { get; set; } // TODO

            public MonsterListEntry(int index)
            {
                Index = index;
                Name = Monster_Dictionary.Instance.ContainsKey((short)Index) ? "[" + Index + "] " + Monster_Dictionary.Instance[(short)Index] : "[" + Index + "] " + "<NOT INDEXED>";
            }
        }
    }
}
