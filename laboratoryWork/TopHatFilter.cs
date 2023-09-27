using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Lab1
{
    class TopHatFilter : MatrixFilter
    {
        public TopHatFilter()
        {
            this.kernel = null;
        }

        public TopHatFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            OpeningFilter opening;
            if (this.kernel == null)
            {
                opening = new OpeningFilter();
            }
            else
            {
                opening = new OpeningFilter(this.kernel);
            }

            SubtractionFilter subtraction = new SubtractionFilter(sourceImage);
            return subtraction.processImage(opening.processImage(sourceImage, worker), worker);
        }
    }
}
