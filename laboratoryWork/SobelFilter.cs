using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class SobelFilter : MatrixFilter
    {
        public SobelFilter()
        {
            float[,] sobelX = new float[,] { { -1, 0, 1 }, 
                                        { -2, 0, 2 }, 
                                        { -1, 0, 1 } };

            float[,] sobelY = new float[,] { { -1, -2, -1 },
                                        {  0,  0,  0 },
                                        {  1,  2,  1 } };

            //createSobelKernelMatrix(sobelX, 3);
            //createSobelKernelLine(sobelX, 0);
            createSobelKernel(sobelY);
        }

        public void createSobelKernel(float[,] res)
        {
            kernel = new float[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    kernel[i, j] = res[i, j];
        }

        public void createSobelKernelMatrix(float[,] sobel, int _size) //Вариант по матрицам
        {
            float[,] BaseMatrix = new float[,] { {1, 2, 1},
                                                 {2, 4, 2},
                                                 {1, 2, 1}};

            int KernelSize = sobel.GetLength(0);
            int HalfKernelSize = KernelSize / 2;
            int OutSize = KernelSize + 2;

            kernel = new float[OutSize, OutSize];
            float[,] InMatrix = new float[OutSize, OutSize];

            for (int x = 0; x < BaseMatrix.GetLength(0); x++)
                for (int y = 0; y < BaseMatrix.GetLength(1); y++)
                    InMatrix[HalfKernelSize + x, HalfKernelSize + y] = BaseMatrix[x, y];

            for (int x = 0; x < OutSize; x++)
                for (int y = 0; y < OutSize; y++)
                    for (int Kx = 0; Kx < KernelSize; Kx++)
                        for (int Ky = 0; Ky < KernelSize; Ky++)
                        {
                            int X = x + Kx - HalfKernelSize;
                            int Y = y + Ky - HalfKernelSize;

                            if (X >= 0 && Y >= 0 && X < OutSize && Y < OutSize)
                                kernel[x, y] += InMatrix[X, Y] * sobel[KernelSize - 1 - Kx, KernelSize - 1 - Ky];
                        }
        }

        public void createSobelKernelLine(float[,] Ky, int _size) //Вариант без матричный(Универсальный)
        {
            int side = _size *2 + 3;
            int halfSide = side / 2;
            kernel = new float[side, side]; //Ядро фильтра
            for (int i = 0; i < side; i++)
            {
                int k = (i <= halfSide) ? (halfSide + i) : (side + halfSide - i - 1);
                for (int j = 0; j < side; j++)
                {
                    if (j < halfSide)
                        kernel[i, j] = Ky[j, i] = j - k;
                    else if (j > halfSide)
                        kernel[i, j] = Ky[j, i] = k - (side - j - 1);
                    else
                        kernel[i, j] = Ky[j, i] = 0;
                }
            }
        }
    }
}
