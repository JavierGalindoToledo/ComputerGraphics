using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class SharraFilter : MatrixFilter
    {
        public SharraFilter()
        {
            float[,] sharraX = new float[,] { { 3,  0,  -3 },
                                              { 10, 0, -10 },
                                              { 3,  0,  -3 } };

            createSharraKernel(sharraX);
        }

        public void createSharraKernel(float[,] res)
        {
            kernel = new float[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    kernel[i, j] = res[i, j];
        }
    }
}
