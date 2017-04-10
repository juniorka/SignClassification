using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignClassification
{
    public partial class Form1 : Form
    {
        private Classifier classifier;
        private SignImage im;
        private List<SignImage> collectionList;
        private List<Split> splitsList;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            collectionList = new List<SignImage>();
            textBoxLog.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            maskedTextBoxMu.Text = 1.ToString();

            openFileDialog1.InitialDirectory = "d:\\обучение\\Распознавание знаков\\signs\\знаки";
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    collectionList.Add(new SignImage(file));
                }
            }
            double m = FindBetterStablePoint();
            //Генерируем новые W и B или используем из файла
            classifier = rBNo.Checked == true ? new Classifier(collectionList[0]) : new Classifier(collectionList[0], Read2DArray("w.txt"), ReadArray("b.txt"),m);

            textBoxLog.Text += classifier.LogStr;
            im = new SignImage();
            pictureStablePoint.Image = im.CreateImage(classifier.StablePoint);

            pictureBoxIntervals.BackColor = Color.White;
            pictureBoxIntervals.Visible = true;
            pictureBoxIntervals.Paint += this.pictureBoxIntervals_Paint;

        }

        private double FindBetterStablePoint()
        {
            List<Split> stableSplits = new List<Split>();
            double[,] w = Read2DArray("w.txt");
            double[] b = ReadArray("b.txt");
            double m = double.Parse(textBoxMinM.Text);
            double minM = m;
            int j = 0;
            const double step = 0.05;
            double maxM = double.Parse(textBoxMaxM.Text);
            List<double> x = new List<double>();
            while (m < maxM + step / 2.0)
            {
                x.Add(m);
                m += step;
            }
            //Формируем класстеры, меняя масштаб данных

            Parallel.ForEach(x, (i) =>
            {
                classifier = new Classifier(collectionList[0], w, b, i);
                Split split = new Split(classifier.Split.Clasters, 1);
                stableSplits.Add(split);
                foreach (var image in collectionList)
                {
                    image.Distance = classifier.EuclideanDistance(image.Brightness);
                    foreach (var claster in split.Clasters)
                    {
                        if (image.Distance <= claster.Interval[1])
                        {
                            claster.BmpList.Add(image);
                            break;
                        }
                    }
                }
            });
            double[] y = new double[stableSplits.Count];
            double buf = 0, splitNumber = 0;
            //Вычисляем наибольший перепад энтропий
            for (int i = 0; i < stableSplits.Count; i++)
            {
                stableSplits[i].GenerateH(collectionList.Count);
                y[i] = stableSplits[i].H;
                if (buf < stableSplits[i].H)
                {
                    buf = stableSplits[i].H;
                    splitNumber = i;
                }
            }
            chart2.ChartAreas[0].AxisX.Minimum = x[0];
            chart2.ChartAreas[0].AxisX.Maximum = x[x.Count-1];
            chart2.ChartAreas[0].AxisX.MajorGrid.Interval = step;
            // Добавляем вычисленные значения в график
            chart2.Series[0].Points.DataBindXY(x, y);

            m = minM + splitNumber * step;
            textBoxLogSP.Text += "Максимальная энтропия достигается при масштабе " + m + Environment.NewLine;
            return m;
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();

            splitsList = new List<Split>();
            double m = double.Parse(textBoxMinMu.Text);
            int j = 0;
            const double step = 0.05;
            //Формируем класстеры, меняя масштаб данных
            double maxM = double.Parse(textBoxMaxMu.Text);
            while(m <= maxM+step/2.0)
            {
                splitsList.Add(new Split(classifier.Split.Clasters, m));
                foreach (var image in collectionList)
                {
                    image.Distance = classifier.EuclideanDistance(image.GetNewBrightness(m));
                    foreach (var claster in splitsList[j].Clasters)
                    {
                        if (image.Distance <= claster.Interval[1])
                        {
                            image.Claster = claster;
                            claster.BmpList.Add(image);
                            break;
                        }
                    }
                }
                j++;
                m += step;
            }

            List<double> x = new List<double>();
            double[] y = new double[splitsList.Count];
            x.Add(splitsList[0].scale);

            double maxDH = 0;
            int splitNumber = 0;
            splitsList[0].GenerateH(collectionList.Count);
            y[0] = splitsList[0].H;
            //Вычисляем наибольший перепад энтропий
            for (int i = 1; i < splitsList.Count; i++)
            {
                splitsList[i].GenerateH(collectionList.Count);
                x.Add(splitsList[i].scale);
                y[i] = splitsList[i].H;
                var buf = Math.Abs(splitsList[i].H - splitsList[i-1].H)/(splitsList[i].scale - splitsList[i-1].scale);
                if (buf < maxDH) continue;
                maxDH = buf;
                if (splitsList[i].H < splitsList[i-1].H) splitNumber = i;
                else splitNumber = i-1;
            }
            chart1.ChartAreas[0].AxisX.Minimum = x[0];
            chart1.ChartAreas[0].AxisX.Maximum = x[x.Count-1];
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval =step;
            // Добавляем вычисленные значения в график
            chart1.Series[0].Points.DataBindXY(x, y);

            textBoxLog.Text += "Максимальный перепад энтропий достигается при " + splitsList[splitNumber].scale + Environment.NewLine;

            // Выводим найденное разбиение на кластеры
            foreach (var claster in splitsList[splitNumber].Clasters)
            {
                if (claster.BmpList.Count != 0)
                {
                    ShowClaster(claster.BmpList, splitNumber, dataGridView1);
                }
            }
            int maxHIndex = Array.IndexOf(y, y.Max());
            // Выводим разбиение по максимальной энтропии
            foreach (var claster in splitsList[maxHIndex].Clasters)
            {
                if (claster.BmpList.Count != 0)
                {
                    ShowClaster(claster.BmpList, maxHIndex, dataGridView2);
                }
            }
        }

        private void ShowClaster(List<SignImage> images, int splitNumber, DataGridView dataGridView)
        {
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            int icIndex = dataGridView.Columns.Add(imgCol);
            dataGridView.Columns[icIndex].Name = "Class" + icIndex;
            if (dataGridView.RowCount < images.Count)
                dataGridView.RowCount = images.Count;
            int i = 0;
            foreach (var image in images)
            {
                dataGridView.Rows[i].Cells["Class" + icIndex].Value = image.Bmp;
                dataGridView.Rows[i].Cells["Class" + icIndex].ToolTipText = image.Distances[splitNumber].ToString("0.00000");
                i++;
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null ||
               !head.Equals((e.RowIndex + 1).ToString()))
                this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value =
                   (e.RowIndex + 1).ToString();
        }

        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dataGridView2.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null ||
               !head.Equals((e.RowIndex + 1).ToString()))
                this.dataGridView2.Rows[e.RowIndex].HeaderCell.Value =
                   (e.RowIndex + 1).ToString();
        }

        private void DrowIntervals(List<Claster> clasters, Graphics gr)
        {
            pictureBoxIntervals.Width = (int)(50+10* Math.Round(clasters[clasters.Count - 1].Interval[1]));
            Pen pen = new Pen(Color.Black);
            Font fn = new Font(FontFamily.GenericMonospace, 6);
            Brush br = new SolidBrush(Color.Black);
            float y = 20;

            foreach (var claster in clasters)
            {
                float x1 = (float) (10*claster.Interval[0]);
                float x2 = (float) (10*claster.Interval[1]);
                gr.DrawLine(pen, x1, 15 ,x2 ,15);
                gr.DrawLine(pen, x1, 12, x1, 18);
                gr.DrawLine(pen, x2, 12, x2, 18);
                gr.DrawString(claster.Interval[1].ToString("0.000"), fn, br, x2, y);
                y = y > 19 ? 4 : 20;
            }

        }

        private void pictureBoxIntervals_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            DrowIntervals(classifier.Split.Clasters, e.Graphics);
        }

        static double[,] Read2DArray(string path)
        {
            double[,] arr;
            using (StreamReader sr = new StreamReader(path))
            {
                int n = int.Parse(sr.ReadLine()); //число строк
                int m = int.Parse(sr.ReadLine()); //число столбцов
                arr = new double[n, m];
                for (int i = 0; i < n; i++)
                {
                    //Считываем очередную строку из файла, в которой хранятся значения столбцов текущей строки
                    //Методом Split разбиваем ее по пробелам и заполняем массив.
                    string temp = sr.ReadLine();
                    string[] line = temp.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < m; j++)
                    {
                        arr[i, j] = double.Parse(line[j]);
                    }
                }
            }
            return arr;
        }
        static double[] ReadArray(string path)
        {
            double[] arr;
            using (StreamReader sr = new StreamReader(path))
            {
                int n = int.Parse(sr.ReadLine()); //число строк
                arr = new double[n];
                for (int i = 0; i < n; i++)
                {
                    arr[i] = double.Parse(sr.ReadLine());
                }
            }
            return arr;
        }

        private void btnMuRun_Click(object sender, EventArgs e)
        {
            double m = Double.Parse(maskedTextBoxMu.Text);
            Split split = new Split(classifier.Split.Clasters, m);
            foreach (var image in collectionList)
            {
                image.Distance = classifier.EuclideanDistance(image.GetNewBrightness(m));
                foreach (var claster in split.Clasters)
                {
                    if (image.Distance <= claster.Interval[1])
                    {
                        claster.BmpList.Add(image);
                        break;
                    }
                }
            }
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();

            foreach (var claster in split.Clasters)
            {
                if (claster.BmpList.Count != 0)
                {
                    ShowClaster(claster.BmpList, collectionList[0].Distances.Count-1, dataGridView3);
                }
            }
        }

        private void btnMuRight_Click(object sender, EventArgs e)
        {
            double m = Double.Parse(maskedTextBoxMu.Text);
            m += 0.1;
            maskedTextBoxMu.Text = m.ToString();
            btnMuRun_Click(sender, e);
        }

        private void btnMuLeft_Click(object sender, EventArgs e)
        {
            double m = Double.Parse(maskedTextBoxMu.Text);
            m -= 0.1;
            maskedTextBoxMu.Text = m.ToString();
            btnMuRun_Click(sender, e);
        }

        private void dataGridView3_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dataGridView3.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null ||
               !head.Equals((e.RowIndex + 1).ToString()))
                this.dataGridView3.Rows[e.RowIndex].HeaderCell.Value =
                   (e.RowIndex + 1).ToString();
        }

        private void btnRunK_Click(object sender, EventArgs e)
        {
            classifier.K = Double.Parse(maskedTextBoxK.Text);
            classifier.CreateIntervals();
            textBoxLog.Text += "Коэффициент сжатия отображения K: " + Math.Round(classifier.K, 5)+ Environment.NewLine;
            textBoxLog.Text += "Количество диапазонов эвклидовых расстояний: " + classifier.Split.Clasters.Count+ Environment.NewLine;

            //pictureBoxIntervals.Width = (int)(50 + 10 * Math.Round(classifier.Split.Clasters[classifier.Split.Clasters.Count - 1].Interval[1]));
            pictureBoxIntervals_Paint(sender, new PaintEventArgs(pictureBoxIntervals.CreateGraphics(),pictureBoxIntervals.Bounds));

        }

        private void btnKRight_Click(object sender, EventArgs e)
        {
            double k = Double.Parse(maskedTextBoxK.Text);
            k += 0.005;
            maskedTextBoxMu.Text = k.ToString();
            btnRunK_Click(sender, e);
        }

        private void btnKLeft_Click(object sender, EventArgs e)
        {
            double k = Double.Parse(maskedTextBoxK.Text);
            k -= 0.005;
            maskedTextBoxMu.Text = k.ToString();
            btnRunK_Click(sender, e);
        }
    }
}