using System.Collections.Generic;
using System.Drawing;

namespace SignClassification
{
    class Claster
    {
        public double[] Interval = new double[2];
        public List<SignImage> BmpList = new List<SignImage>();
        public Claster(double start, double finish)
        {
            Interval[0] = start;
            Interval[1] = finish;
        }

        public Claster()
        {

        }

        public Claster ShallowCopy()
        {
            Claster claster = (Claster) this.MemberwiseClone();
            claster.BmpList = new List<SignImage>();
            return claster;
        }
    }
}
