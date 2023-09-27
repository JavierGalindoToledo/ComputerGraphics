using System;
using System.Drawing;

namespace Lab1
{
    class SubtractionFilter : Filters
    {
        Bitmap mMinuedImage = null;
        public SubtractionFilter(Bitmap minuendImage)
        {
            mMinuedImage = minuendImage;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color minuedColor = mMinuedImage.GetPixel(x, y);
            Color subtrahendColor = sourceImage.GetPixel(x, y);
            return Color.FromArgb(Clamp(minuedColor.R - subtrahendColor.R, 0, 255),
                                  Clamp(minuedColor.G - subtrahendColor.G, 0, 255),
                                  Clamp(minuedColor.B - subtrahendColor.B, 0, 255));
        }
    }
}
