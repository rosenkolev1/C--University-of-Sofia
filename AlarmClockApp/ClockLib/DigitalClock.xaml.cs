using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClockLib
{
    /// <summary>
    /// Interaction logic for DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock : UserControl
    {
        public event EventHandler ClockStarted;
        public event EventHandler TimeUpdated;

        private DispatcherTimer timer;

        public DigitalClock()
        {
            InitializeComponent();
            this.timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, UpdateTime, Dispatcher.CurrentDispatcher);
            this.timer.Stop();
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            clockBox.Text = "00:00:00";
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            this.timer.Start();

            ClockTickArgs clockTickArgs = new ClockTickArgs(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            this.ClockStarted?.Invoke(sender, clockTickArgs);
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            this.timer.Stop();
        }

        public void UpdateTime(object sender, EventArgs e)
        {
            ClockTickArgs clockTickArgs = new ClockTickArgs(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            clockBox.Text = $"{clockTickArgs.ClockTick.hour:00}:{clockTickArgs.ClockTick.minute:00}:{clockTickArgs.ClockTick.second:00}";

            this.TimeUpdated?.Invoke(sender, clockTickArgs);
        }
    }
}
