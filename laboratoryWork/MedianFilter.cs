using System;
using System.Drawing;

namespace Lab1
{
    class MedianFilter : Filters
    {
        private static void Sorting(double[] arr, long first, long last)
        {
            double p = arr[(last - first) / 2 + first];
            double temp;
            long i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < p && i <= last) ++i;
                while (arr[j] > p && j >= first) --j;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) Sorting(arr, first, j);
            if (i < last) Sorting(arr, i, last);
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double[] R = new double[9];
            double[] G = new double[9];
            double[] B = new double[9];

            if ((x < 5 || y < 5) || (x > sourceImage.Width - 5 || y > sourceImage.Height - 5)) //Если пиксель рядом с краями изображения - ничего не деаем
                return sourceColor;

            R[0] = sourceImage.GetPixel(x - 4, y - 4).R;
            G[0] = sourceImage.GetPixel(x - 4, y - 4).G;
            B[0] = sourceImage.GetPixel(x - 4, y - 4).B;

            R[1] = sourceImage.GetPixel(x - 3, y - 3).R;
            G[1] = sourceImage.GetPixel(x - 3, y - 3).G;
            B[1] = sourceImage.GetPixel(x - 3, y - 3).B;

            R[2] = sourceImage.GetPixel(x - 2, y - 2).R;
            G[2] = sourceImage.GetPixel(x - 2, y - 2).G;
            B[2] = sourceImage.GetPixel(x - 2, y - 2).B;

            R[3] = sourceImage.GetPixel(x - 1, y - 1).R;
            G[3] = sourceImage.GetPixel(x - 1, y - 1).G;
            B[3] = sourceImage.GetPixel(x - 1, y - 1).B;

            R[4] = sourceImage.GetPixel(x, y).R;
            G[4] = sourceImage.GetPixel(x, y).G;
            B[4] = sourceImage.GetPixel(x, y).B;

            R[5] = sourceImage.GetPixel(x + 1, y + 1).R;
            G[5] = sourceImage.GetPixel(x + 1, y + 1).G;
            B[5] = sourceImage.GetPixel(x + 1, y + 1).B;
                                  
            R[6] = sourceImage.GetPixel(x + 2, y + 2).R;
            G[6] = sourceImage.GetPixel(x + 2, y + 2).G;
            B[6] = sourceImage.GetPixel(x + 2, y + 2).B;

            R[7] = sourceImage.GetPixel(x + 3, y + 3).R;
            G[7] = sourceImage.GetPixel(x + 3, y + 3).G;
            B[7] = sourceImage.GetPixel(x + 3, y + 3).B;

            R[8] = sourceImage.GetPixel(x + 4, y + 4).R;
            G[8] = sourceImage.GetPixel(x + 4, y + 4).G;
            B[8] = sourceImage.GetPixel(x + 4, y + 4).B;

            Sorting(R, 0, R.Length - 1);
            Sorting(G, 0, G.Length - 1);
            Sorting(B, 0, B.Length - 1);

            Color resultColor = Color.FromArgb(Convert.ToInt32(R[4]), Convert.ToInt32(G[4]), Convert.ToInt32(B[4]));
            return resultColor;
        }


    }
}
