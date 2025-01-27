using FFXProjectEditor.FfxLib.Ability;
using FFXProjectEditor.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace FFXProjectEditor.Modules.BattleKernel.Commands
{
    internal class KernelCommands_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        CommandFile_enum CommandFileType { get; set; }
        List<Ability_Command> CommandsList { get; set; }
        List<KernelCommands_Wrapper> LoadedCommands { get; set; }
        ObservableCollection<KernelCommands_Wrapper> DisplayedCommands { get; set; }

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

            File.WriteAllBytes(Project_Service.Instance.Path_KernelCommandUs, Ability_Command.WriteList(commandList, HasExtraInfo()));
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
