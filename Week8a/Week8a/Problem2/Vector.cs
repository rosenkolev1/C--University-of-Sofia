using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Problem2
{
    public struct Vector : Comparable
    {
        public Point SPoint { get; private set; }
        public Point EPoint { get; private set; }
        private static string[] indexes = { "a", "b" };
        public Vector(Point sPoint, Point ePoint)
        {
            SPoint = sPoint;
            EPoint = ePoint;
        }
        #region Indexer
        public Point this[string index]
        {
            get
            { /* return the specified index here */
                if (indexes.Contains(index))
                {
                    var selection = index switch
                    {
                        string i1 when i1 == indexes[0] => SPoint,
                        string i1 when i1 == indexes[1] => EPoint,
                        _ => new Point()
                    };
                    return selection;
                }
                else
                {
                    return new Point();
                }
            }

        }
        #endregion

        #region Utility methods
        /// <summary>
        /// Return Vector length
        /// </summary>
        /// <returns></returns>
        double Comparable.SizeOf()
        {
            var dx = SPoint.X - EPoint.X;
            var dy = SPoint.Y - EPoint.Y;
            var dz = SPoint.Z - EPoint.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static bool GetSizeOf(Comparable obj1, Comparable obj2)
        {
            return obj1.SizeOf() > obj2.SizeOf();
        }

        public static GreaterThan Method
        {
            get => Vector.GetSizeOf;
        }

        #endregion



        /// <summary>
        /// To string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"V [{SPoint}, {EPoint}]";
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector vector &&
                   EqualityComparer<Point>.Default.Equals(SPoint, vector.SPoint) &&
                   EqualityComparer<Point>.Default.Equals(EPoint, vector.EPoint);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SPoint, EPoint);
        }

        public static bool operator ==(Vector left, Vector right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector left, Vector right)
        {
            return !(left == right);
        }


    }
}

