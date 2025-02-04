using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Services;
using System.IO;
using Xe.BinaryMapper;

namespace FFXProjectEditor.Modules.DebugMenu
{
    internal partial class DebugMenu_DataModel : ObservableObject
    {
        public Process_Service ProcService { get => Process_Service.Instance; }
        public MemoryBtl.BtlDebug LoadedBtlDebug { get; set; }

        public DebugMenu_DataModel()
        {
            LoadBtlDebug();
        }

        public void LoadBtlDebug()
        {
            byte[] btlDebugBytes = ReadBtlDebug();
            using (MemoryStream stream = new MemoryStream(btlDebugBytes))
                LoadedBtlDebug = BinaryMapping.ReadObject<MemoryBtl.BtlDebug>(stream);
        }

        public byte[] ReadBtlDebug()
        {
            return MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_BTL_DEBUG_SETTINGS, 0x28);
        }

        public void WriteBtlDebug()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryMapping.WriteObject(stream, LoadedBtlDebug);
                MemSharp_Service.Instance.Write(MemoryMap.ADDR_BTL_DEBUG_SETTINGS, stream.ToArray());
            }
        }
    }
}
