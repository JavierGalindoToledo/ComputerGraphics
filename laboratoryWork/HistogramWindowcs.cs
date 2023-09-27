using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    public partial class HistogramWindowcs : Form
    {
        public HistogramWindowcs()
        {
            InitializeComponent();
        }

        public void ShowIntensityHistogram(int[] histogram)
        {
            ChartArea ca = new ChartArea();
            ca.AxisX.Minimum = 0;
            ca.AxisX.Maximum = 256;
            ca.AxisY.Minimum = 0;
            ca.AxisY.Maximum = histogram.Max();
            ca.AxisY.Interval = 500;
            mHistogramChart.ChartAreas.Add(ca);

            mHistogramChart.Series.Add("Интенсивность");
            mHistogramChart.Series["Интенсивность"].XValueType = ChartValueType.Int32;
            mHistogramChart.Series["Интенсивность"].ChartType = SeriesChartType.Column;
            mHistogramChart.Series["Интенсивность"]["PointWidth"] = "1";
            mHistogramChart.Series["Интенсивность"].Points.DataBindY(histogram);
            Show();
        }

        public void ShowRGBHistogram(int[][] histogram)
        {
            ChartArea ca = new ChartArea();
            ca.AxisX.Minimum = 0;
            ca.AxisX.Maximum = 256;
            ca.AxisY.Minimum = 0;
            ca.AxisY.Maximum = Math.Max(histogram[0].Max(), Math.Max(histogram[1].Max(), histogram[2].Max()));
            ca.AxisY.Interval = 1000;
            mHistogramChart.ChartAreas.Add(ca);

            mHistogramChart.Series.Add("Красный");
            mHistogramChart.Series["Красный"].XValueType = ChartValueType.Int32;
            mHistogramChart.Series["Красный"].ChartType = SeriesChartType.Column;
            mHistogramChart.Series["Красный"].Color = Color.FromArgb(85, Color.Red);
            mHistogramChart.Series["Красный"].Points.DataBindY(histogram[0]);
            mHistogramChart.Series["Красный"]["PointWidth"] = "1";

            mHistogramChart.Series.Add("Зелёный");
            mHistogramChart.Series["Зелёный"].XValueType = ChartValueType.Int32;
            mHistogramChart.Series["Зелёный"].ChartType = SeriesChartType.Column;
            mHistogramChart.Series["Зелёный"].Color = Color.FromArgb(85, Color.Green);
            mHistogramChart.Series["Зелёный"].Points.DataBindY(histogram[1]);
            mHistogramChart.Series["Зелёный"].MarkerSize = 1;
            mHistogramChart.Series["Зелёный"]["PointWidth"] = "1";

            mHistogramChart.Series.Add("Синий");
            mHistogramChart.Series["Синий"].XValueType = ChartValueType.Int32;
            mHistogramChart.Series["Синий"].ChartType = SeriesChartType.Column;
            mHistogramChart.Series["Синий"].Color = Color.FromArgb(85, Color.DarkBlue);
            mHistogramChart.Series["Синий"].Points.DataBindY(histogram[2]);
            mHistogramChart.Series["Синий"]["PointWidth"] = "1";
            Show();
        }
    }
}
