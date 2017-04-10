using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignClassification
{
    class SignImage
    {
        public Bitmap Bmp;
        public Claster Claster;
        public double[] Brightness;
        private double _distance;
        public List<double> Distances { get; } = new List<double>();

        public double Distance
        {
            set
            {
                Distances.Add(value);
                _distance = value;
            }
            get { return _distance; }
        }
        

        public SignImage(string path)
        {
            Bmp = new Bitmap(path);
            Brightness = new double[Bmp.Width*Bmp.Height];
            int k = 0;
            for (int i = 0; i < Bmp.Width; i++)
            {
                for (int j = 0; j < Bmp.Height; j++)
                {
                    Color oc = Bmp.GetPixel(i, j);
                    int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                    Bmp.SetPixel(i, j, nc);
                    Brightness[k] = Bmp.GetPixel(i, j).GetBrightness();
                    k++;
                }
            }
        }

        public SignImage()
        {
            
        }

        //Масштабирование яркостей изображения
        public double[] GetNewBrightness(double m)
        {
            double[] bufB = new double[Bmp.Width * Bmp.Height];
            int i = 0;
            foreach (var b in Brightness)
            {
                bufB[i] = b * m;
                i++;
            }
            return bufB;
        }

        private void LinearNormalization(double maxValue, double minValue, ref double[] brightness)
        {
            for (int i = 0; i < brightness.Length; i++)
            {
                brightness[i] = (brightness[i] - minValue) / (maxValue - minValue);
            }
        }

        public Bitmap CreateImage(double[] brightness)
        {
            Bitmap bmp = new Bitmap("d:\\обучение\\Распознавание знаков\\signs\\знаки\\image.bmp");
            int k = 0;
            double[] br = new double[brightness.Length];
            Array.Copy(brightness,br,brightness.Length);
            LinearNormalization(br.Max(), br.Min(), ref br);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color cl = Color.FromArgb((int)(br[k] * 255),(int)(br[k]*255),(int)(br[k]*255));
                    bmp.SetPixel(i,j,cl);
                    k++;
                }
            }
            //bmp.Save("d:\\обучение\\Распознавание знаков\\signs\\искуственные знаки\\image2.bmp");
            return bmp;
        }
    }
}
