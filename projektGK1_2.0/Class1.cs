using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektGK1_2._0
{
    struct Vector3
    {
        public double x, y, z;

        public Vector3(double a, double b, double c)
        {
            x = a;
            y = b;
            z = c;
            Wersolize();
        }

        public void Wersolize()
        {
            double len = Math.Sqrt(x * x + y * y + z * z);
            x /= len;
            y /= len;
            z /= len;
        }
    }

    struct ColorVector
    {
        public double R, G, B;

        public ColorVector(Color c)
        {
            R = ((double)c.R / 128) - 1;
            G = ((double)c.G / 128) - 1;
            B = ((double)c.B / 255);
        }

        public Color ToColor()
        {
            return Color.FromArgb((int)Math.Floor((R + 1) * 127), (int)Math.Floor((G + 1) * 127), (int)Math.Floor((B + 1) * 127));
        }
    }
}
