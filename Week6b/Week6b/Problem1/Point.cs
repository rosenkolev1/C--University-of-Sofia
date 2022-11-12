using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Point
    {
        private int[] coords;
        private static char[] indexes = { 'x', 'y' };

        private readonly string PID;
        private static int cnt = 1;

        #region Constructors
        /// <summary>
        /// General- purpose constructor
        /// </summary>
        /// <param name="coords"></param>
        public Point(int[] coords)
        {
            Coords = coords;
            PID = string.Format($"{(cnt++):D6}");

        }
        /// <summary>
        /// Default constructor
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
        #endregion

        #region Properties
        public int[] Coords
        {
            get
            {
                return new int[] { coords[0], coords[1] };
            }
            set
            {
                coords = value != null && value.Length == 2 ?
                         new int[] { value[0], value[1] } :
                         new int[2];
            }
        }

        public int this[char index]
        {
            get
            {
                if (indexes.Contains(index)) // check for valid index
                {
                    var selection = index switch
                    {
                        char ind when ind == 'x' => coords[0],
                        char ind when ind == 'y' => coords[1]
                    };
                    return selection;

                }
                else
                    return int.MinValue;
                /* return the specified index here */
            }
            set
            { /* set the specified index to value here */
                if (indexes.Contains(index))  // check for valid index
                {
                    switch (index)
                    {
                        case 'x':
                            coords[0] = value >= 0 ? value : 0;
                            break;
                        case 'y':
                            coords[1] = value >= 0 ? value : 0;
                            break;
                    };
                }
            }
        }
        #endregion

        public override string ToString()
        {
            return string.Format($"P {PID} [ {string.Join(", ", coords)}]");
        }
    }
}
