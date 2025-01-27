using Avalonia.Controls;
using FFXProjectEditor.Modules.DebugMenu;

namespace FFXProjectEditor;

public partial class DebugMenu_Control : UserControl
{
    DebugMenu_DataModel DataModel;
    public DebugMenu_Control()
    {
        DataModel = new DebugMenu_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Toggle_ControlOn(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.EnableControl(true);
    }

    private void Toggle_ControlOff(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.EnableControl(false);
    }
}