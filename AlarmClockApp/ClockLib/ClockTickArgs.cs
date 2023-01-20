using System;

namespace ClockLib
{
    public class ClockTickArgs : EventArgs
    {
        public (int hour, int minute, int second) ClockTick;

        public ClockTickArgs(int hour, int minute, int second)
        {
            ClockTick = (hour, minute, second);
        }
    }
}
