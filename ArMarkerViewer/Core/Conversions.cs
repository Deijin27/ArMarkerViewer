using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ArMarkerViewer.Core;

static class Conversions
{
    public static BitmapImage BitmapToImageSource(Bitmap bitmap)
    {
        using MemoryStream memory = new MemoryStream();
        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
        memory.Position = 0;
        BitmapImage bitmapimage = new BitmapImage();
        bitmapimage.BeginInit();
        bitmapimage.StreamSource = memory;
        bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapimage.EndInit();

        return bitmapimage;
    }


    #region Id to Name

    private static readonly string[] NameLookup = Resource1.Names.Split(Environment.NewLine);
    public static string PokemonIdToName(ushort id) => NameLookup[id];

    #endregion


    #region Id To Icon

    private const int SpriteSheetWidth = 16;
    private const int SpritePixelWidth = 32;
    private const int SpritePixelHeight = 32;
    private static readonly BitmapImage IconSheet = BitmapToImageSource(Resource1.PokemonIconSheet);

    public static ImageSource PokemonIdToIcon(ushort id)
    {
        if (id > 733)
        {
            if (id >= 988 && id <= 1011) // random or mirror
            {
                id = 734;
            }
            else // not recognised by camera
            {
                id = 735;
            }
        }
        int row = id / SpriteSheetWidth;
        int col = id % SpriteSheetWidth;
        int hOffset = SpritePixelWidth * col;
        int vOffset = SpritePixelHeight * row;
        return new CroppedBitmap(IconSheet, new Int32Rect(hOffset, vOffset, SpritePixelWidth, SpritePixelHeight));
    }

    #endregion


}
