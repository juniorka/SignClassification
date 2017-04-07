using System;
using System.Collections.Generic;

namespace SignClassification
{
    class Split
    {
        public List<Claster> Clasters;
        private double _h;
        public double H => _h;

        public double scale = 1;

        public void GenerateH(int images)
        {
            foreach (var claster in Clasters)
            {
                if (claster.BmpList.Count != 0)
                {
                    double d = (double)claster.BmpList.Count / images;
                    _h += Math.Abs(d * Math.Log(d, Math.E));
                }
            }
        }

        public Split(List<Claster> clasters, double scale)
        {
            Clasters = new List<Claster>();
            for( int i=0; i< clasters.Count;i++)
            {
                Clasters.Add(clasters[i].ShallowCopy());
            }
            this.scale = scale;
        }

        public Split()
        {
            Clasters = new List<Claster>();
        }
    }
}
