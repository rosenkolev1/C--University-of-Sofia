using Problem1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1Test
{
    public static class RectangleExtensions
    {
        public static double Perimeter (this Rectangle r)
        {
            return 2 * (r.Width + r.Height);
        }
        public static bool IsSquare(this Rectangle r)
        {
            return  r.Width == r.Height;
        }

    }
}
