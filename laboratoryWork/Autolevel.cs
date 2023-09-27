using System;
using System.ComponentModel;
using System.Drawing;

namespace Lab1
{
    internal class Autolevel : Filters
    {
        private byte maxR = 0;
        private byte maxG = 0;
        private byte maxB = 0;

        private byte minR = 255;
        private byte minG = 255;
        private byte minB = 255;

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color c = sourceImage.GetPixel(x, y);
                    maxR = Math.Max(maxR, c.R);
                    maxG = Math.Max(maxG, c.G);
                    maxB = Math.Max(maxB, c.B);

                    minR = Math.Min(minR, c.R);
                    minG = Math.Min(minG, c.G);
                    minB = Math.Min(minB, c.B);
                }
            return base.processImage(sourceImage, worker);
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int lengthR = maxR - minR > 0 ? maxR - minR : 1;
            int lengthG = maxG - minG > 0 ? maxG - minG : 1;
            int lengthB = maxB - minB > 0 ? maxB - minB : 1;
            byte r = (byte)((sourceColor.R - minR) * 255 / lengthR);
            byte g = (byte)((sourceColor.G - minG) * 255 / lengthG);
            byte b = (byte)((sourceColor.B - minB) * 255 / lengthB);
            return Color.FromArgb(r, g, b);
        }
    }
}