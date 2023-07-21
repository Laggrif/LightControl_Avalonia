using System;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace LightControl.Converters;

public class DarkenClick: IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (value is SolidColorBrush color)
        {
            var Color = color.Color;
            byte R = (byte) Double.Min(Color.R - 50, 0);
            byte G = (byte) Double.Min(Color.G - 50, 0);
            byte B = (byte) Double.Min(Color.B - 50, 0);
            return color;
            return new SolidColorBrush(new Color(Color.A, R, G, B));
        }

        return value;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}