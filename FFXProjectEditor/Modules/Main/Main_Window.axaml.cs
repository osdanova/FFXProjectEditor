using Avalonia.Controls;
using Avalonia.Input;
using FFXProjectEditor.Modules.BattleKernel.Commands;
using FFXProjectEditor.Modules.Main;
using FFXProjectEditor.Services;
using FFXProjectEditor.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FFXProjectEditor;

public partial class Main_Window : Window
{
    Main_DataModel DataModel;
    public Main_Window()
    {
        DataModel = new Main_DataModel();
        this.DataContext = DataModel;
        InitializeComponent();
        AddHandler(DragDrop.DropEvent, Drop_ProjectFolder);
    }

    public void Drop_ProjectFolder(object sender, DragEventArgs e)
    {
        List<string> files = e.Data.GetFileNames().ToList();

        if (files.Count == 0)
        {
            Debug.WriteLine("No files found on drop");
            return;
        }

        string filePath = Uri.UnescapeDataString(files[0]);

        if (!Project_Service.IsPathValid(filePath))
            return;

        DataModel.LoadProjectFolder(filePath);
    }

    private async void Button_ProjectPath(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        List<string> openDialogResults = await AvaloniaDialog_Util.OpenFolderDialog(this, "Select the project folder");
        if (openDialogResults.Count == 0 || !Directory.Exists(openDialogResults[0]))
        {
            return;
        }
        DataModel.LoadProjectFolder(openDialogResults[0]);
    }

    private void MenuItem_MonsterEditor(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!Project_Service.Instance.IsProjectLoaded)
            return;

        ContentFrame.Content = new MonEditorSelector_Control();
    }
    private void MenuItem_Commands(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!Project_Service.Instance.IsProjectLoaded)
            return;

        ContentFrame.Content = new KernelCommands_Control(CommandFile_enum.Command);
    }
    private void MenuItem_Items(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!Project_Service.Instance.IsProjectLoaded)
            return;

        ContentFrame.Content = new KernelCommands_Control(CommandFile_enum.Item);
    }
    private void MenuItem_MonsterMagic1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!Project_Service.Instance.IsProjectLoaded)
            return;

        ContentFrame.Content = new KernelCommands_Control(CommandFile_enum.MonMagic1);
    }
    private void MenuItem_MonsterMagic2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!Project_Service.Instance.IsProjectLoaded)
            return;

        ContentFrame.Content = new KernelCommands_Control(CommandFile_enum.MonMagic2);
    }
    private void MenuItem_DebugMenu(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ContentFrame.Content = new DebugMenu_Control();
    }
    private void MenuItem_BattleTracker(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ContentFrame.Content = new BattleTracker_Control();
    }
    private void MenuItem_Test(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ContentFrame.Content = new Test_Control();
    }
}