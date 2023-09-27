using System;
using System.Drawing;

namespace Lab1
{
    class DilationFilter : MatrixFilter
    {
        public DilationFilter()
        {
            // kernel = new float[3, 3];
            kernel = new float[,] { {0.0f, 1.0f, 0.0f },
                                   {1.0f, 1.0f, 1.0f },
                                   {0.0f, 1.0f, 0.0f } };
            //kernel[0, 0] = 0.0f; kernel[0, 1] = 1.0f; kernel[0, 2] = 0.0f;
            //kernel[1, 0] = 1.0f; kernel[1, 1] = 1.0f; kernel[1, 2] = 1.0f;
            //kernel[2, 0] = 0.0f; kernel[2, 1] = 1.0f; kernel[2, 2] = 0.0f;
        }

        public DilationFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculateNewPixelColor(System.Drawing.Bitmap sourceImage, int x, int y)
        {
            // определяем радиус действия фильтра по оси X
            int radiusX = kernel.GetLength(0) / 2;

            // определяем радиус действия фильтра по оси Y
            int radiusY = kernel.GetLength(1) / 2;

            Color resultColor = Color.Black;

            byte max = 0;
            for (int l = -radiusY; l < radiusY; l++)
                for (int k = -radiusX; k < radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color color = sourceImage.GetPixel(idX, idY);
                    int intensity = color.R;
                    if (color.R != color.G || color.R != color.B || color.G != color.B)
                    {
                        intensity = (int)(0.36 * color.R + 0.53 * color.G + 0.11 * color.R);
                    }
                    if (kernel[k + radiusX, l + radiusY] > 0 && intensity > max)
                    {
                        max = (byte)intensity;
                        resultColor = color;
                    }
                }
            return resultColor;
        }

        //protected override Color calculateNewPixelColor(System.Drawing.Bitmap sourceImage, int x, int y)
        //{
        //    // определяем радиус действия фильтра по оси X
        //    int radiusX = kernel.GetLength(0) / 2;

        //    // определяем радиус действия фильтра по оси Y
        //    int radiusY = kernel.GetLength(1) / 2;

        //    Color resultColor = Color.Black;

        //    byte max = 0;
        //    for (int l = -radiusY; l <= radiusY; l++)
        //        for (int k = -radiusX; k <= radiusX; k++)
        //        {
        //            int idX = Clamp(x + k, 0, sourceImage.Width - 1);
        //            int idY = Clamp(y + l, 0, sourceImage.Height - 1);
        //            Color color = sourceImage.GetPixel(idX, idY);
        //            int intensity = color.R;
        //            if (color.R != color.G || color.R != color.B || color.G != color.B)
        //            {
        //                intensity = (int)(0.36 * color.R + 0.53 * color.G + 0.11 * color.R);
        //            }
        //            if (kernel[k + radiusX, l + radiusY] > 0 && intensity > max)
        //            {
        //                max = (byte)intensity;
        //                resultColor = color;
        //            }
        //        }
        //    return resultColor;
        //}
    }
}
