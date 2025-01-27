using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.FfxLib.Dictionaries;

namespace FFXProjectEditor.Modules
{
    public partial class GameIndex_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Name))] public GameCategory_Enum category;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Name))] public ushort index;

        string Name => FfxCommon_Util.GetCommandName(category, index);

        public static GameIndex_Wrapper Wrap(ushort gameIndex)
        {
            GameIndex_Wrapper wrapper = new();
            wrapper.Category = FfxCommon_Util.GetCommandCategory(gameIndex);
            wrapper.Index = FfxCommon_Util.GetCommandIndex(gameIndex);
            return wrapper;
        }
        public ushort Unwrap()
        {
            ushort gameIndex = new();
            gameIndex = FfxCommon_Util.SetCommandCategory(gameIndex, category);
            gameIndex = FfxCommon_Util.SetCommandIndex(gameIndex, index);
            return gameIndex;
        }
    }
}
