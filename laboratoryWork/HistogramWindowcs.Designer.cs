
namespace Lab1
{
    partial class HistogramWindowcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.mHistogramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.mHistogramChart)).BeginInit();
            this.SuspendLayout();
            // 
            // mHistogramChart
            // 
            chartArea1.Name = "ChartArea1";
            this.mHistogramChart.ChartAreas.Add(chartArea1);
            this.mHistogramChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.mHistogramChart.Legends.Add(legend1);
            this.mHistogramChart.Location = new System.Drawing.Point(0, 0);
            this.mHistogramChart.Name = "mHistogramChart";
            this.mHistogramChart.Size = new System.Drawing.Size(800, 450);
            this.mHistogramChart.TabIndex = 0;
            this.mHistogramChart.Text = "mHistogramChart";
            this.mHistogramChart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // HistogramWindowcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mHistogramChart);
            this.Name = "HistogramWindowcs";
            this.Text = "HistogramWindowcs";
            ((System.ComponentModel.ISupportInitialize)(this.mHistogramChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mHistogramChart;
    }
}