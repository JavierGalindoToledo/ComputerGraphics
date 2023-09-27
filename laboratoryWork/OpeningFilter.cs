using System.Drawing;
using System.ComponentModel;


namespace Lab1
{
    class OpeningFilter : MatrixFilter
    {
        public OpeningFilter()
        {
            this.kernel = null;
        }
        public OpeningFilter(float[,] kernel)
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
            return dilation.processImage(erosion.processImage(sourceImage, worker), worker);
        }
    }
}
