using Avalonia;
using Avalonia.Controls.Primitives;
using FFXProjectEditor.Modules;
using System.Collections.Generic;

namespace FFXProjectEditor;

public class GameIndex_Template : TemplatedControl
{
    // REQUIRED to be passed as if it's tried to be loaded in the template the initial value won't show up :(
    public static readonly StyledProperty<List<string>> CategOptionsProperty = AvaloniaProperty.Register<TemplatedControl, List<string>>(nameof(CategOptions), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public List<string> CategOptions
    {
        get => GetValue(CategOptionsProperty);
        set => SetValue(CategOptionsProperty, value);
    }

    // Values
    public static readonly StyledProperty<string> GameIndex_LabelProperty = AvaloniaProperty.Register<TemplatedControl, string>(nameof(GameIndex_Label), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public string GameIndex_Label
    {
        get => GetValue(GameIndex_LabelProperty);
        set => SetValue(GameIndex_LabelProperty, value);
    }
    public static readonly StyledProperty<GameIndex_Wrapper> GameIndex_ObjectProperty = AvaloniaProperty.Register<TemplatedControl, GameIndex_Wrapper>(nameof(GameIndex_Object), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public GameIndex_Wrapper GameIndex_Object
    {
        get => GetValue(GameIndex_ObjectProperty);
        set => SetValue(GameIndex_ObjectProperty, value);
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
    public static readonly StyledProperty<bool> IsLabelVisibleProperty = AvaloniaProperty.Register<TemplatedControl, bool>(nameof(IsLabelVisible), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay, defaultValue: true);
    public bool IsLabelVisible
    {
        get => GetValue(IsLabelVisibleProperty);
        set => SetValue(IsLabelVisibleProperty, value);
    }
    public static readonly StyledProperty<int> BorderThicknessProperty = AvaloniaProperty.Register<TemplatedControl, int>(nameof(BorderThickness), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay, defaultValue: 1);
    public int BorderThickness
    {
        get => GetValue(BorderThicknessProperty);
        set => SetValue(BorderThicknessProperty, value);
    }
}