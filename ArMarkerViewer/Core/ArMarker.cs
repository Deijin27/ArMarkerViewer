using System.Drawing;

namespace ArMarkerViewer.Core
{
    public static class ArMarker
    {
        public static Bitmap CodeToImage(ushort arMarkerCode, int pixelSize)
        {
            int dimension = pixelSize * 6;
            Bitmap bmp = new Bitmap(dimension, dimension);
            using Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            for (int i = 0; i < 0x10; i++)
            {
                int xShift = (i % 4 + 1);
                int yShift = (i / 4 + 1);

                if (((arMarkerCode >> i) & 1) == 1)
                {
                    g.FillRectangle(whiteBrush, new Rectangle(xShift * pixelSize, yShift * pixelSize, pixelSize, pixelSize));
                }
            }
            return bmp;
        }

        public static Bitmap PokemonIdToImage(ushort pokemonId, int pixelSize)
        {
            return CodeToImage(PokemonIdToCode(pokemonId), pixelSize);
        }

        public static ushort PokemonIdToCode(ushort pokemonId)
        {
            int result = 0x0200 // start with this because of offset 9 always being 1

                | ((pokemonId >> 5) & 1) << 2 // I could remove one shift from these things, but speed doesn't really matter and it's much easier to understand like this.
                | SpecialNumberCycle(pokemonId, 1) // << 0
                | ((pokemonId >> 8) & 1) << 1                            
                | ((pokemonId >> 2) & 1) << 3

                | SpecialNumberCycle(pokemonId, 8) << 4
                | ((pokemonId >> 9) & 1) << 5
                // offset 6 is always 0
                | ((pokemonId >> 7) & 1) << 7

                | SpecialNumberCycle(pokemonId, 64) << 8
                // offset 9 is always 1
                | ((pokemonId >> 9) & 1) << 10
                | ((pokemonId >> 4) & 1) << 11

                | ((pokemonId >> 0) & 1) << 12
                | ((pokemonId >> 3) & 1) << 13
                | ((pokemonId >> 6) & 1) << 14
                | ((pokemonId >> 1) & 1) << 15;

            return (ushort)result;
        }

        /// <summary>
        /// Accepts arMarkerCode. Returns bool as of whether the code is valid, and also 
        /// has an out value that is the detected pokemonId.
        /// </summary>
        /// <param name="arMarkerCode"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public static bool TryCodeToPokemonId(ushort arMarkerCode, out ushort pokemonId)
        {
            int result = 0
                | ((arMarkerCode >> 1) & 1) << 8
                | ((arMarkerCode >> 2) & 1) << 5
                | ((arMarkerCode >> 3) & 1) << 2;

            int nine1 = ((arMarkerCode >> 5) & 1) << 9;
            int nine2 = ((arMarkerCode >> 10) & 1) << 9;

            if (nine1 != nine2)
            {
                pokemonId = 0;
                return false;
            }
            result |= nine1
                | ((arMarkerCode >> 7) & 1) << 7
                | ((arMarkerCode >> 11) & 1) << 4
                | ((arMarkerCode >> 12) & 1) << 0
                | ((arMarkerCode >> 13) & 1) << 3
                | ((arMarkerCode >> 14) & 1) << 6
                | ((arMarkerCode >> 15) & 1) << 1;

            pokemonId = (ushort)result;

            if (SpecialNumberCycle(pokemonId, 1) != ((arMarkerCode >> 0) & 1))
                return false;

            if (SpecialNumberCycle(pokemonId, 8) != ((arMarkerCode >> 4) & 1))
                return false;

            if (SpecialNumberCycle(pokemonId, 64) != ((arMarkerCode >> 8) & 1))
                return false;

            if ((arMarkerCode >> 6) == 1)
                return false;

            if ((arMarkerCode >> 9) == 0)
                return false;

            return true;
        }

        private static int SpecialNumberCycle(ushort pokemonId, int divisor)
        {
            return (0x69 >> (pokemonId / divisor % 8)) & 1; // nice
        }
    }
}
