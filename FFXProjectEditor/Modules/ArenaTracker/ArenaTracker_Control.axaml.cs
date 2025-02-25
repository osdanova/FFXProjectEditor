using Avalonia;
using Avalonia.Controls;
using FFXProjectEditor.Modules.ArenaTracker;

namespace FFXProjectEditor;

public partial class ArenaTracker_Control : UserControl
{
    ArenaTracker_DataModel DataModel { get; set; }
    public ArenaTracker_Control()
    {
        InitializeComponent();
        DataModel = new ArenaTracker_DataModel();
        DataContext = DataModel;
    }

    // Unused because it breaks the app. ObservableCollection issue?
    private void Button_Refresh(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.LoadArenaData();
    }
    private void Button_LoadIngame(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.WriteArenaData();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        DataModel.StartReading(); // Start the timer when UserControl is loaded
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);
        DataModel.StopReading(); // Stop the timer when UserControl is unloaded
    }
}