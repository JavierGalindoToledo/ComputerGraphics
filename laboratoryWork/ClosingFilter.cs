using System.Drawing;
using System.ComponentModel;

namespace Lab1
{
    class ClosingFilter : MatrixFilter
    {
        public ClosingFilter()
        {
            this.kernel = null;
        }

        public ClosingFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            DilationFilter dilation;
            ErosionFilter erosion;
            if (kernel != null)
            {
                dilation = new DilationFilter(this.kernel);
                erosion = new ErosionFilter(this.kernel);
            }
            else
            {
                dilation = new DilationFilter();
                erosion = new ErosionFilter();
            }
            return erosion.processImage(dilation.processImage(sourceImage, worker), worker);
        }
    }
}
