using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ArMarkerViewer.ValueConverters
{
    public class PokemonIdToIconConverter : IValueConverter
    {
        private const int SpriteSheetWidth = 16;
        private const int SpritePixelWidth = 32;
        private const int SpritePixelHeight = 32;

        private static readonly BitmapImage IconSheet = Conversions.BitmapToImageSource(Resource1.PokemonIconSheet);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ushort spriteSheetId = (ushort)value;

            if (spriteSheetId > 733)
            {
                if (spriteSheetId >= 988 && spriteSheetId <= 1011) // random or mirror
                {
                    spriteSheetId = 734;
                }
                else // not recognised by camera
                {
                    spriteSheetId = 735;
                }
            }

            int row = spriteSheetId / SpriteSheetWidth;
            int col = spriteSheetId % SpriteSheetWidth;
            int hOffset = SpritePixelWidth * col;
            int vOffset = SpritePixelHeight * row;
            return new CroppedBitmap(IconSheet, new Int32Rect(hOffset, vOffset, SpritePixelWidth, SpritePixelHeight));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) // unnecessary
        {
            return null;
        }
    }
}
