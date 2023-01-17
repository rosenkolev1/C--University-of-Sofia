using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2Lab9b
{
    public class AlarmClock : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler? Alarm;

        private int rings;
        private int rungTime;


        public int RingTime
        {
            get { return rungTime; }
            set { rungTime = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(RingTime)));
            }
        }

        public int Rings
        {
            get { return rings; }
            set { rings = value; }
        }

        protected void OnAlarm(AlarmEventArgs e)
        {

            //Invoke the event handler.
            Alarm?.Invoke(this, e);

        }

        // event invoking method
        public void Start()
        {
            Thread.Sleep(RingTime);
            for (; ; )
            {
                rings--;
                if (rings < 0)
                {
                    break;
                }

                else
                {
                    Thread.Sleep(1000);
                    AlarmEventArgs e = new AlarmEventArgs(rings);
                    OnAlarm(this, e);
                }
            }
        }

        protected virtual void OnAlarm(object sender, EventArgs args)
        {
            Alarm?.Invoke(this,args);
        }
    }
}

