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
using System.Windows.Xps;

namespace CalculatorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Data members

        private double inputFirstNumber;
        private double inputSecondNumber;
        private double result;

        private enum Operation { NO_OPERATION, ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION }
        private Operation operation;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            operation = Operation.NO_OPERATION;
        }

        #region Event handler methods
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string digit = ((Button)sender).Content.ToString();// the text dsiplayed by the button 
            if (TxtInput.Text == "0")
            {
                TxtInput.Text = digit;
            }
            else
            {
                if (digit == "," && TxtInput.Text.Contains(",")) return;
                TxtInput.Text += digit;
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            //  inputFirstNumber = Convert.ToDouble(TxtInput.Text);

            if (!double.TryParse(TxtInput.Text, out inputFirstNumber))
            {
                MessageBox.Show("Wrong input. Enter a valid decimal number.");
                TxtInput.Text = "0";
                return;
            }

            operation = ((Button)sender).Content.ToString() switch
            {
                "+" => Operation.ADDITION,
                "-" => Operation.SUBTRACTION,
                "x" => Operation.MULTIPLICATION,
                "/" => Operation.DIVISION,
                _ => Operation.NO_OPERATION
            };

            TxtInput.Text = "0";

        }

        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TxtInput.Text, out inputSecondNumber))
            {
                MessageBox.Show("Wrong input. Enter a valid decimal number.");
                TxtInput.Text = "0";
                return;
            }

            switch (operation)
            {
                case Operation.ADDITION:
                    result = inputFirstNumber + inputSecondNumber;
                    break;
                case Operation.SUBTRACTION:
                    result = inputFirstNumber - inputSecondNumber;
                    break;
                case Operation.MULTIPLICATION:
                    result = inputFirstNumber * inputSecondNumber;
                    break;
                case Operation.DIVISION:
                    result = inputSecondNumber == 0 ?
                        double.MaxValue : inputFirstNumber / inputSecondNumber;
                    break;
            }

            operation = Operation.NO_OPERATION;
            TxtInput.Text = "" + result;
        }

        private void btnOff_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0); // Quit the application
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            TxtInput.Text = "0";
        }

        private void btnCA_Click(object sender, RoutedEventArgs e)
        {
            TxtInput.Text = "0";
            operation = Operation.NO_OPERATION;
        } 
        #endregion
   
    }
}
