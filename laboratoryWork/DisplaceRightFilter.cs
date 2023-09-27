using System;
using System.Drawing;

namespace Lab1
{
    class DisplaceRightFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (x <= 50)
            {
                return Color.FromArgb(0, 0, 0);
            }

            x = x - 50;

            if (x < 0)
            {
                x = 0;
            }

            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            return resultColor;
        }
    }
}
