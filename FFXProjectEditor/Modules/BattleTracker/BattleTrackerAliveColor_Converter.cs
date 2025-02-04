using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace FFXProjectEditor.Modules.BattleTracker
{
    public class BattleTrackerAliveColor_Converter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? Brushes.White : Brushes.DarkRed;
            }
            if (value is int intValue)
            {
                return intValue == 1 ? Brushes.White : Brushes.DarkRed;
            }
            return Brushes.White; // Default color
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
