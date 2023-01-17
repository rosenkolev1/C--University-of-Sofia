using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public struct Point : Comparable
    {
        #region Datamembers and constyructor
        public double X;
        public double Y;
        public double Z;

        private static readonly string[] indexes = { "x", "y", "z" };
        public Point(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        } 
        #endregion

        #region Properties
        public double? this[string index]
        {
            get
            { /* return the specified index here */

                return index switch
                {
                    string s when s == indexes[0] => X,
                    string s when s == indexes[1] => Y,
                    string s when s == indexes[2] => Z,
                    _ => null,
                };
            }
        }
        #endregion


        #region Utility methods

        public static Point operator +(Point v1, Point v2)
        {
            return new Point (v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public static GreaterThan GetSize
        {
            get
            {
                return GetSizeOf;
            }
        }
        private static bool GetSizeOf(Comparable obj1, Comparable obj2)
        {
            return obj1.SizeOf() > obj2.SizeOf();
        }
        double Comparable.SizeOf()
        {
            return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        }
        #endregion

        public override string ToString()
        {
            return $"P [{X:0.00},{Y:0.00},{Z:0.00}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y &&
                   Z == point.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}
