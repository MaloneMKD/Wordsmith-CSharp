using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordsmith.Converters
{
    public class StringToTextAlignmentConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string alignment = (string)value;
                switch (alignment)
                {
                    case "left": return TextAlignment.Start;
                    case "center": return TextAlignment.Center;
                    case "right": return TextAlignment.End;
                }
            }
            return TextAlignment.Start;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null)
            {
                TextAlignment alignment = (TextAlignment)value;
                switch (alignment)
                {
                    case TextAlignment.Start: return "left";
                    case TextAlignment.Center: return "center";
                    case TextAlignment.End: return "right";
                }
            }
            return "left";
        }
    }
}
