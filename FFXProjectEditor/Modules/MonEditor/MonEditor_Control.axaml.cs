using Avalonia.Controls;
using FFXProjectEditor.FfxLib.Monster;
using FFXProjectEditor.Modules.MonEditor;

namespace FFXProjectEditor;

public partial class MonEditor_Control : UserControl
{
    MonEditor_DataModel DataModel;
    public MonEditor_Control(Monster_File monFile, string monsterPath, MonEditorSelector_DataModel selectorDM)
    {
        DataModel = new MonEditor_DataModel(monFile, monsterPath, selectorDM);
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.Save();
    }
}