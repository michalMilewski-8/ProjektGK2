using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektGK1_2._0
{
    class Edge
    {
        public VertexPoint a;
        public VertexPoint b;

        public double x_min;

        public double one_div_m;

        public Edge( VertexPoint a_, VertexPoint b_)
        {
            if (a_.Get().Y < b_.Get().Y)
            {
                a = a_;
                b = b_;
            }
            else
            {
                a = b_;
                b = a_;
            }
            SetXmin();
            CalculateOneDivM();
        }

        public void SetXmin()
        {
            x_min = a.Get().X;
        }
        public void CalculateOneDivM()
        {
            if (a.Get().Y == b.Get().Y) one_div_m = 0;
            else
            {
                one_div_m = (double)(b.Get().X - a.Get().X) / (double)(b.Get().Y - a.Get().Y);
            }
        }
    }
}
