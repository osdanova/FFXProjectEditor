using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.Services;

namespace FFXProjectEditor.Modules.Main
{
    internal partial class Main_DataModel : ObservableObject
    {
        [ObservableProperty] public string projectPath = "Select project folder (master)";
        [ObservableProperty] public string gameHookInfo = "Game not hooked";

        public Process_Service ProcService { get => Process_Service.Instance; }
        public Project_Service ProjService { get => Project_Service.Instance; }

        public void LoadProjectFolder(string selectedFolder)
        {
            ProjectPath = selectedFolder;
            Project_Service.Instance.LoadProject(selectedFolder);
        }
    }
}
