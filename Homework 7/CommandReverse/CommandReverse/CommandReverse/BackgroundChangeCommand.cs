using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandReverse
{
    public class BackgroundChangeCommand
    {

        public static RoutedUICommand Change { get; set; }

        static BackgroundChangeCommand()
        {
            InputGestureCollection gestures = new InputGestureCollection();

            gestures.Add(new KeyGesture(Key.Enter));

            Change = new RoutedUICommand
               ("Change background color based on word length", "ChangeBackgroundColor", typeof(BackgroundChangeCommand), gestures);

            //Change.T
        }
    }
}
