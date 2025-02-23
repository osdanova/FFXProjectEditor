using Avalonia;
using Avalonia.Controls.Primitives;

namespace FFXProjectEditor;

public class PropertyBool_Template : TemplatedControl
{
    public static readonly StyledProperty<string> Property_LabelProperty = AvaloniaProperty.Register<TemplatedControl, string>(nameof(Property_Label), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public string Property_Label
    {
        get => GetValue(Property_LabelProperty);
        set => SetValue(Property_LabelProperty, value);
    }
    public static readonly StyledProperty<bool> Property_ValueProperty = AvaloniaProperty.Register<TemplatedControl, bool>(nameof(Property_Value), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public bool Property_Value
    {
        get => GetValue(Property_ValueProperty);
        set => SetValue(Property_ValueProperty, value);
    }
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