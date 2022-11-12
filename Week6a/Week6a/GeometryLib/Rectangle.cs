using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib
{
    public class Rectangle
    {
        #region Data members
        private double width;
        private double height;
        private Point? leftLowerPoint;
        private static char[] indexes = { 'x', 'y', 'w', 'h' };
        public readonly string R_ID;
        private static int cnt = 1;

        public delegate double CompareBy(Rectangle r);

        #endregion

        #region Constructors
        public Rectangle(double width, double height, Point? leftLowerPoint)
        {
            Width = width;
            Height = height;
            LeftLowerPoint = leftLowerPoint!;
            R_ID = string.Format("R{0:D6}", cnt++);
            // R_ID = string.Format("R{0:000000}", cnt++);
            // R_ID = string.Format($"R{(cnt++):000000}" );
        }

        public Rectangle() : this(0, 0, new Point())
        {
        }
        public Rectangle(Rectangle rectangle)
        : this(rectangle.width, rectangle.height, rectangle.leftLowerPoint)
        {
        }
        #endregion

        #region Properties
        public Point? LeftLowerPoint
        {
            get { return new Point(leftLowerPoint!); }
            set
            {
                leftLowerPoint = value != null ?
                                        new Point(value) :
                                        new Point();
            }
        }


        public double Height
        {
            get { return height; }
            set { height = value >= 0 ? value : 0; }
        }

        public double Width
        {
            get { return width; }
            set { width = value >= 0 ? value : 0; }
        }

        public double this[char index]
        {
            get
            { /* return the specified index here */
                if (indexes.Contains(index))
                {
                    var selection =
                        index switch
                        {
                            char ind when ind == 'x'
                                        => leftLowerPoint['x'],
                            char ind when ind == 'y'
                                        => leftLowerPoint['y'],
                            char ind when ind == 'w'
                                        => width,
                            char ind when ind == 'h'
                                        => height

                        };
                    return selection;
                }
                else
                    return double.MaxValue;


            }
            set
            { /* set the specified index to value here */
                if (indexes.Contains(index))
                {
                    switch (index)
                    {
                        case 'x':
                            leftLowerPoint!['x'] = (int)(value);
                            break;
                        case 'y':
                            leftLowerPoint!['y'] = (int)(value);
                            break;
                        case 'w':
                            width = (value >= 0 ? value : 0);
                            break;
                        case 'h':
                            height = (value >= 0 ? value : 0);
                            break;
                    }
                }


            }
        } 
        #endregion

        public static double Area(Rectangle r)
        {
            double area = 0;

            var w = r['w'];
            var h = r.height;
            area = w * h;

            return area;
        }
        public static double Diagonal(Rectangle r)
        {
            double diag = 0;

            var w = r['w'];
            var h = r.height;
            diag = Math.Sqrt(w * w + h * h);

            return diag;
        }


        public static IEnumerable<Rectangle> SortBy(List<Rectangle> list,
                                       CompareBy order)
        {
            var sortedList = list.OrderBy(x => order(x));
            return sortedList;  
        }
        public override string ToString()
        {
            return String.Format($"{R_ID}: {leftLowerPoint}, " +
                                 $"W:{width}, H: {height} " +
                                 $"D:{Rectangle.Diagonal(this):F2}");
        }
    }
}
