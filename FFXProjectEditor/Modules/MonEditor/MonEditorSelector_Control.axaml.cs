using Avalonia.Controls;
using FFXProjectEditor.Modules.MonEditor;
using static FFXProjectEditor.Modules.MonEditor.MonEditorSelector_DataModel;

namespace FFXProjectEditor;

public partial class MonEditorSelector_Control : UserControl
{
    MonEditorSelector_DataModel DataModel;
    public MonEditorSelector_Control()
    {
        DataModel = new MonEditorSelector_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
    }

    private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        DataModel.LoadMonster((MonsterListEntry)MonsterList.SelectedItem, ContentFrame);
    }

    private void Filter_Changed(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        DataModel.ApplyFilter();
    }
}