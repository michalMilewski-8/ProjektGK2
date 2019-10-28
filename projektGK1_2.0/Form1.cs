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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Polygon> triangles_net;
        private VertexPoint[,] vertices;

        private void CreateNet(int xcount, int ycount)
        {
            triangles_net = new List<Polygon>();
            vertices = new VertexPoint[xcount, ycount];
            Point start = new Point((int)Math.Round(drawing_panel.Width * 0.1), (int)Math.Round(drawing_panel.Height * 0.1));
            int diffX = (int)Math.Round((drawing_panel.Width * 0.8) / xcount);
            int diffY = (int)Math.Round((drawing_panel.Height * 0.8) / ycount);

            int currentX = start.X;
            int currentY = start.Y;


            for (int i = 0; i < xcount; i++)
            {
                for (int j = 0; j < ycount; j++)
                {
                    vertices[i, j] = new VertexPoint(currentX,currentY);
                    currentY += diffY;
                }
                currentX += diffX;
            }

            for (int i = 0; i < xcount - 1; i++)
            {
                for (int j = 0; j < ycount - 1; j++)
                {
                    triangles_net.Add(new Polygon());
                    triangles_net.Last().AddVertex(vertices[i, j]);
                    triangles_net.Last().AddVertex(vertices[i, j+1]);
                    triangles_net.Last().AddVertex(vertices[i+1, j]);
                    triangles_net.Add(new Polygon());
                    triangles_net.Last().AddVertex(vertices[i+1, j]);
                    triangles_net.Last().AddVertex(vertices[i+1, j + 1]);
                    triangles_net.Last().AddVertex(vertices[i, j+1]);
                }
            }
        }


        private void FillFigure(Polygon polygon)
        {
            List<Edge>[] edges_table = new List<Edge>[drawing_panel.Height];
            for(int i = 0; i < polygon.edges.Count; i++)
            {
                Edge curr = polygon.edges[i];
                if(edges_table[curr.a.Get().Y] is null)
                {
                    edges_table[curr.a.Get().Y] = new List<Edge>();
                }
                edges_table[curr.a.Get().Y].Add(curr);
            }

            
        }

    }
}
