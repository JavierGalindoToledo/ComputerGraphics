using System;
using System.Drawing;

namespace Lab1
{
    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int R = Convert.ToInt32(sourceColor.R * 0.299);
            int G = Convert.ToInt32(sourceColor.G * 0.587);
            int B = Convert.ToInt32(sourceColor.B * 0.114);
            int res = Clamp((R + G + B), 0, 255);

            Color resultColor = Color.FromArgb(res, res, res);
            return resultColor;
        }
    }
}
