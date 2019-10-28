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
    class Polygon
    {
        public List<VertexPoint> vertices;

        public Polygon()
        {
            vertices = new List<VertexPoint>();
        }
        public Polygon(List<VertexPoint> v)
        {
            vertices = v;
        }
        public Polygon(List<Point> points)
        {
            vertices = new List<VertexPoint>();
            foreach (var point in points)
            {
                vertices.Add(new VertexPoint(point));
            }
        }
    }
}
