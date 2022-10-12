using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        /// <summary>
        /// Create time based on hours, minutes and seconds
        /// </summary>
        /// <param name="hours">Store hours value</param>
        /// <param name="minutes">Store minutes value</param>
        /// <param name="seconds">Store seconds value</param>
        public Time(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public Time(Time time)
        {
            
        }

        public Time()
        {
            
        }
    }
}