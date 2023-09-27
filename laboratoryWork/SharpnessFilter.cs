using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 //Делать
{
    class SharpnessFilter : MatrixFilter
    {
        public SharpnessFilter()
        {
            float[,] res = new float[,] { {  0, -1,  0 }, 
                                          { -1,  5, -1 }, 
                                          {  0, -1,  0 } };

            createSharpnessKernel(res);
        }

        public void createSharpnessKernel(float[,] res)
        {
            kernel = new float[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    kernel[i, j] = res[i, j];
        }
    }
}
