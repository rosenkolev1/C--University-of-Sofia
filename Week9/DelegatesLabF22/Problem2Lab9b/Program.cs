using Problem2Lab9b;
using System.ComponentModel;
using System.Security.AccessControl;

internal class Program
{
    private static void Main(string[] args)
    {
         var clock = new AlarmClock();
        clock.Alarm += AlarmRingHandler1!;
        clock.Alarm += AlarmRingHandlerBeep!;
        clock.PropertyChanged += RingTimeChanged!;
        clock.Rings = 5;
        clock.RingTime = 2000;
        clock.Start();


    }

    public static void AlarmRingHandler1(object sender,
                                         EventArgs e)
    {
        Console.WriteLine($"Alarm rings: { ((AlarmEventArgs)e).NRings}");
    }

    public static void AlarmRingHandlerBeep(object sender,
                                     EventArgs e)
    {
        Console.Beep();
         
    }

    public static void RingTimeChanged(object sender,
                                 PropertyChangedEventArgs e)
    {
        Console.WriteLine($"Ringtime updated: {e.PropertyName} ");
    }
}