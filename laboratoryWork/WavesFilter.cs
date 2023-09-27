using System;
using System.Drawing;

namespace Lab1
{
    class WavesFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = Convert.ToInt32(x + 20 * Math.Sin((3.14 * y) / 60));
            if (k >= sourceImage.Width)
                k = sourceImage.Width - 1;
            if (k < 0)
                k = 0;
            Color sourceColor = sourceImage.GetPixel(k, y);
            Color resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            return resultColor;
        }
    }
}
