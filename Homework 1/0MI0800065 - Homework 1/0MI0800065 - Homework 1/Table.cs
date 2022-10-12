using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _0MI0800065___Homework_1
{
    internal class Table
    {
        private double argumentStartValue;
        private double argumentEndValue;
        private int argumentStepsCount;

        public double ArgumentStartValue
        {
            get => argumentStartValue;
            private set
            {
                this.argumentStartValue = value;
            }
        }
        public double ArgumentEndValue
        {
            get => argumentEndValue;
            private set
            {
                argumentEndValue = value;
            }
        }
        public int ArgumentStepsCount
        {
            get => argumentStepsCount;
            private set
            {
                if (value <= 0) argumentStepsCount = 1;
                else argumentStepsCount = value;
            }
        }

        private double calculateFunction(double argument)
        {
            double functionResult = Math.Pow(argument - 2, 2) / (Math.Pow(argument, 2) + 1);
            return functionResult;
        }

        public Table(double argumentStartValue, double argumentEndValue, int argumentStepsCount)
        {
            this.ArgumentStartValue = argumentStartValue;
            this.ArgumentEndValue = argumentEndValue;
            this.ArgumentStepsCount = argumentStepsCount;
        }

        public void MakeTable()
        {
            double argumentStep = (this.ArgumentEndValue - this.ArgumentStartValue) / this.ArgumentStepsCount;
            int stepsMadeBeforeReturnPrompt = 0;

            Console.WriteLine("|{0,11}|{1,11}|", "x     ", "f(x)   ");
            Console.WriteLine(new string('-', 25));
            double x = this.ArgumentStartValue;

            do
            {
                double functionResult = calculateFunction(x);
                stepsMadeBeforeReturnPrompt++;

                string output = string.Format($"|{x,11:0.0000}|{functionResult,11:0.0000}|");
                Console.Write(output);

                if (stepsMadeBeforeReturnPrompt == 20)
                {
                    stepsMadeBeforeReturnPrompt = 0;
                    Console.Write("  Press return to continue...");
                    do
                    {
                        string input = Console.ReadLine();

                        if (input == "return") break;
                    } while (true);
                }
                else Console.WriteLine();

                if (argumentStep == 0) break;
                x += argumentStep;

                //This is used because, due to rounding errors, sometimes the argument never reaches the end value because the
                //argumentStep makes it go over the argumentEndValue
                if(!(argumentStep > 0 ? x <= this.ArgumentEndValue : x >= this.ArgumentEndValue) && 
                    Math.Abs((x - argumentStep) - this.ArgumentEndValue) >= 0.0001)
                {
                    x = this.ArgumentEndValue;
                    continue;
                }
            }
            while ((argumentStep > 0 ? x <= this.ArgumentEndValue : x >= this.ArgumentEndValue));
            
        }
    }
}
