using Avalonia.Controls;
using FFXProjectEditor.Modules.BattleTracker;

namespace FFXProjectEditor;

public partial class BattleTrackerChr_Control : UserControl
{
    BattleTrackerChr_Wrapper DataModel { get; set; }
    public BattleTrackerChr_Control(BattleTrackerChr_Wrapper wrapper)
    {
        InitializeComponent();
        DataModel = wrapper;
        DataContext = DataModel;
    }
}