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
        public List<Edge> edges;

        public Polygon()
        {
            vertices = new List<VertexPoint>();
            edges = new List<Edge>();
        }
        public Polygon(List<VertexPoint> v)
        {
            vertices = v;
            MakeEdges();
        }
        public Polygon(List<Point> points)
        {
            vertices = new List<VertexPoint>();
            foreach (var point in points)
            {
                vertices.Add(new VertexPoint(point));
            }
            MakeEdges();
        }
        public void AddVertex(VertexPoint point)
        {
            vertices.Add(point);
            MakeEdges();
        }
        public void MakeEdges()
        {
            edges = new List<Edge>();
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                edges.Add(new Edge(vertices[i], vertices[i + 1]));
            }
            edges.Add(new Edge(vertices[0], vertices[vertices.Count - 1]));
        }
    }
}
