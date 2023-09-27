using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1 //Коррекция с опорным цветом
{
    class CorrectingColorFilter : Filters
    {
        private Color click_color;
        public CorrectingColorFilter(Color _color)
        {
            click_color = _color;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y); //src
            int R, G, B;

            if (click_color.R == 0)
                R = sourceColor.R;
            else
                R = sourceColor.R * (255 / click_color.R);

            if (click_color.G == 0)
                G = sourceColor.G;
            else
                G = sourceColor.G * (255 / click_color.G);

            if (click_color.B == 0)
                B = sourceColor.B;
            else
                B = sourceColor.B * (255 / click_color.B);

            Color resultColor = Color.FromArgb(Clamp(R, 0, 255), Clamp(G, 0, 255), Clamp(B, 0, 255));
            return resultColor;
        }
    }
}
