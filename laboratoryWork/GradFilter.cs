using System.Drawing;
using System.ComponentModel;

namespace Lab1
{
    class GradFilter : MatrixFilter
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            DilationFilter dilation = new DilationFilter();
            ErosionFilter erosion = new ErosionFilter();
            SubtractionFilter subtraction = new SubtractionFilter(dilation.processImage(sourceImage, worker));
            return subtraction.processImage(erosion.processImage(sourceImage, worker), worker);
        }
    }
}
