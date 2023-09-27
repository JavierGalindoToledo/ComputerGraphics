using System;
using System.Drawing;

namespace Lab1
{
    class BrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int k = 5;
            int R = Clamp(sourceColor.R + k, 0, 255);
            int G = Clamp(sourceColor.G + k, 0, 255);
            int B = Clamp(sourceColor.B + k, 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
