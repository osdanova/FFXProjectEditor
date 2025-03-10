using Avalonia;
using Avalonia.Controls;
using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Modules.Test;
using FFXProjectEditor.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace FFXProjectEditor;

public partial class Test_Control : UserControl
{
    Test_DataModel DataModel { get; set; }
    public Test_Control()
    {
        InitializeComponent();
        DataModel = new Test_DataModel();
        DataContext = DataModel;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //ReadMemory();
        //PrintValues(MyValues);
        //DoTest();
        Debug.WriteLine("DEBUG PRESSED");
    }

    private void ReadMemory()
    {
        int monsterListAddress = MemSharp_Service.Instance.Read<int>(MemoryMap.POINTER_BATTLE_ENEMY_LIST);

        int monsterCount = 20;

        List<int> monsterAddresses = new();
        for (int i = 0; i < monsterCount; i++)
        {
            monsterAddresses.Add(monsterListAddress + i * MemoryMap.SIZE_BATTLE_CHR_ENTRY);
        }

        for (int i = 0; i < monsterCount; i++)
        {
            int monAdd = monsterAddresses[i];
            short monId = MemSharp_Service.Instance.Read<short>(monAdd + 14, false);
            if (monId > 0)
                monId -= 0x1000;
            float pos1 = MemSharp_Service.Instance.Read<float>(monAdd + 928, false);
            float pos2 = MemSharp_Service.Instance.Read<float>(monAdd + 932, false);
            float pos3 = MemSharp_Service.Instance.Read<float>(monAdd + 936, false);
            float pos4 = MemSharp_Service.Instance.Read<float>(monAdd + 940, false);

            string monName = (Monster_Dictionary.Instance.ContainsKey(monId)) ? Monster_Dictionary.Instance[monId] : "-";

            Debug.WriteLine("Monster [" + i + "]: Id [" + monId + "] Name [" + monName + "] - P1 [" + pos1 + "] - P2 [" + pos2 + "] - P3 [" + pos3 + "] - P4 [" + pos4 + "]");
        }

        //byte[] monsterBytes = MemSharp_Service.Instance.Read<byte>(monsterListAddress, MemoryMap.SIZE_BATTLE_ENEMY_ENTRY, false);
        //using (MemoryStream stream = new MemoryStream(monsterBytes))
        //{
        //    MemoryChr monsterChr = BinaryMapping.ReadObject<MemoryChr>(stream);
        //}
    }

    private void DoTest()
    {
        string[] directories = Directory.GetDirectories(Project_Service.Instance.Path_Btl);

        List<int> fileCounts = new List<int>();
        foreach(string dir in directories)
        {
            fileCounts.Add(Directory.GetFiles(dir).Length);
        }
    }

    private void PrintValues(List<int> values)
    {
        foreach(int i in values)
        {
            Debug.WriteLine("0x" + (i+4).ToString("X3"));
        }
    }

    private List<int> MyValues = new List<int>
    {
        0x0,
    };

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