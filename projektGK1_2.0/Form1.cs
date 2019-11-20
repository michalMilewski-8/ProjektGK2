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
    struct PointInSpace
    {
        public int X;
        public int Y;
        public int Z;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fill_color = Color.Silver;
            light_color = new ColorVectorREal(Color.White);
            CreateNet(NetSize, NetSize);
            drawing_panel.Invalidate();
            light_source.Z = 10;
        }
        private int NetSize = 5;
        private List<Polygon> triangles_net;
        private VertexPoint[,] vertices;
        private static Size vartice_size = new Size(10, 10);
        private const int MouseBias = 5;
        private VertexPoint currently_changed_vertex;
        private bool moving = false;
        private Color fill_color;
        private ColorVectorREal light_color;
        private Vector3 V = new Vector3(0, 0, 1);
        private BmpPixelSnoop textureBmp;
        private BmpPixelSnoop normalMap;
        private BmpPixelSnoop tmpPicture;
        private PointInSpace light_source = new PointInSpace();
        private readonly double degree = Math.PI / 180;
        private int current_degree = 0;
        private int current_z_degree = 0;
        private double radius;
        private Point center_point;
        private bool texture_loaded = false;
        private bool normal_map_loaded = false;
        double Ks = 0.50;
        double Kd = 0.50;
        int M = 1;
        private readonly Random rand = new Random();


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

        private Vector3 CrossProduct(Vector3 a, Vector3 b)
        {
            Vector3 c = new Vector3();
            c.x = a.y * b.z - a.z * b.y;
            c.y = a.z * b.x - a.x * b.z;
            c.x = a.x * b.y - a.y * b.x;
            return c;
        }

        private double CrossProduct(Point a, Point b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        private double cosin(Vector3 v, Vector3 b)
        {
            return (v.x * b.x + v.y * b.y + v.z * b.z);
        }

        private double DotProd(Vector3 v, Vector3 b)
        {
            return (v.x * b.x + v.y * b.y + v.z * b.z);
        }

        private void MoveLightSource()
        {
            light_source.X = (int)Math.Round(center_point.X + radius * Math.Sin(current_degree * degree));
            light_source.Y = (int)Math.Round(center_point.Y + radius * Math.Cos(current_degree * degree));

            light_source.Z = (int)Math.Round(10 + 200 * Math.Abs(Math.Sin(current_z_degree * degree)));

            current_z_degree += 3;
            current_z_degree %= 360;
            current_degree += 10;
            current_degree %= 360;
        }

        private void FillFigure(Polygon polygon, double ks, double kd, int m)
        {


            if (randomParameters.Checked)
            {
                ks = rand.NextDouble();
                kd = rand.NextDouble();
                m = (int)(rand.NextDouble() * 100);
            }

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
                if (!(edges_table[i] is null))
                {
                    current = i;
                    break;
                }
            }

            active_edges_table.AddRange(edges_table[current]);
            while (active_edges_table.Count > 0 && current < drawing_panel.Height - 1)
            {
                active_edges_table.RemoveAll((Edge ed) =>
                {
                    return ed.b.Get().Y <= current;
                });
                active_edges_table.Sort((Edge e1, Edge e2) =>
                {
                    return e1.x_min.CompareTo(e2.x_min);
                });
                for (int i = 0; i < active_edges_table.Count - 1; i += 2)
                {
                    FillLine((int)Math.Round(active_edges_table[i].x_min), (int)Math.Round(active_edges_table[i + 1].x_min), current, ks, kd, m);
                    active_edges_table[i].x_min += active_edges_table[i].one_div_m;
                    active_edges_table[i + 1].x_min += active_edges_table[i + 1].one_div_m;
                }
                current++;
                if (!(edges_table[current] is null))
                    active_edges_table.AddRange(edges_table[current]);
            }

            for (int i = 0; i < polygon.edges.Count; i++)
            {
                polygon.edges[i].SetXmin();
            }

        }

        private void FillFigureAprox(Polygon polygon, double ks, double kd, int m)
        {
            if (randomParameters.Checked)
            {
                ks = rand.NextDouble();
                kd = rand.NextDouble();
                m = (int)(rand.NextDouble() * 100);
            }
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
                if (!(edges_table[i] is null))
                {
                    current = i;
                    break;
                }
            }

            Point pointa = new Point(polygon.vertices[0].Get().X, polygon.vertices[0].Get().Y);
            Point pointb = new Point(polygon.vertices[1].Get().X, polygon.vertices[1].Get().Y);
            Point pointc = new Point(polygon.vertices[2].Get().X, polygon.vertices[2].Get().Y);

            Color preva = Count(pointa.X, pointa.Y, ks, kd, m);
            Color prevb = Count(pointb.X, pointb.Y, ks, kd, m);
            Color prevc = Count(pointc.X, pointc.Y, ks, kd, m);

            active_edges_table.AddRange(edges_table[current]);
            while (active_edges_table.Count > 0 && current < drawing_panel.Height - 1)
            {
                active_edges_table.RemoveAll((Edge ed) =>
                {
                    return ed.b.Get().Y <= current;
                });
                active_edges_table.Sort((Edge e1, Edge e2) =>
                {
                    return e1.x_min.CompareTo(e2.x_min);
                });
                for (int i = 0; i < active_edges_table.Count - 1; i += 2)
                {
                    FillLineAprox((int)Math.Round(active_edges_table[i].x_min), (int)Math.Round(active_edges_table[i + 1].x_min), current, pointa, pointb, pointc, preva, prevb, prevc);
                    active_edges_table[i].x_min += active_edges_table[i].one_div_m;
                    active_edges_table[i + 1].x_min += active_edges_table[i + 1].one_div_m;
                }
                current++;
                if (!(edges_table[current] is null))
                    active_edges_table.AddRange(edges_table[current]);
            }

            for (int i = 0; i < polygon.edges.Count; i++)
            {
                polygon.edges[i].SetXmin();
            }
        }

        private void FillFigureHybrid(Polygon polygon, double ks, double kd, int m)
        {


            if (randomParameters.Checked)
            {
                ks = rand.NextDouble();
                kd = rand.NextDouble();
                m = (int)(rand.NextDouble() * 100);
            }

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
                if (!(edges_table[i] is null))
                {
                    current = i;
                    break;
                }
            }

            Point pointa = new Point(polygon.vertices[0].Get().X, polygon.vertices[0].Get().Y);
            Point pointb = new Point(polygon.vertices[1].Get().X, polygon.vertices[1].Get().Y);
            Point pointc = new Point(polygon.vertices[2].Get().X, polygon.vertices[2].Get().Y);
            Color preva = fill_color;
            Color prevb = fill_color;
            Color prevc = fill_color;
            if (!selectObjectColor.Checked && texture_loaded)
            {
                preva = textureBmp.GetPixel(pointa.X % textureBmp.Width, pointa.Y % textureBmp.Height);
                prevb = textureBmp.GetPixel(pointb.X % textureBmp.Width, pointb.Y % textureBmp.Height);
                prevc = textureBmp.GetPixel(pointc.X % textureBmp.Width, pointc.Y % textureBmp.Height);
            }

            var Na = new Vector3(0, 0, 1);
            var Nb = new Vector3(0, 0, 1);
            var Nc = new Vector3(0, 0, 1);
            if (!staticVector.Checked && normal_map_loaded)
            {
                var color = new ColorVector(normalMap.GetPixel(pointa.X % normalMap.Width, pointa.Y % normalMap.Height));
                Na = new Vector3(color.R, color.G, color.B);
                color = new ColorVector(normalMap.GetPixel(pointb.X % normalMap.Width, pointb.Y % normalMap.Height));
                Nb = new Vector3(color.R, color.G, color.B);
                color = new ColorVector(normalMap.GetPixel(pointc.X % normalMap.Width, pointc.Y % normalMap.Height));
                Nc = new Vector3(color.R, color.G, color.B);
            }


            active_edges_table.AddRange(edges_table[current]);
            while (active_edges_table.Count > 0 && current < drawing_panel.Height - 1)
            {
                active_edges_table.RemoveAll((Edge ed) =>
                {
                    return ed.b.Get().Y <= current;
                });
                active_edges_table.Sort((Edge e1, Edge e2) =>
                {
                    return e1.x_min.CompareTo(e2.x_min);
                });
                for (int i = 0; i < active_edges_table.Count - 1; i += 2)
                {
                    FillLineHybrid((int)Math.Round(active_edges_table[i].x_min), (int)Math.Round(active_edges_table[i + 1].x_min), current, pointa, pointb, pointc, preva, prevb, prevc, Na, Nb, Nc, ks, kd, m);
                    active_edges_table[i].x_min += active_edges_table[i].one_div_m;
                    active_edges_table[i + 1].x_min += active_edges_table[i + 1].one_div_m;
                }
                current++;
                if (!(edges_table[current] is null))
                    active_edges_table.AddRange(edges_table[current]);
            }

            for (int i = 0; i < polygon.edges.Count; i++)
            {
                polygon.edges[i].SetXmin();
            }

        }

        private void FillLine(int x1, int x2, int y, double ks, double kd, int m)
        {
            for (int i = x1; i <= x2; i++)
            {
                tmpPicture.SetPixel(i, y, Count(i, y, ks, kd, m));
            }
        }

        private void FillLineAprox(int x1, int x2, int y, Point a, Point b, Point c, Color preva, Color prevb, Color prevc)
        {
            //Parallel.For(x1, x2, (int i) =>
            //{
            for (int i = x1; i <= x2; i++)
            {
                tmpPicture.SetPixel(i, y, CalculateColor(a, b, c, new Point(i, y), preva, prevb, prevc));
            }
        }

        private void FillLineHybrid(int x1, int x2, int y, Point a, Point b, Point c, Color preva, Color prevb, Color prevc, Vector3 Na, Vector3 Nb, Vector3 Nc, double ks, double kd, int m)
        {
            //Parallel.For(x1, x2, (int i) =>
            //{
            for (int i = x1; i <= x2; i++)
            {
                tmpPicture.SetPixel(i, y, HybridCount(i, y, ks, kd, m, CalculateN(a, b, c, new Point(i, y), Na, Nb, Nc), CalculateColor(a, b, c, new Point(i, y), preva, prevb, prevc)));
            }
        }

        private Color Count(int x, int y, double ks, double kd, int m)
        {
            Color mainColor = fill_color;
            if (loadTexture.Checked && texture_loaded)
            {
                mainColor = textureBmp.GetPixel(x % textureBmp.Width, y % textureBmp.Height);
            }
            Vector3 N = new Vector3(0, 0, 1);
            if (!staticVector.Checked && normal_map_loaded)
            {
                var color = new ColorVector(normalMap.GetPixel(x % normalMap.Width, y % normalMap.Height));
                N = new Vector3(color.R, color.G, color.B);
            }
            Vector3 L = new Vector3(0, 0, 1);
            if (!staticL.Checked)
            {
                L = new Vector3(light_source.X - x,y-  light_source.Y, light_source.Z);
            }
            Vector3 R = new Vector3(2 * DotProd(L, N) * N.x - L.x, 2 * DotProd(L, N) * N.y - L.y, 2 * DotProd(L, N) * N.z - L.z);
            R.Wersolize();
            int r = (int)Math.Round(kd * light_color.R * mainColor.R * cosin(N, L) + ks * light_color.R * mainColor.R * Math.Pow(cosin(V, R), m));
            int g = (int)Math.Round(kd * light_color.G * mainColor.G * cosin(N, L) + ks * light_color.G * mainColor.G * Math.Pow(cosin(V, R), m));
            int b = (int)Math.Round(kd * light_color.B * mainColor.B * cosin(N, L) + ks * light_color.B * mainColor.B * Math.Pow(cosin(V, R), m));
            r = r < 0 ? 0 : r;
            g = g < 0 ? 0 : g;
            b = b < 0 ? 0 : b;
            r = r > 255 ? 255 : r;
            g = g > 255 ? 255 : g;
            b = b > 255 ? 255 : b;
            return Color.FromArgb(r, g, b);
        }

        private Color CalculateColor(Point a, Point b, Point c, Point p, Color preva, Color prevb, Color prevc)
        {
            double R, G, B;

            double r, s, t;

            Point u, v, w;

            u = new Point(b.X - a.X, b.Y - a.Y);
            v = new Point(c.X - a.X, c.Y - a.Y);
            w = new Point(p.X - a.X, p.Y - a.Y);

            r = CrossProduct(v, w) / CrossProduct(v, u);
            t = CrossProduct(u, w) / CrossProduct(u, v);
            s = 1 - r - t;

            R = preva.R * s + prevb.R * r + prevc.R * t;
            G = preva.G * s + prevb.G * r + prevc.G * t;
            B = preva.B * s + prevb.B * r + prevc.B * t;

            R = R < 0 ? 0 : R;
            G = G < 0 ? 0 : G;
            B = B < 0 ? 0 : B;

            R = R > 255 ? 255 : R;
            G = G > 255 ? 255 : G;
            B = B > 255 ? 255 : B;

            return Color.FromArgb((int)R, (int)G, (int)B);

        }

        private Color HybridCount(int x, int y, double ks, double kd, int m, Vector3 N, Color mainColor)
        {
            Vector3 L = new Vector3(0, 0, 1);
            if (!staticL.Checked)
            {
                L = new Vector3(light_source.X - x, y - light_source.Y, light_source.Z);
            }
            Vector3 R = new Vector3(2 * DotProd(L, N) * N.x - L.x, 2 * DotProd(L, N) * N.y - L.y, 2 * DotProd(L, N) * N.z - L.z);
            R.Wersolize();
            int r = (int)Math.Round(kd * light_color.R * mainColor.R * cosin(N, L) + ks * light_color.R * mainColor.R * Math.Pow(cosin(V, R), m));
            int g = (int)Math.Round(kd * light_color.G * mainColor.G * cosin(N, L) + ks * light_color.G * mainColor.G * Math.Pow(cosin(V, R), m));
            int b = (int)Math.Round(kd * light_color.B * mainColor.B * cosin(N, L) + ks * light_color.B * mainColor.B * Math.Pow(cosin(V, R), m));
            r = r < 0 ? 0 : r;
            g = g < 0 ? 0 : g;
            b = b < 0 ? 0 : b;
            r = r > 255 ? 255 : r;
            g = g > 255 ? 255 : g;
            b = b > 255 ? 255 : b;
            return Color.FromArgb(r, g, b);
        }

        private Vector3 CalculateN(Point a, Point b, Point c, Point p, Vector3 Na, Vector3 Nb, Vector3 Nc)
        {
            double X, Y, Z;

            double r, s, t;

            Point u, v, w;

            u = new Point(b.X - a.X, b.Y - a.Y);
            v = new Point(c.X - a.X, c.Y - a.Y);
            w = new Point(p.X - a.X, p.Y - a.Y);

            r = CrossProduct(v, w) / CrossProduct(v, u);
            t = CrossProduct(u, w) / CrossProduct(u, v);
            s = 1 - r - t;

            X = Na.x * s + Nb.x * r + Nc.x * t;
            Y = Na.y * s + Nb.y * r + Nc.y * t;
            Z = Na.z * s + Nb.z * r + Nc.z * t;

            return new Vector3(X, Y, Z);
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
            //foreach (var tri in triangles_net)
            Bitmap tmp = new Bitmap(drawing_panel.Width, drawing_panel.Height);
            tmpPicture = new BmpPixelSnoop(tmp);
            Parallel.ForEach(triangles_net, (Polygon tri) =>
           // foreach (var tri in triangles_net)
            {
                 if (!moving)
                 {

                     if (aproximate.Checked)
                         FillFigureAprox(tri, Ks, Kd, M);
                     else if (hybrid.Checked)
                         FillFigureHybrid(tri, Ks, Kd, M);
                     else
                         FillFigure(tri, Ks, Kd, M);

                 }
             });
            tmpPicture.Dispose();
            e.Graphics.DrawImage(tmp, 0, 0);
            tmp.Dispose();
            foreach (var tri in triangles_net)
                foreach (var edge in tri.edges)
                {
                    DrawLine(edge, e.Graphics);
                }
            //foreach (var point in tri.vertices)
            //{
            //    DrawVertice(point.Get(), e.Graphics);
            //}

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
            if (moving && e.Location.Y >= 0)
            {
                currently_changed_vertex.Set(e.Location);
                var dp = triangles_net.FindAll((Polygon p) =>
               {
                   return p.vertices.Contains(currently_changed_vertex);
               });
                for (int i = 0; i < dp.Count; i++)
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
            drawing_panel.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                light_color = new ColorVectorREal(colorDialog1.Color);
                drawing_panel.Invalidate();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (selectObjectColor.Checked)
            {
                selectColor.Visible = true;
                openFile.Visible = false;
            }
            if (loadTexture.Checked)
            {
                selectColor.Visible = false;
                openFile.Visible = true;
            }
        }

        private void selectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fill_color = colorDialog1.Color;
                drawing_panel.Invalidate();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (staticVector.Checked)
            {
                openVectorTexture.Visible = false;
                normal_map_loaded = false;
            }
            if (loadVectorTexture.Checked)
            {
                openVectorTexture.Visible = true;
            }
        }

        private void ksSlider_Scroll(object sender, EventArgs e)
        {
            if (manual.Checked)
            {
                Ks = (double)ksSlider.Value / 100;
                drawing_panel.Invalidate();
            }
        }

        private void kdSlider_Scroll(object sender, EventArgs e)
        {
            if (manual.Checked)
            {
                Kd = (double)kdSlider.Value / 100;
                drawing_panel.Invalidate();
            }
        }

        private void mSlider_Scroll(object sender, EventArgs e)
        {
            if (manual.Checked)
            {
                M = mSlider.Value;
                drawing_panel.Invalidate();

            }
        }

        private void staticL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "image(.png,.jpg)|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var texture = new Bitmap(dialog.FileName);
                textureBmp = new BmpPixelSnoop(texture.Clone(new Rectangle(0, 0, texture.Width, texture.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
            }
            texture_loaded = true;
            drawing_panel.Invalidate();
        }

        private void openVectorTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "image(.png,.jpg)|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var texture = new Bitmap(dialog.FileName);
                normalMap = new BmpPixelSnoop(texture.Clone(new Rectangle(0, 0, texture.Width, texture.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
            }
            normal_map_loaded = true;
            drawing_panel.Invalidate();
        }

        private void drawing_panel_SizeChanged(object sender, EventArgs e)
        {
            radius = drawing_panel.Height / 5;
            center_point = new Point((int)drawing_panel.Width / 2, (int)drawing_panel.Height / 2);
            CreateNet(NetSize, NetSize);
            drawing_panel.Invalidate();
        }

        private void RandomL_CheckedChanged(object sender, EventArgs e)
        {
            radius = drawing_panel.Height / 5;
            center_point = new Point((int)drawing_panel.Width / 2, (int)drawing_panel.Height / 2);
            if (RandomL.Checked)
            {
                timer1.Interval = 100;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                drawing_panel.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveLightSource();
            drawing_panel.Invalidate();
        }

        private void loadTexture_CheckedChanged(object sender, EventArgs e)
        {
            if (!loadTexture.Checked)
            {
                texture_loaded = false;
            }
        }

        private void full_CheckedChanged(object sender, EventArgs e)
        {
            drawing_panel.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            NetSize = trackBar1.Value;
            LabelSize.Text = NetSize.ToString();
            CreateNet(NetSize, NetSize);
            drawing_panel.Invalidate();
        }
    }
}
