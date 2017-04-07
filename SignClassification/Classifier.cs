using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SignClassification
{
    class Classifier
    {
        private List<double[]> _stablePointList;
        //матрица весов синапсов W и вектор смещения B, устойчивая точка
        private double[,] W;
        private double[] B, _stablePoint;
        public Split Split;
        private int M, N;
        public double K;
        private SignImage im;

        public StringBuilder LogStr { get; }

        public double[] StablePoint
        {
            get
            {
                return _stablePoint;
            }
        }

        public Classifier(SignImage image)
        {
            M = image.Bmp.Width;
            N = image.Bmp.Height;
            LogStr = new StringBuilder();
            //Генерируем случайные значения элементов Wmn матрицы M х N
            LogStr.AppendLine("Сумма квад ратов матрицы весов Wmn: " + Math.Round(GenerateWB(), 3));
            StartClassification(image);
            Write2DArray("w.txt", W);
            WriteArray("b.txt", B);
        }

        public Classifier(SignImage image, double[,] W, double[] B)
        {
            M = image.Bmp.Width;
            N = image.Bmp.Height;
            this.W = W;
            this.B = B;
            LogStr = new StringBuilder();
            //Генерируем случайные значения элементов Wmn матрицы M х N
            LogStr.AppendLine("Сумма квадратов матрицы весов Wmn: " + Math.Round(CheckW(), 3));
            StartClassification(image);
        }

        private void StartClassification(SignImage image)
        {
            //Определяем координаты устойчивой точки
            FindStablePoint2(image.Brightness);
            LogStr.AppendLine("Количество итераций при поиске устойчивой точки: " + _stablePointList.Count);
            LogStr.AppendLine("Максимальное значение в векторе устойчивой точки: " + Math.Round(StablePoint.Max(), 3));
            LogStr.AppendLine("Минимальное значение в векторе устойчивой точки: " + Math.Round(StablePoint.Min(), 3));
            //Определяем коэффициент сжатия отображения K 
            GenerateK();
            LogStr.AppendLine("Коэффициент сжатия отображения K: " + Math.Round(K, 5));
            CreateIntervals(image);
            LogStr.AppendLine("Количество диапазонов эвклидовых расстояний: " + Split.Clasters.Count);
        }

        private void LinearNormalization(double maxValue, double minValue, ref double[,] brightness)
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    brightness[i, j] = (brightness[i, j] - minValue) / (maxValue - minValue);
                }
            }
        }

        private void GenerateW_B()
        {
            W = new double[M*N, M*N];
            B = new double[M*N];
            Random rnd = new Random();
            double chiSquare = (double) rnd.Next(801, 899) / 1000.0;
            double sum = chiSquare;
            for (int i = 0; i < M*N; i++)
            {
                B[i] = rnd.NextDouble();
                for (int j = 0; j < M*N; j++)
                {
                    if (i == M - 1 && j == N - 1)
                    {
                        W[i, j] = Math.Sqrt(sum);
                        break;
                    }
                    W[i, j] = rnd.NextDouble() * Math.Sqrt(sum) / 100;
//                    while (sum <= W[i, j] * W[i, j])
//                    {
//                        W[i, j] = rnd.NextDouble();
//                    }
                    sum -= W[i, j] * W[i, j];
                }
            }
        }

        private double GenerateWB()
        {
            W = new double[M * N, M * N];
            B = new double[M * N];
            Random rnd = new Random();
            double chiSquare = (double)rnd.Next(801, 899) / 1000.0;
            double sum = 0;
            for (int i = 0; i < M * N; i++)
            {
                B[i] = rnd.NextDouble();
                for (int j = 0; j < M * N; j++)
                {
                    W[i, j] = rnd.NextDouble();
                    sum += W[i, j] * W[i, j];
                }
            }
            double divider = Math.Sqrt(sum /chiSquare);
            sum = 0;
            for (int i = 0; i < M * N; i++)
            {
                for (int j = 0; j < M * N; j++)
                {
                    W[i, j] /= divider;
                    sum += W[i, j] * W[i, j];
                }
            }
            return sum;
        }

        private double CheckW()
        {
            double chiSquare = 0;
            for (int i = 0; i < M*N; i++)
            {
                for (int j = 0; j < M * N; j++)
                {
                    chiSquare += W[i, j] * W[i, j];
                }
            }
            return chiSquare;
        }

        private void FindStablePoint(double[] u)
        {
            _stablePointList = new List<double[]>();
            double[] buf = new double[M*N];
            Array.Copy(u, buf, u.Length);
            _stablePointList.Add(buf.Clone() as double[]);
            bool equal = false;

            while (!equal)
            {
                equal = true;
                _stablePoint = new double[M * N];
                Parallel.For(0, M*N, i =>
                    {
                        for (int j = 0; j < M*N; j++)
                        {
                                _stablePoint[i] += W[i, j] * buf[j];
                        }
                        _stablePoint[i] += B[i];
                        if (Math.Abs(_stablePoint[i] - buf[i]) > 1E-6) equal = false;
                    }
                );
                Array.Copy(_stablePoint, buf, _stablePoint.Length);
                _stablePointList.Add(buf.Clone() as double[]);
            }
        }
        private void FindStablePoint2(double[] u)
        {
            _stablePointList = new List<double[]>();
            double[] buf = new double[M * N];
            Array.Copy(u, buf, u.Length);
            _stablePointList.Add(buf.Clone() as double[]);
            bool equal = false;
            double distance = 0;

            while (!equal)
            {
                equal = true;
                _stablePoint = new double[M * N];
                Parallel.For(0, M * N, i =>
                {
                    for (int j = 0; j < M * N; j++)
                    {
                        _stablePoint[i] += W[i, j] * buf[j];
                    }
                    _stablePoint[i] += B[i];
                }
                );
                double dis = EuclideanDistance(buf);
                if (Math.Abs(dis - distance) > 1E-6) equal = false;
                distance = dis;
                Array.Copy(_stablePoint, buf, _stablePoint.Length);
                _stablePointList.Add(buf.Clone() as double[]);
            }
        }

        public double EuclideanDistance(double[] image)
        {
            double p = 0;
            for (int i = 0; i < M*N; i++)
            {
                p += Math.Pow(image[i] - _stablePoint[i], 2);
            }
            return Math.Sqrt(p);
        }

        private void GenerateK()
        {
            K=new double();
            K = Math.Pow(EuclideanDistance(_stablePointList[_stablePointList.Count-11]) / EuclideanDistance(_stablePointList[3]), (double)1/(_stablePointList.Count - 11 - 3));
        }

        private void CreateIntervals(SignImage image)
        {
            Split = new Split();
            Split.Clasters.Add(new Claster(0, 10E-6 / K));
            double maxP = Math.Sqrt(M * N)* _stablePoint.Max();
            int i = 0;
            while (maxP >= Split.Clasters[i].Interval[1])
            {
                Split.Clasters.Add(new Claster(Split.Clasters[i].Interval[1], Split.Clasters[i].Interval[1] / K));
                i++;
            }
        }
        static void Write2DArray(string path, double[,] array)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(array.GetLength(0));
                sw.WriteLine(array.GetLength(1));
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    string[] line = new string[array.GetLength(1)];
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        //Cобираем в строковый массив столбцы текущей строки массива
                        line[j] = array[i, j].ToString(CultureInfo.InvariantCulture);
                    }
                    //Метод Join() склеивает элементы массива line в одну строку, разделяя их пробелами
                    sw.WriteLine(String.Join(" ", line));
                }
            }
        }
        static void WriteArray(string path, double[] array)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(array.GetLength(0));
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    sw.WriteLine(array[i].ToString(CultureInfo.InvariantCulture));
                }
            }
        }
    }
}
