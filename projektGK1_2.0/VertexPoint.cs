using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projektGK1_2._0
{
    class VertexPoint
    {
        private Point point;

        public VertexPoint(Point point_)
        {
            point = point_;
        }
        public VertexPoint(int x, int y)
        {
            point = new Point(x, y);
        }
        public VertexPoint(PointF pointf_)
        {
            point = new Point((int)Math.Round(pointf_.X), (int)Math.Round(pointf_.Y));
        }
        public VertexPoint(double x, double y)
        {
            point = new Point((int)Math.Round(x), (int)Math.Round(y));
        }

        public Point Get() { return point; }
        public void Set(int x, int y)
        {
            point = new Point(x, y);
        }
        public void Set(PointF pointf_)
        {
            point = new Point((int)Math.Round(pointf_.X), (int)Math.Round(pointf_.Y));
        }
        public void Set(double x, double y)
        {
            point = new Point((int)Math.Round(x), (int)Math.Round(y));
        }
    }
}
