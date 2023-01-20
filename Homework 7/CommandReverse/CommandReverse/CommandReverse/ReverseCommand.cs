using System;
using System.Windows.Input;    // Required

namespace CommandReverse
{
   public class ReverseCommand
   {
      private static RoutedUICommand reverse;

      public static RoutedUICommand Reverse
      {
         get { return reverse; }
      }

      static ReverseCommand()
      {
         reverse = new RoutedUICommand
            ( "Reverse", "Reverse", typeof(ReverseCommand), null);
      }
   }
}
