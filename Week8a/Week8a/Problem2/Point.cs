using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public struct Point : Comparable
    {
        #region Data members
        public double X;
        public double Y;
        public double Z;
        private static string[] indexes = { "x", "y", "z" }; 
	#endregion

        #region Constructor
		public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        #endregion

        #region Indexer
        public double this[string index]
        {
            get
            { /* return the specified index here */
                if (indexes.Contains(index))
                {
                    var selection = index switch
                    {
                        string i1 when i1 == indexes[0] => X,
                        string i1 when i1 == indexes[1] => Y,
                        string i1 when i1 == indexes[2] => Z
                    };
                    return selection;
                }
                else
                {
                    return double.NaN;
                }
            }

        } 
        #endregion

        #region Utility methods
        public static bool GetSizeOf(Comparable obj1, Comparable obj2)
        {
            return obj1.SizeOf() > obj2.SizeOf();
        }
        public static GreaterThan Method
        {
            get => Point.GetSizeOf;
        }
        double Comparable.SizeOf()
        {
            return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        } 
        #endregion


        public static Point operator +(Point p1, Point p2)
        {

            return new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }


        public override string ToString()
        {
            return $"X={X:0.00},Y={Y:0.00},Z={Z:0.00} ";
        }

        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y &&
                   Z == point.Z;
        }
        public static bool operator == (Point o1, object o2)
        {
            return o1.Equals(o2);   
        }

        public static bool operator !=(Point o1, object o2)
        {
            return !(o1.Equals(o2));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

    }
}
