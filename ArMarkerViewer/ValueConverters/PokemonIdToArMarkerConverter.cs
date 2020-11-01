using ArMarkerViewer.Core;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ArMarkerViewer.ValueConverters
{
    public class PokemonIdToArMarkerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Conversions.BitmapToImageSource(ArMarker.PokemonIdToImage((ushort)value, 25));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) // unnecessary
        {
            return null;
        }
    }
}
