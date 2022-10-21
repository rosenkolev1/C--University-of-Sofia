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

namespace CalculatorSample
{
    public enum Operation
    {
        NO_OP,
        ADDITION,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private double inputFirstNumber;
        private double inputSecondNumber;
        private Operation operation;
        private double resultOfCompute;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            inputSecondNumber = Convert.ToDouble(txt.Text);
            resultOfCompute = 0;
            switch(operation)
            {
                case Operation.NO_OP:
                    break;
                case Operation.ADDITION:
                    resultOfCompute = inputFirstNumber + inputSecondNumber;
                    break;
                case Operation.DIVISION:
                    resultOfCompute = (inputSecondNumber == 0) ?
                        double.MaxValue : inputFirstNumber / inputSecondNumber;
                    break;
                case Operation.MULTIPLICATION:
                    resultOfCompute = inputFirstNumber + inputSecondNumber;
                    break;
                default:
                    break;
            }
            txt.Text = "" + resultOfCompute;
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            inputFirstNumber = Convert.ToDouble(txt.Text);
            operation = ((Button)sender).Content.ToString() switch
            {
                "+" => Operation.ADDITION,
                "-" => Operation.SUBTRACTION,
                "*" => Operation.MULTIPLICATION,
                @"\" => Operation.DIVISION,
                _ => Operation.NO_OP
            };
            
            txt.Text = "0";
        }

        private void BtnCA_Click(object sender, RoutedEventArgs e)
        {
            inputSecondNumber = inputFirstNumber = 0;
            operation = Operation.NO_OP;
        }

        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
