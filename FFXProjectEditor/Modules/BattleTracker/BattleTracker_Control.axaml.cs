using Avalonia;
using Avalonia.Controls;
using FFXProjectEditor.Modules.BattleTracker;

namespace FFXProjectEditor;

public partial class BattleTracker_Control : UserControl
{
    BattleTracker_DataModel DataModel;
    public BattleTracker_Control()
    {
        InitializeComponent();
        DataModel = new BattleTracker_DataModel(FrameAlly, FrameEnemy);
        this.DataContext = DataModel;
    }

    private void Button_Read(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.ReadInfo();
    }

    private void ListBox_SelectionChangedAlly(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        DataModel.LoadAlly((BattleTrackerChr_Wrapper)ListBox_Ally.SelectedItem);
        //FrameAlly.Content = new BattleTrackerChr_Control((BattleTrackerChr_Wrapper)ListBox_Ally.SelectedItem);
    }
    private void ListBox_SelectionChangedEnemy(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        DataModel.LoadEnemy((BattleTrackerChr_Wrapper)ListBox_Enemy.SelectedItem);
        //FrameEnemy.Content = new BattleTrackerChr_Control((BattleTrackerChr_Wrapper)ListBox_Enemy.SelectedItem);
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

    private void Button_LoadIngame(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.LoadIngame();
    }
}