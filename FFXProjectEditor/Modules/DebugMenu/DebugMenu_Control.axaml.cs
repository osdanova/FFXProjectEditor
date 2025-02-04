using Avalonia.Controls;
using FFXProjectEditor.Modules.DebugMenu;

namespace FFXProjectEditor;

public partial class DebugMenu_Control : UserControl
{
    DebugMenu_DataModel DataModel;
    public int SwitchSize { get; set; } = 500;
    public DebugMenu_Control()
    {
        DataModel = new DebugMenu_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Toggle_ControlOn(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //DataModel.EnableControl(true);
        DataModel.WriteBtlDebug();
    }

    private void Toggle_ControlOff(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //DataModel.EnableControl(false);
        DataModel.WriteBtlDebug();
    }

    private void ToggleSwitch_Write(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.WriteBtlDebug();
    }

    private void Button_Apply(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.WriteBtlDebug();
    }
}