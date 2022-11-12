using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib
{
    public class Point
    {

        #region Data members
        private int[] coords;
        private static char[] indexes = { 'x', 'y' };

        #endregion

        #region Constructors
        /// <summary>
        /// General- purpose constructor
        /// </summary>
        /// <param name="coords"></param>
        public Point(int[] coords)
        {
            Coords = coords;

        }

        /// <summary>
        /// Default constructior
        /// </summary>
        public Point() : this(new int[2])
        {

        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="point"></param>
        public Point(Point point) : this(point.coords)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        #endregion

        #region Properties
        public int[] Coords // reference mutable type
        {
            get
            {  // Single Responsibility principle
                return new int[] { coords[0], coords[1] };
            }
            set
            {
                coords = value != null && value.Length == 2 ?
                    new int[] { value[0], value[1] } : new int[2];
            }
        }

        public int this[char index]
        {
            get
            {
                /* return the specified index here */
                if (indexes.Contains(index))
                {
                    var selection = index switch
                    {
                        char ind when ind == indexes[0] => coords[0],
                        char ind when ind == indexes[1] => coords[1],

                    };
                    return selection;
                }
                else
                    return int.MaxValue;
            }
            set
            { /* set the specified index to value here */
                if (indexes.Contains(index) && value >= 0)
                {

                    switch (index)
                    {
                        case 'x':
                            coords[0] = value;
                            break;
                        case 'y':
                            coords[1] = value;
                            break;

                    };

                }
                else
                Console.WriteLine("Wrong coords value ...");
            }
        }
        #endregion

        public override string ToString()
        {
            return String.Format($"Point: {string.Join(", ", coords)}"); 
        }
    }
}
