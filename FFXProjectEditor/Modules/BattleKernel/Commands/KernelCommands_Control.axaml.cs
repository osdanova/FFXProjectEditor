using Avalonia.Controls;
using FFXProjectEditor.Modules.BattleKernel.Commands;

namespace FFXProjectEditor;

public partial class KernelCommands_Control : UserControl
{
    KernelCommands_DataModel DataModel;
    public KernelCommands_Control(CommandFile_enum commandFileType)
    {
        DataModel = new KernelCommands_DataModel(commandFileType);
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.Save();
    }
    private void Button_LoadIngame(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.LoadInGame();
    }

    private void Filter_Changed(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        DataModel.ApplyFilter();
    }
}