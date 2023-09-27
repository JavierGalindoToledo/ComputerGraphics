using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Bitmap temp_image; //Для отмены
        Color pixelColor;
        bool filters = false;
        public string name; //Для хранения названия файла       

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); //Диалог открытия файла
            dialog.Filter = "Image files|*.png; *.jpg; *.bmp|All files(.*.)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                name = Path.GetFileName(dialog.FileName);
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void InversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void BlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ФильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void GrayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void stepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new StepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void brightnessЯркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new BrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sharpnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void glassEffectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new glassEffectFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void correctingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для коррекции выберите точку на изображении", "Сообщение");
            filters = true;

        }
        private Color GetColorAt(Point point)
        {
            return ((Bitmap)pictureBox1.Image).GetPixel(point.X, point.Y);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (filters)
            {
                if (e.Button == MouseButtons.Left)
                    pixelColor = GetColorAt(e.Location);

                temp_image = new Bitmap(pictureBox1.Image);

                Filters filter = new CorrectingColorFilter(pixelColor);
                backgroundWorker1.RunWorkerAsync(filter);

                filters = false;
            }
        }

        private void linearStretchingToolStripMenuItem_Click(object sender, EventArgs e) //Линейное растяжение
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new linearStretchingFilters();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void displaceRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new DisplaceRightFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void wavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new WavesFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sharraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            if (toolStripTextBox1.Text != "" && Convert.ToInt32(toolStripTextBox1.Text) > 0)
            {
                Filters filter = new DilationFilter(MatrixFilter.generateUnitMatrix(Convert.ToInt32(toolStripTextBox1.Text)));
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else 
            {
                Filters filter = new DilationFilter();
                backgroundWorker1.RunWorkerAsync(filter);
            }
            
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            if (toolStripTextBox1.Text != "" && Convert.ToInt32(toolStripTextBox1.Text) > 0)
            {
                Filters filter = new ErosionFilter(MatrixFilter.generateUnitMatrix(Convert.ToInt32(toolStripTextBox1.Text)));
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                Filters filter = new ErosionFilter();
                backgroundWorker1.RunWorkerAsync(filter);
            }
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            if (toolStripTextBox1.Text != "" && Convert.ToInt32(toolStripTextBox1.Text) > 0)
            {
                Filters filter = new OpeningFilter(MatrixFilter.generateUnitMatrix(Convert.ToInt32(toolStripTextBox1.Text)));
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                Filters filter = new OpeningFilter();
                backgroundWorker1.RunWorkerAsync(filter);
            }
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            if (toolStripTextBox1.Text != "" && Convert.ToInt32(toolStripTextBox1.Text) > 0)
            {
                Filters filter = new ClosingFilter(MatrixFilter.generateUnitMatrix(Convert.ToInt32(toolStripTextBox1.Text)));
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                Filters filter = new ClosingFilter();
                backgroundWorker1.RunWorkerAsync(filter);
            }
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new TopHatFilter(MatrixFilter.generateUnitMatrix(7));
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new BlackHatFilter(MatrixFilter.generateUnitMatrix(7));
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new GradFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp_image = new Bitmap(pictureBox1.Image);

            Filters filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Image Files|*.png;*.jpeg;*.jpg;*.bmp|All files(*.*)|*.*",
                FileName = name
            };


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image.Save(dialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно сохранить изображение", ex.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rgbhistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new GrayScaleFilter();
            int[][] histogram = new int[3][];
            histogram[0] = new int[256];
            histogram[1] = new int[256];
            histogram[2] = new int[256];
            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                {
                    Color sourceColor = image.GetPixel(x, y);
                    histogram[0][sourceColor.R]++;
                    histogram[1][sourceColor.G]++;
                    histogram[2][sourceColor.B]++;
                }
            HistogramWindowcs histogramView = new HistogramWindowcs();
            histogramView.ShowRGBHistogram(histogram);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = temp_image;
            image = temp_image;
        }

        private void bWГистограммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            Bitmap palImage = filter.processImage(image);
            int[] histogram = new int[256];
            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                    histogram[palImage.GetPixel(x, y).R]++;
            HistogramWindowcs histogramView = new HistogramWindowcs();
            histogramView.ShowIntensityHistogram(histogram);
        }

        private void автокоецияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Autolevel();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}