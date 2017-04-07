namespace SignClassification
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBNo = new System.Windows.Forms.RadioButton();
            this.rBYes = new System.Windows.Forms.RadioButton();
            this.pictureBoxIntervals = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureStablePoint = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaxMu = new System.Windows.Forms.TextBox();
            this.textBoxMinMu = new System.Windows.Forms.TextBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBoxMu = new System.Windows.Forms.MaskedTextBox();
            this.btnMuRun = new System.Windows.Forms.Button();
            this.btnMuLeft = new System.Windows.Forms.Button();
            this.btnMuRight = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntervals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStablePoint)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(12, 22);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(221, 32);
            this.buttonLoadImage.TabIndex = 0;
            this.buttonLoadImage.Text = "Загрузка изображений";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonCalc
            // 
            this.buttonCalc.Location = new System.Drawing.Point(12, 134);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(221, 32);
            this.buttonCalc.TabIndex = 1;
            this.buttonCalc.Text = "Расчет ";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.pictureBoxIntervals);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureStablePoint);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonLoadImage);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxMaxMu);
            this.panel2.Controls.Add(this.textBoxMinMu);
            this.panel2.Controls.Add(this.textBoxLog);
            this.panel2.Controls.Add(this.buttonCalc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1478, 276);
            this.panel2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBNo);
            this.groupBox1.Controls.Add(this.rBYes);
            this.groupBox1.Location = new System.Drawing.Point(239, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 55);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Повторяемость";
            // 
            // rBNo
            // 
            this.rBNo.AutoSize = true;
            this.rBNo.Location = new System.Drawing.Point(116, 26);
            this.rBNo.Name = "rBNo";
            this.rBNo.Size = new System.Drawing.Size(61, 24);
            this.rBNo.TabIndex = 14;
            this.rBNo.Text = "нет";
            this.rBNo.UseVisualStyleBackColor = true;
            // 
            // rBYes
            // 
            this.rBYes.AutoSize = true;
            this.rBYes.Checked = true;
            this.rBYes.Location = new System.Drawing.Point(7, 26);
            this.rBYes.Name = "rBYes";
            this.rBYes.Size = new System.Drawing.Size(54, 24);
            this.rBYes.TabIndex = 0;
            this.rBYes.TabStop = true;
            this.rBYes.Text = "да";
            this.rBYes.UseVisualStyleBackColor = true;
            // 
            // pictureBoxIntervals
            // 
            this.pictureBoxIntervals.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxIntervals.Location = new System.Drawing.Point(12, 172);
            this.pictureBoxIntervals.Name = "pictureBoxIntervals";
            this.pictureBoxIntervals.Size = new System.Drawing.Size(1450, 50);
            this.pictureBoxIntervals.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIntervals.TabIndex = 11;
            this.pictureBoxIntervals.TabStop = false;
            this.pictureBoxIntervals.Visible = false;
            this.pictureBoxIntervals.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxIntervals_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1016, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Устойчивая точка";
            // 
            // pictureStablePoint
            // 
            this.pictureStablePoint.Location = new System.Drawing.Point(1020, 43);
            this.pictureStablePoint.Name = "pictureStablePoint";
            this.pictureStablePoint.Size = new System.Drawing.Size(50, 50);
            this.pictureStablePoint.TabIndex = 9;
            this.pictureStablePoint.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Макс. масштаб";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Мин. масштаб";
            // 
            // textBoxMaxMu
            // 
            this.textBoxMaxMu.Location = new System.Drawing.Point(142, 102);
            this.textBoxMaxMu.Name = "textBoxMaxMu";
            this.textBoxMaxMu.Size = new System.Drawing.Size(91, 26);
            this.textBoxMaxMu.TabIndex = 4;
            this.textBoxMaxMu.Text = "1.4";
            // 
            // textBoxMinMu
            // 
            this.textBoxMinMu.Location = new System.Drawing.Point(142, 70);
            this.textBoxMinMu.Name = "textBoxMinMu";
            this.textBoxMinMu.Size = new System.Drawing.Size(91, 26);
            this.textBoxMinMu.TabIndex = 3;
            this.textBoxMinMu.Text = "0.8";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(428, 22);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(582, 144);
            this.textBoxLog.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.dataGridView3);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1478, 570);
            this.panel1.TabIndex = 6;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(523, 35);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(398, 339);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView2_RowPrePaint);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView3.Location = new System.Drawing.Point(921, 35);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView3.RowTemplate.Height = 28;
            this.dataGridView3.Size = new System.Drawing.Size(557, 339);
            this.dataGridView3.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(523, 339);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 374);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1478, 196);
            this.panel3.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Энтропии";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1478, 196);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.maskedTextBoxMu);
            this.panel4.Controls.Add(this.btnMuRun);
            this.panel4.Controls.Add(this.btnMuLeft);
            this.panel4.Controls.Add(this.btnMuRight);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(100, 0, 50, 0);
            this.panel4.Size = new System.Drawing.Size(1478, 35);
            this.panel4.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(546, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(15, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(216, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "Класстеризация по maxH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(1021, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label6.Size = new System.Drawing.Size(246, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Класстеризация при масштабе";
            // 
            // maskedTextBoxMu
            // 
            this.maskedTextBoxMu.Dock = System.Windows.Forms.DockStyle.Right;
            this.maskedTextBoxMu.Location = new System.Drawing.Point(1267, 0);
            this.maskedTextBoxMu.Mask = "0.000";
            this.maskedTextBoxMu.Name = "maskedTextBoxMu";
            this.maskedTextBoxMu.Size = new System.Drawing.Size(68, 26);
            this.maskedTextBoxMu.TabIndex = 18;
            // 
            // btnMuRun
            // 
            this.btnMuRun.BackgroundImage = global::SignClassification.Properties.Resources.media_play_green;
            this.btnMuRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMuRun.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMuRun.Location = new System.Drawing.Point(1335, 0);
            this.btnMuRun.Name = "btnMuRun";
            this.btnMuRun.Size = new System.Drawing.Size(31, 35);
            this.btnMuRun.TabIndex = 17;
            this.btnMuRun.UseVisualStyleBackColor = true;
            // 
            // btnMuLeft
            // 
            this.btnMuLeft.BackgroundImage = global::SignClassification.Properties.Resources.arrow1600_2;
            this.btnMuLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMuLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMuLeft.Location = new System.Drawing.Point(1366, 0);
            this.btnMuLeft.Name = "btnMuLeft";
            this.btnMuLeft.Size = new System.Drawing.Size(31, 35);
            this.btnMuLeft.TabIndex = 16;
            this.btnMuLeft.UseVisualStyleBackColor = true;
            // 
            // btnMuRight
            // 
            this.btnMuRight.BackgroundImage = global::SignClassification.Properties.Resources.arrow1600;
            this.btnMuRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMuRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMuRight.Location = new System.Drawing.Point(1397, 0);
            this.btnMuRight.Name = "btnMuRight";
            this.btnMuRight.Size = new System.Drawing.Size(31, 35);
            this.btnMuRight.TabIndex = 15;
            this.btnMuRight.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(100, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 200, 0);
            this.label3.Size = new System.Drawing.Size(446, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Класстеризация по max(∆H/∆μ)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 846);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Класстеризатор";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntervals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStablePoint)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonCalc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaxMu;
        private System.Windows.Forms.TextBox textBoxMinMu;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureStablePoint;
        private System.Windows.Forms.PictureBox pictureBoxIntervals;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBNo;
        private System.Windows.Forms.RadioButton rBYes;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMu;
        private System.Windows.Forms.Button btnMuRun;
        private System.Windows.Forms.Button btnMuLeft;
        private System.Windows.Forms.Button btnMuRight;
        private System.Windows.Forms.Label label3;
    }
}

