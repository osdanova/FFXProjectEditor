using Avalonia.Controls;
using FFXProjectEditor.Modules.InventoryTracker;
using System.Collections.Generic;
using System.Linq;

namespace FFXProjectEditor;

public partial class InventoryTracker_Control : UserControl
{
    InventoryTracker_DataModel DataModel { get; set; }
    public InventoryTracker_Control()
    {
        InitializeComponent();
        DataModel = new InventoryTracker_DataModel();
        DataContext = DataModel;
    }

    // Unused because it breaks the app. ObservableCollection issue?
    private void Button_Refresh(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.LoadData();
    }
    private void Button_SellSelected(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        List<Equipment_Wrapper> selectedEquipment = EquipmentGrid.SelectedItems.Cast<Equipment_Wrapper>().ToList();
        DataModel.SellSelected(selectedEquipment);
    }
    private void Button_LoadIngame(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataModel.WriteSaveData();
        DataModel.WriteEquipment();
        DataModel.WriteKeyItems();
    }
}