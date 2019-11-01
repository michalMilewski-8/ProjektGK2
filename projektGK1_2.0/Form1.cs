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
            CreateNet(20, 20);
            drawing_panel.Invalidate();
        }

        private List<Polygon> triangles_net;
        private VertexPoint[,] vertices;
        private static Size vartice_size = new Size(10, 10);
        private static int MouseBias = 5;
        private VertexPoint currently_changed_vertex;
        private bool moving = false;

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
                    vertices[i, j] = new VertexPoint(currentX, currentY);
                    currentY += diffY;
                }
                currentX += diffX;
                currentY = start.Y;
            }

            for (int i = 0; i < xcount - 1; i++)
            {
                for (int j = 0; j < ycount - 1; j++)
                {
                    triangles_net.Add(new Polygon());
                    triangles_net.Last().AddVertex(vertices[i, j]);
                    triangles_net.Last().AddVertex(vertices[i, j + 1]);
                    triangles_net.Last().AddVertex(vertices[i + 1, j]);
                    triangles_net.Add(new Polygon());
                    triangles_net.Last().AddVertex(vertices[i + 1, j]);
                    triangles_net.Last().AddVertex(vertices[i + 1, j + 1]);
                    triangles_net.Last().AddVertex(vertices[i, j + 1]);
                }
            }
        }




        private void FillFigure(Polygon polygon,Graphics e)
        {
            List<Edge>[] edges_table = new List<Edge>[drawing_panel.Height];
            for (int i = 0; i < polygon.edges.Count; i++)
            {
                Edge curr = polygon.edges[i];

                    if (edges_table[curr.a.Get().Y] is null)
                    {
                        edges_table[curr.a.Get().Y] = new List<Edge>();
                    }
                    edges_table[curr.a.Get().Y].Add(curr);

            }

            List<Edge> active_edges_table = new List<Edge>();
            int current = 0;
            for (int i = 0; i < drawing_panel.Height; i++)
            {
                if(!(edges_table[i] is null))
                {
                    current = i;
                    break;
                }
            }

            active_edges_table.AddRange(edges_table[current]);
            while (active_edges_table.Count > 0 && current < drawing_panel.Height-1)
            {
                active_edges_table.RemoveAll((Edge ed) =>
                {
                    return ed.b.Get().Y <= current;
                });
                active_edges_table.Sort((Edge e1, Edge e2) =>
                {
                    return e1.x_min.CompareTo(e2.x_min);
                });
                for(int i = 0; i < active_edges_table.Count - 1; i += 2)
                {
                    FillLine((int)Math.Round(active_edges_table[i].x_min), (int)Math.Round(active_edges_table[i + 1].x_min), current, e);
                    active_edges_table[i].x_min += active_edges_table[i].one_div_m;
                    active_edges_table[i+1].x_min += active_edges_table[i+1].one_div_m;
                }
                current++;
                if(!(edges_table[current] is null))
                active_edges_table.AddRange(edges_table[current]);
            }

            for (int i = 0; i < polygon.edges.Count; i++)
            {
                polygon.edges[i].SetXmin();
            }

        }

        private void FillLine(int x1, int x2, int y,Graphics e)
        {
            e.DrawLine(Pens.Silver, x1, y, x2, y);
        }

        private void DrawVertice(Point p, Graphics e)
        {
            Point here = new Point(p.X, p.Y);
            here.Offset(-5, -5);
            e.FillEllipse(Brushes.Red, new Rectangle(here, vartice_size));
        }
        private void DrawLine(Edge edge, Graphics e)
        {
            e.DrawLine(Pens.Black, edge.a.Get(), edge.b.Get());
        }
        private void drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var tri in triangles_net)
            {
                FillFigure(tri, e.Graphics);
                foreach (var edge in tri.edges)
                {
                    DrawLine(edge, e.Graphics);
                }
                foreach (var point in tri.vertices)
                {
                    DrawVertice(point.Get(), e.Graphics);
                }
            }
        }
        private VertexPoint FindIfOnVertex(Point p)
        {
            for (int i = 0; i < vertices.GetLength(0); i++)
            {
                for (int j = 0; j < vertices.GetLength(1); j++)
                {
                    Point v = vertices[i, j].Get();
                    if (Math.Abs(p.X - v.X) <= MouseBias && Math.Abs(p.Y - v.Y) <= MouseBias)
                    {
                        return vertices[i, j];
                    }
                }
            }
            return null;
        }

        private void drawing_panel_MouseDown(object sender, MouseEventArgs e)
        {
            VertexPoint tmp = FindIfOnVertex(e.Location);
            if (!(tmp is null))
            {
                currently_changed_vertex = tmp;
                moving = true;
            }
        }

        private void drawing_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving&& e.Location.Y>=0)
            {
                currently_changed_vertex.Set(e.Location);
                var dp = triangles_net.FindAll((Polygon p) =>
               {
                   return p.vertices.Contains(currently_changed_vertex);
               });
                for(int i = 0; i < dp.Count; i++)
                {
                    dp[i].MakeEdges();
                }
                drawing_panel.Invalidate();
            }
        }

        private void drawing_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                moving = false;
                currently_changed_vertex = null;
            }
        }
    }
}
