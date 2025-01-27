using Avalonia;
using Avalonia.Controls.Primitives;

namespace FFXProjectEditor;

public class MonEditorDrop_Template : TemplatedControl
{
    public static readonly StyledProperty<string> FieldLabelProperty = AvaloniaProperty.Register<TemplatedControl, string>(nameof(FieldLabel), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public string FieldLabel
    {
        get => GetValue(FieldLabelProperty);
        set => SetValue(FieldLabelProperty, value);
    }
    public static readonly StyledProperty<string> FieldIdProperty = AvaloniaProperty.Register<TemplatedControl, string>(nameof(FieldId), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public string FieldId
    {
        get => GetValue(FieldIdProperty);
        set => SetValue(FieldIdProperty, value);
    }
    public static readonly StyledProperty<string> FieldNameProperty = AvaloniaProperty.Register<TemplatedControl, string>(nameof(FieldName), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public string FieldName
    {
        get => GetValue(FieldNameProperty);
        set => SetValue(FieldNameProperty, value);
    }
    public static readonly StyledProperty<string> FieldCountProperty = AvaloniaProperty.Register<TemplatedControl, string>(nameof(FieldCount), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public string FieldCount
    {
        get => GetValue(FieldCountProperty);
        set => SetValue(FieldCountProperty, value);
    }
    public static readonly StyledProperty<string> FieldChanceProperty = AvaloniaProperty.Register<TemplatedControl, string>(nameof(FieldChance), defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    public string FieldChance
    {
        get => GetValue(FieldChanceProperty);
        set => SetValue(FieldChanceProperty, value);
    }
}