using System;
using System.Globalization;
using System.Windows.Data;

namespace ArMarkerViewer.ValueConverters
{
    public class PokemonIdToNameConverter : IValueConverter
    {
        private static readonly string[] NameLookup = Resource1.Names.Split(Environment.NewLine);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return NameLookup[(ushort)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) // unnecessary
        {
            return null;
        }
    }
}
