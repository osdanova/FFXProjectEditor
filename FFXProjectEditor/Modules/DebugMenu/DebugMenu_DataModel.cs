using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.Services;

namespace FFXProjectEditor.Modules.DebugMenu
{
    internal partial class DebugMenu_DataModel : ObservableObject
    {
        private const int ADDR_ENEMY_CONTROL = 0xD2A8FA;

        [ObservableProperty] public bool isControlEnabled;
        public Process_Service ProcService { get => Process_Service.Instance; }

        public DebugMenu_DataModel()
        {
            CheckValues();
        }

        private void CheckValues()
        {
            bool tess = MemSharp_Service.Instance.Read<byte>(ADDR_ENEMY_CONTROL) == 1 ? true : false;
            IsControlEnabled = tess;
        }

        public void EnableControl(bool doEnable)
        {
            if (doEnable)
            {
                MemSharp_Service.Instance.Write<byte>(ADDR_ENEMY_CONTROL, 1);
            }
            else
            {
                MemSharp_Service.Instance.Write<byte>(ADDR_ENEMY_CONTROL, 0);
            }
            CheckValues();
        }
    }
}
