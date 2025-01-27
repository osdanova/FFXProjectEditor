using Avalonia.Controls;
using FFXProjectEditor.Controls.MonX;
using FFXProjectEditor.Files;

namespace FFXProjectEditor;

public partial class MonX_Control : UserControl
{
    MonX_DataModel dataModel;
    public MonX_Control(MonX_File file)
    {
        dataModel = new MonX_DataModel(file);
        this.DataContext = dataModel;
        InitializeComponent();
    }
}