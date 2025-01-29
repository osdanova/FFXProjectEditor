using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.Services;

namespace FFXProjectEditor.Modules.DebugMenu
{
    internal partial class DebugMenu_DataModel : ObservableObject
    {
        [ObservableProperty] public bool isControlEnabled;
        public Process_Service ProcService { get => Process_Service.Instance; }

        public DebugMenu_DataModel()
        {
            CheckValues();
        }

        private void CheckValues()
        {
            bool tess = MemSharp_Service.Instance.Read<byte>(MemoryMap_Util.ADDR_ENEMY_CONTROL) == 1 ? true : false;
            IsControlEnabled = tess;
        }

        public void EnableControl(bool doEnable)
        {
            if (doEnable)
            {
                MemSharp_Service.Instance.Write<byte>(MemoryMap_Util.ADDR_ENEMY_CONTROL, 1);
            }
            else
            {
                MemSharp_Service.Instance.Write<byte>(MemoryMap_Util.ADDR_ENEMY_CONTROL, 0);
            }
            CheckValues();
        }
    }
}
