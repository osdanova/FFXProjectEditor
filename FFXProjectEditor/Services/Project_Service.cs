using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.Utils;
using System.Diagnostics;
using System.IO;

namespace FFXProjectEditor.Services
{
    public partial class Project_Service : SingletonBase<Project_Service>
    {
        /******************************************
         * STATE
         ******************************************/
        // master folder
        [ObservableProperty][NotifyPropertyChangedFor(nameof(IsProjectLoaded))] public string? projectPath; // This should be private set but can't do it with ObservableProperty
        public bool IsProjectLoaded => ProjectPath != null && ProjectPath != "" && Directory.Exists(ProjectPath);

        /******************************************
         * Public functions
         ******************************************/

        public static bool IsPathValid(string projectPath)
        {
            if (File.Exists(projectPath))
            {
                Debug.WriteLine("This is a file");
                return false;
            }
            if (!Directory.Exists(projectPath))
            {
                Debug.WriteLine("Directory doesn't exist");
                return false;
            }
            if(!projectPath.EndsWith("master"))
            {
                Debug.WriteLine("Directory is not the master folder");
                return false;
            }
            return true;
        }

        public void LoadProject(string projectPath)
        {
            if (!Directory.Exists(projectPath))
                throw new System.Exception("[Project_Service] Provided folder doesn't exist");

            if (!projectPath.EndsWith("master") && !projectPath.EndsWith("master/"))
                throw new System.Exception("[Project_Service] Provided folder is not master folder");

            ProjectPath = projectPath;
        }

        /******************************************
         * Files
         ******************************************/
        public string Path_Btl => Path.Combine(ProjectPath, "jppc", "battle", "btl");
        public string Path_Kernel => Path.Combine(ProjectPath, "jppc", "battle", "kernel");
        public string Path_KernelUs => Path.Combine(ProjectPath, "new_uspc", "battle", "kernel");
        public string Path_KernelArmsRate => Path.Combine(Path_Kernel, "arms_rate.bin");
        public string Path_KernelCommand => Path.Combine(Path_Kernel, "command.bin");
        public string Path_KernelCommandUs => Path.Combine(Path_KernelUs, "command.bin");
        public string Path_KernelItemUs => Path.Combine(Path_KernelUs, "item.bin");
        public string Path_KernelMonMagic1Us => Path.Combine(Path_KernelUs, "monmagic1.bin");
        public string Path_KernelMonMagic2Us => Path.Combine(Path_KernelUs, "monmagic2.bin");
        public string Path_Mon => Path.Combine(ProjectPath, "jppc", "battle", "mon");

        public string GetPathMon(int monsterId)
        {
            CheckProject();

            if (monsterId < 0 || monsterId > 999)
                throw new System.Exception("[Project_Service] Invalid monster id");

            string folder = "_m" + monsterId.ToString("D3");
            string file = "m" + monsterId.ToString("D3") + ".bin";
            return Path.Combine(Path_Mon, folder, file);
        }

        private void CheckProject()
        {
            if (!IsProjectLoaded)
                throw new System.Exception("[Project_Service] Project is not loaded!");
        }
    }
}
