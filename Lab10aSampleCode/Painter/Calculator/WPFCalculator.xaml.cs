﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WPFCalculator : Window
    {
        private double inputFirstNumber; // left operand
        private double inputSecondNumber; // right operand
        private double resultOfCompute; // right operand
        private enum Operation { NO_OP, ADDITION, SUBTRACTION, DIVISION, MULTIPLICATION }
        private Operation operation; // currently selected artihmetic operation

        public WPFCalculator()
        {
            InitializeComponent();
            operation = Operation.NO_OP;

        }

        private void DigitalButton_Click(object sender, RoutedEventArgs e)
        {
            string digit = ((Button)sender).Content.ToString();
            if (txtInput.Text == "0")
            {
                txtInput.Text = digit;
            }
            else
            {
                if (digit == "," && txtInput.Text.Contains(',')) return;
                txtInput.Text = string.Format($"{txtInput.Text}{digit}");
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            //inputFirstNumber = Convert.ToDouble(txtInput.Text);

            if (!Double.TryParse(txtInput.Text, out inputFirstNumber))
            {
                MessageBox.Show("Wrong input!");
                txtInput.Text = "0";
                return;
            }
            operation = ((Button)sender).Content.ToString() switch
            {
                "+" => Operation.ADDITION,
                "-" => Operation.SUBTRACTION,
                "x" => Operation.MULTIPLICATION,
                @"/" => Operation.DIVISION,
                _ => Operation.NO_OP
            };

            txtInput.Text = "0";

        }

        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            inputSecondNumber = Convert.ToDouble(txtInput.Text);
            resultOfCompute = 0;
            switch (operation)
            {
                case Operation.NO_OP:
                    break;
                case Operation.ADDITION:
                    resultOfCompute = inputFirstNumber + inputSecondNumber;
                    break;
                case Operation.SUBTRACTION:
                    resultOfCompute = inputFirstNumber - inputSecondNumber;
                    break;
                case Operation.DIVISION:
                    resultOfCompute = (inputSecondNumber == 0) ?
                       double.MaxValue : inputFirstNumber / inputSecondNumber;
                    break;
                case Operation.MULTIPLICATION:
                    resultOfCompute = inputFirstNumber * inputSecondNumber;
                    break;
                default:
                    break;
            }
            txtInput.Text = "" + resultOfCompute;
            operation = Operation.NO_OP;
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
        }

        private void btnCA_Click(object sender, RoutedEventArgs e)
        {
            inputSecondNumber = inputFirstNumber = 0;
            operation = Operation.NO_OP;
        }

        private void btnOff_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}
