using System.Drawing;
using System.ComponentModel;

namespace Lab1
{
    class BlackHatFilter : MatrixFilter
    {
        public BlackHatFilter()
        {
            this.kernel = null;
        }

        public BlackHatFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            ClosingFilter closing;
            if (this.kernel == null)
            {
                closing = new ClosingFilter();
            }
            else
            {
                closing = new ClosingFilter(this.kernel);
            }
            SubtractionFilter subtraction = new SubtractionFilter(closing.processImage(sourceImage, worker));
            return subtraction.processImage(sourceImage, worker);
        }
    }
}
