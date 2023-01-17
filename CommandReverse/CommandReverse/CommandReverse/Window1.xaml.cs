using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandReverse
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
        public Window1()
        {
            InitializeComponent();

            btnReverse.Command = ReverseCommand.Reverse;
            btnReverse.CommandTarget = txtBox;
            btnReverse.Content = ((RoutedUICommand)(btnReverse.Command)).Text;

            CommandBinding binding = new CommandBinding();
            binding.Command     = ReverseCommand.Reverse;
            binding.Executed   += ReverseString_Executed;
            binding.CanExecute += ReverseString_CanExecute;

            CommandBinding changeBackgroundBinding = new CommandBinding();
            changeBackgroundBinding.Command = BackgroundChangeCommand.Change;
            changeBackgroundBinding.Executed += ChangeBackground_Executed;
            changeBackgroundBinding.CanExecute += ChangeBackground_CanExecute;

            CommandBindings.Add( binding );
            CommandBindings.Add(changeBackgroundBinding);
        }

        public void ChangeBackground_Executed(object sender, ExecutedRoutedEventArgs e )
        {
            if (txtBox.Text.Length > 8) txtBox.Background = Brushes.Green;
            else if (txtBox.Text.Length < 8) txtBox.Background = Brushes.Red;

        }

        public void ChangeBackground_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void ReverseString_Executed( object sender, ExecutedRoutedEventArgs args )
        {
            char[] temp = txtBox.Text.ToCharArray();
            Array.Reverse(temp);
            txtBox.Text = new string(temp);
        }

        public void ReverseString_CanExecute( object sender, CanExecuteRoutedEventArgs args )
        {
            args.CanExecute = txtBox.Text.Length > 0;
        }

        private void shit_KeyDown(object sender, KeyEventArgs e)
        {
            char[] temp = txtBox.Text.ToCharArray();
            Array.Reverse(temp);
            txtBox.Text = new string(temp);
        }
    
    }
}
