using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.Converters;
using FFXProjectEditor.FfxLib.Ability;
using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace FFXProjectEditor.Modules.BattleKernel.Commands
{
    internal partial class KernelCommands_DataModel : ObservableObject
    {
        public Process_Service ProcService { get => Process_Service.Instance; }
        /******************************************
         * Data
         ******************************************/
        CommandFile_enum CommandFileType { get; set; }
        List<Ability_Command> CommandsList { get; set; }
        List<KernelCommands_Wrapper> LoadedCommands { get; set; }
        ObservableCollection<KernelCommands_Wrapper> DisplayedCommands { get; set; }

        /******************************************
         * View settings
         ******************************************/
        [ObservableProperty] public bool showDescription = true;
        [ObservableProperty] public bool showAnimations = false;
        [ObservableProperty] public bool showMenu = false;
        [ObservableProperty] public bool showCharacters = false;
        [ObservableProperty] public bool showProperties = true;
        [ObservableProperty] public bool showCosts = false;
        [ObservableProperty] public bool showAttackData = false;
        [ObservableProperty] public bool showElement = false;
        [ObservableProperty] public bool showStatus = false;
        [ObservableProperty] public bool showBuffs = false;
        [ObservableProperty] public bool showExtra = false;

        public List<string> CharacterOptions => new Character_Converter().Options.Values.ToList();
        public List<string> HitCalcTypeOptions => new HitCalcType_Converter().Options.Values.ToList();

        bool IsExtraEnabled => HasExtraInfo();
        string FilterText { get; set; } = "";

        public KernelCommands_DataModel(CommandFile_enum commandFileType)
        {
            CommandFileType = commandFileType;

            LoadedCommands = new();
            DisplayedCommands = new();
            LoadCommands();
            ApplyFilter();
        }

        public void LoadCommands()
        {
            byte[] byteFile = File.ReadAllBytes(GetFilePath());
            CommandsList = Ability_Command.ReadList(byteFile, HasExtraInfo());

            for (int i = 0; i < CommandsList.Count; i++)
            {
                KernelCommands_Wrapper wrapper = KernelCommands_Wrapper.Wrap(CommandsList[i]);
                wrapper.Index = i;
                LoadedCommands.Add(wrapper);
            }
        }

        public void ApplyFilter()
        {
            DisplayedCommands.Clear();
            foreach (KernelCommands_Wrapper command in LoadedCommands)
            {
                if (FilterText == "" ||
                    command.Index.ToString().Contains(FilterText.ToLower()) ||
                    command.Name.ToLower().Contains(FilterText.ToLower()) ||
                    command.Description.ToLower().Contains(FilterText.ToLower()))
                {
                    DisplayedCommands.Add(command);
                }
            }
        }

        public void Save()
        {
            List<Ability_Command> commandList = new();
            for (int i = 0; i < LoadedCommands.Count; i++)
            {
                Ability_Command command = LoadedCommands[i].Unwrap();
                commandList.Add(command);
            }

            File.WriteAllBytes(GetFilePath(), BuildFile());
        }
        public void LoadInGame()
        {
            int fileAddress;
            if (CommandFileType == CommandFile_enum.Item)
            {
                fileAddress = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_FILE_ITEM);
            }
            else if (CommandFileType == CommandFile_enum.Command)
            {
                fileAddress = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_FILE_COMMAND);
            }
            else if (CommandFileType == CommandFile_enum.MonMagic1)
            {
                fileAddress = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_FILE_MONMAGIC1);
            }
            else if (CommandFileType == CommandFile_enum.MonMagic2)
            {
                fileAddress = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_FILE_MONMAGIC2);
            }
            else return;

            MemSharp_Service.Instance.Write(fileAddress, BuildFile(), false);
        }

        private byte[] BuildFile()
        {
            List<Ability_Command> commandList = new();
            for (int i = 0; i < LoadedCommands.Count; i++)
            {
                Ability_Command command = LoadedCommands[i].Unwrap();
                commandList.Add(command);
            }

            bool hasExtraInfo = HasExtraInfo();

            return Ability_Command.WriteList(commandList, hasExtraInfo);
        }

        public string GetFilePath()
        {
            if(CommandFileType == CommandFile_enum.Command)
            {
                return Project_Service.Instance.Path_KernelCommandUs;
            }
            if (CommandFileType == CommandFile_enum.Item)
            {
                return Project_Service.Instance.Path_KernelItemUs;
            }
            if (CommandFileType == CommandFile_enum.MonMagic1)
            {
                return Project_Service.Instance.Path_KernelMonMagic1Us;
            }
            if (CommandFileType == CommandFile_enum.MonMagic2)
            {
                return Project_Service.Instance.Path_KernelMonMagic2Us;
            }

            throw new System.Exception("[KernelCommands_DataModel] File type not selected");
        }

        public bool HasExtraInfo()
        {
            if (CommandFileType == CommandFile_enum.Command || CommandFileType == CommandFile_enum.Item)
            {
                return true;
            }
            if (CommandFileType == CommandFile_enum.MonMagic1 || CommandFileType == CommandFile_enum.MonMagic2)
            {
                return false;
            }

            throw new System.Exception("[KernelCommands_DataModel] File type not selected");
        }
    }
}
