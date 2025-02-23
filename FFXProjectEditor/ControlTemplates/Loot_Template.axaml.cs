using Avalonia;
using Avalonia.Controls.Primitives;
using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.Modules;
using System.Collections.Generic;

namespace FFXProjectEditor;

public class Loot_Template : TemplatedControl
{
    // REQUIRED to be passed as if it's tried to be loaded in the template the initial value won't show up :(
    public static readonly StyledProperty<List<string>> CategOptionsProperty = AvaloniaProperty.Register<TemplatedControl, List<string>>(nameof(CategOptions), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public List<string> CategOptions
    {
        get => GetValue(CategOptionsProperty);
        set => SetValue(CategOptionsProperty, value);
    }

    // Values
    public static readonly StyledProperty<string> Loot_LabelProperty = AvaloniaProperty.Register<TemplatedControl, string>(nameof(Loot_Label), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public string Loot_Label
    {
        get => GetValue(Loot_LabelProperty);
        set => SetValue(Loot_LabelProperty, value);
    }
    //public bool IsLabelVisible
    //{
    //    get
    //    {
    //        bool isit = Loot_Label != null && Loot_Label != "";
    //        return isit;
    //    }
    //}
    public static readonly StyledProperty<bool> Loot_IsLabelVisibleProperty = AvaloniaProperty.Register<TemplatedControl, bool>(nameof(Loot_IsLabelVisible), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay, defaultValue: true);
    public bool Loot_IsLabelVisible
    {
        get => GetValue(Loot_IsLabelVisibleProperty);
        set => SetValue(Loot_IsLabelVisibleProperty, value);
    }
    public static readonly StyledProperty<GameIndex_Wrapper> Loot_ObjectProperty = AvaloniaProperty.Register<TemplatedControl, GameIndex_Wrapper>(nameof(Loot_Object), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public GameIndex_Wrapper Loot_Object
    {
        get => GetValue(Loot_ObjectProperty);
        set => SetValue(Loot_ObjectProperty, value);
    }
    //public static readonly StyledProperty<GameCategory_Enum> Loot_CategoryProperty = AvaloniaProperty.Register<TemplatedControl, GameCategory_Enum>(nameof(Loot_Category), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    //public GameCategory_Enum Loot_Category
    //{
    //    get => GetValue(Loot_CategoryProperty);
    //    set => SetValue(Loot_CategoryProperty, value);
    //}
    //public static readonly StyledProperty<ushort> Loot_IndexProperty = AvaloniaProperty.Register<TemplatedControl, ushort>(nameof(Loot_Index), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    //public ushort Loot_Index
    //{
    //    get => GetValue(Loot_IndexProperty);
    //    set => SetValue(Loot_IndexProperty, value);
    //}
    //public static readonly StyledProperty<string> Loot_NameProperty = AvaloniaProperty.Register<TemplatedControl, string>(nameof(Loot_Name), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    //public string Loot_Name
    //{
    //    get => GetValue(Loot_NameProperty);
    //    set => SetValue(Loot_NameProperty, value);
    //}
    public static readonly StyledProperty<ushort> Loot_CountProperty = AvaloniaProperty.Register<TemplatedControl, ushort>(nameof(Loot_Count), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public ushort Loot_Count
    {
        get => GetValue(Loot_CountProperty);
        set => SetValue(Loot_CountProperty, value);
    }

    // Syling
    public static readonly StyledProperty<int> BorderWidthProperty = AvaloniaProperty.Register<TemplatedControl, int>(nameof(BorderWidth), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public int BorderWidth
    {
        get => GetValue(BorderWidthProperty);
        set => SetValue(BorderWidthProperty, value);
    }
    public static readonly StyledProperty<int> ValueBorderWidthProperty = AvaloniaProperty.Register<TemplatedControl, int>(nameof(ValueBorderWidth), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay, defaultValue: 100);
    public int ValueBorderWidth
    {
        get => GetValue(ValueBorderWidthProperty);
        set => SetValue(ValueBorderWidthProperty, value);
    }
}