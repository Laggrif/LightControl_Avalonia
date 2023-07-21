using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace LightControl.Views;

public class ValuesToRGB: IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values?.Count == 5 && values.All(v => v is double))
        {
            var red = (double)values[0];
            var green = (double)values[1];
            var blue = (double)values[2];
            var W = (double)values[3];
            var alpha = (double)values[4];

            var A = (byte)alpha;
            var R = (byte)Double.Min(255, red + W);
            var G = (byte)Double.Min(255, green + W);
            var B = (byte)Double.Min(255, blue + W);

            var brush = new LinearGradientBrush
            {
                EndPoint = new RelativePoint(255 / alpha, 0, RelativeUnit.Relative)
            };
            brush.GradientStops.Add(new GradientStop(Colors.Black, 0.0));
            brush.GradientStops.Add(new GradientStop(new Color(A, R, G, B), 1.0));

            return brush;
        }

        return AvaloniaProperty.UnsetValue;
    }
}