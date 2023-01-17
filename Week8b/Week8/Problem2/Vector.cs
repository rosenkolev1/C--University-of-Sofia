using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public delegate bool GreaterThan(Comparable obj1, Comparable obj2);
    public struct  Vector : Comparable
    {
        #region Datamembers and Constructor
        private Point sPoint;
        private Point ePoint;
        private static readonly int[] indexes = { 1, 2 };
        public Vector(Point p1, Point p2)
        {

            sPoint = p1;
            ePoint = p2;
        } 
        #endregion

        #region Properties
        public Point? this[int index]
        {
            get
            { /* return the specified index here */

                return index switch
                {
                    int s when s == indexes[0] => sPoint,
                    int s when s == indexes[1] => ePoint,
                    _ => null,
                };
            }
        }
        #endregion

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.sPoint + v2.sPoint,v1.ePoint + v2.ePoint );
        }

        public static bool operator ==(Vector left, Vector right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector left, Vector right)
        {
            return !(left == right);
        }

        #region Utility methods

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
            var dx = sPoint.X - ePoint.X;
            var dy = ePoint.Y - sPoint.Y;
            var dz = ePoint.Z - sPoint.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);

        } 
        #endregion
        public override string ToString()
        {
            return $"V [{sPoint}, {ePoint}]";
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector vector &&
                   EqualityComparer<Point>.Default.Equals(sPoint, vector.sPoint) &&
                   EqualityComparer<Point>.Default.Equals(ePoint, vector.ePoint);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(sPoint, ePoint);
        }
    }
}
