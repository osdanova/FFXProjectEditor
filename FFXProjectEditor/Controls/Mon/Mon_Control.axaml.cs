using Avalonia.Controls;
using FFXProjectEditor.Controls.Mon;
using FFXProjectEditor.FfxLib.Monster;

namespace FFXProjectEditor;

public partial class Mon_Control : UserControl
{
    Mon_DataModel dataModel;
    public Mon_Control(Monster_File file, string filepath)
    {
        dataModel = new Mon_DataModel(file, filepath);
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private void Button_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        dataModel.Save();
    }
}