using ClockLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace AlarmClockApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private (int hour, int minute, int second) startTime;
        private (int hour, int minute, int second) currentTime;

        private Random rand;
        private double ringAfter;

        public MainWindow()
        {
            InitializeComponent();

            Binding sliderBinding = new Binding("Value");
            sliderBinding.Source = slider;
            sliderBinding.StringFormat = "0.0";

            sliderBox.SetBinding(TextBox.TextProperty, sliderBinding);

            this.ringAfter = 0;
            this.rand = new Random();

            //this.digitalClock.ClockStarted += OnClockStarted;
            //this.digitalClock.TimeUpdated += OnTimeUpdated;

        }

        private void OnClockStarted(object sender, EventArgs e)
        {
            var clockTickArgs = (ClockTickArgs)e;
            this.startTime = clockTickArgs.ClockTick;

            this.ringAfter = double.Parse(sliderBox.Text);

            this.findDistinctBox.Text = $"{this.startTime.hour:00}:{this.startTime.minute:00}:{this.startTime.second:00}";
        }

        private void OnTimeUpdated(object sender, EventArgs e)
        {
            var clockTickArgs = (ClockTickArgs)e;
            this.currentTime = clockTickArgs.ClockTick;

            if (this.currentTime.second % 2 == 0)
            {
                this.beepIndicatorBox.Text += $"{this.rand.Next(10, 51)} ";
            }

            var currentTimeSpan = new TimeSpan(this.currentTime.hour, this.currentTime.minute, this.currentTime.second);
            var startTimeSpan = new TimeSpan(this.currentTime.hour, this.currentTime.minute, this.currentTime.second);

            double minutesSinceStart = currentTimeSpan.Subtract(startTimeSpan).Seconds / 60.0;

            if (minutesSinceStart >= ringAfter)
            {
                this.labelBeepIndicator.Content = "Beep Indicator: Start ringing";
                SystemSounds.Beep.Play();
            }
        }

        private void ButtonFindDistinct_Click(object sender, RoutedEventArgs e)
        {
            var allNumbers = this.beepIndicatorBox.Text.Split(" ").Where(x => int.TryParse(x, out _)).Select(x => int.Parse(x));

            this.findDistinctBox.Text += $"\n{string.Join(' ', allNumbers.Distinct().ToList())}";

            this.findDistinctBox.Text += $"\nFrequency\n";

            string distinctFrequency = string.Join("\n", allNumbers
                .GroupBy(x => x)
                .Select(x => $"Number:{x.Key} found {x.Count()} times.").ToList());

            this.findDistinctBox.Text += distinctFrequency;
        }
    }
}
