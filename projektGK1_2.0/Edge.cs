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
        }
    }
}
