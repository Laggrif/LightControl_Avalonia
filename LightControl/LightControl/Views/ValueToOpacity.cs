using System;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace LightControl.Views;

public class ValueToOpacity: IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (value is not double sliderValue) return new SolidColorBrush(new Color(255, 0, 0, 0));
        byte R = (byte) (sliderValue);
        byte G = (byte) (sliderValue);
        byte B = (byte) (sliderValue);

        switch (parameter)
        {
            case "r":
                G = 0;
                B = 0;
                break;
            case "g":
                R = 0;
                B = 0;
                break;
            case "b":
                R = 0;
                G = 0;
                break;
            default:
                R = 0;
                G = 0;
                B = 0;
                break;
        }

        return new SolidColorBrush(new Color(255, R, G, B));

    }

    public object ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}