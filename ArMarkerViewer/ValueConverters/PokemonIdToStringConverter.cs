using System;
using System.Globalization;
using System.Windows.Data;

namespace ArMarkerViewer.ValueConverters
{
    public class PokemonIdToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ushort)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ushort.TryParse((string)value, out ushort i) ? i : ushort.MinValue;
        }
    }
}
