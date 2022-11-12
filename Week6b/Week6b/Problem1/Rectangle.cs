using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Rectangle
    {
        #region Data members
        private double width;
        private double height;
        private Point leftLowerPoint;
        public delegate double CompareBy(Rectangle r);

        private static char[] indexes = { 'w', 'h', 'x', 'y' };
        

        #endregion

        #region Constructors
        public Rectangle(double width, double height, Point leftLowerPoint)
        {
            Width = width;
            Height = height;
            LeftLowerPoint = leftLowerPoint;
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
        public double this[char index]
        {
            get
            { /* return the specified index here */
                if (indexes.Contains(index))
                {

                    var selection =
                        index switch
                        {
                            char ind when ind == 'x' => leftLowerPoint['x'],
                            char ind when ind == 'y' => leftLowerPoint['y'],
                            char ind when ind == 'w' => width,
                            char ind when ind == 'h' => height,
                        };
                    return selection;
                }
                else
                    return double.MinValue;
            }
            set
            { /* set the specified index to value here */
                if (indexes.Contains(index))
                {
                    switch (index)
                    {
                        case 'x':
                            leftLowerPoint['x'] = (int)(value >= 0 ? value : 0);
                            break;
                        case 'y':
                            leftLowerPoint['y'] = (int)(value >= 0 ? value : 0);
                            break;
                        case 'w':
                            Width = value;
                            break;
                        case 'h':
                            Height = value;
                            break;
                        default:
                            break;
                    }
                }

            }
        }
        public Point LeftLowerPoint
        {
            get
            {
                return new Point(leftLowerPoint);
            }
            set
            {
                leftLowerPoint = value != null ? new Point(value) :
                    new Point();
            }
        }

        public double Height
        {
            get { return height; }
            set { height = value >= 0 ? value : 0; ; }
        }

        public double Width
        {
            get { return width; }
            set { width = value >= 0 ? value : 0; }
        }
        #endregion

        public static double Area ( Rectangle r)
        {
            return r.height * r.width;
        }

        public static double Diagonal(Rectangle r)
        {
            var diag = Math.Sqrt(r.width * r.width + r.height * r.height);
            return diag;
        }


        public static IEnumerable<Rectangle> SortBy( List<Rectangle> list,
                                                    CompareBy compare)
        {
            return list.OrderBy(x => compare(x)  );
        }
        public override string ToString()
        {
            return String.Format($"R : W {width}, H {height}," +
                           $" {leftLowerPoint}");
        }
    }
}
