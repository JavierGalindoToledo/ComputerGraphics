using System;
using System.Drawing;

namespace Lab1
{
    class glassEffectFilter : Filters
    {
        Random rnd1 = new Random(1942352);
        Random rnd2 = new Random(4352347);

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int r1 = rnd1.Next(10);
            int r2 = rnd2.Next(10);

            int xR = Convert.ToInt32(x + r1);
            int yR = Convert.ToInt32(y + r2);

            if (xR < 0)
                xR = x + 2;
            if (xR >= sourceImage.Width)
                xR = x - 2;
            if (yR < 0)
                yR = y + 2;
            if (yR >= sourceImage.Height)
                yR = y - 2;


            Color sourceColor = sourceImage.GetPixel(xR, yR);
            Color resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            return resultColor;
        }
    }
}
