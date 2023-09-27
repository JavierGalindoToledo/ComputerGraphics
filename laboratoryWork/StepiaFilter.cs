using System;
using System.Drawing;

namespace Lab1
{
    class StepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int k = 9;
            int intensity = Convert.ToInt32((sourceColor.R * 0.299) + (sourceColor.G * 0.587) + (sourceColor.B * 0.114));
            int R = intensity + 2 * k;
            int G = Convert.ToInt32(intensity + 0.5 * k);
            int B = intensity - 1 * k;

            Color resultColor = Color.FromArgb(Clamp(R, 0, 255), Clamp(G, 0, 255), Clamp(B, 0, 255));
            return resultColor;
        }
    }
}
