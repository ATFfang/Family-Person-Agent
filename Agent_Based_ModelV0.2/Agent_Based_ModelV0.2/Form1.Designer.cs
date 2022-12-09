
namespace Agent_Based_ModelV0._1
{
    partial class Run01
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Get01 = new System.Windows.Forms.Button();
            this.textBoxGet01 = new System.Windows.Forms.TextBox();
            this.Iterations = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GetValue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Get01
            // 
            this.Get01.Location = new System.Drawing.Point(24, 25);
            this.Get01.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Get01.Name = "Get01";
            this.Get01.Size = new System.Drawing.Size(84, 22);
            this.Get01.TabIndex = 0;
            this.Get01.Text = "Get01";
            this.Get01.UseVisualStyleBackColor = true;
            this.Get01.Click += new System.EventHandler(this.Get01_Click);
            // 
            // textBoxGet01
            // 
            this.textBoxGet01.Location = new System.Drawing.Point(124, 26);
            this.textBoxGet01.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxGet01.Name = "textBoxGet01";
            this.textBoxGet01.Size = new System.Drawing.Size(112, 25);
            this.textBoxGet01.TabIndex = 1;
            this.textBoxGet01.Text = "140";
            // 
            // Iterations
            // 
            this.Iterations.Location = new System.Drawing.Point(124, 68);
            this.Iterations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Iterations.Name = "Iterations";
            this.Iterations.Size = new System.Drawing.Size(112, 25);
            this.Iterations.TabIndex = 2;
            this.Iterations.Text = "50";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 68);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 108);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 297);
            this.panel1.TabIndex = 5;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 3);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(671, 294);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // GetValue
            // 
            this.GetValue.Location = new System.Drawing.Point(292, 40);
            this.GetValue.Name = "GetValue";
            this.GetValue.Size = new System.Drawing.Size(107, 39);
            this.GetValue.TabIndex = 7;
            this.GetValue.Text = "ShowChart";
            this.GetValue.UseVisualStyleBackColor = true;
            this.GetValue.Click += new System.EventHandler(this.GetValue_Click);
            // 
            // Run01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 405);
            this.Controls.Add(this.GetValue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Iterations);
            this.Controls.Add(this.textBoxGet01);
            this.Controls.Add(this.Get01);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Run01";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Get01;
        private System.Windows.Forms.TextBox textBoxGet01;
        private System.Windows.Forms.TextBox Iterations;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button GetValue;
    }
}

