using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Data members
        private const string defaultInputFormat = "{0}{1}{2}";
        private string inputFormat = defaultInputFormat; //Format for the text in the textbox
        private string inputFirstNumber = "0"; // left operand
        private string inputSecondNumber = ""; // right operand
        //private double resultOfCompute; // right operand
        private int currentNumber = 1;

        private Queue<SpecialOperation> SpecialOperationsAll = new Queue<SpecialOperation>();
        private Stack<SpecialOperation> SpecialOperationsFirst = new Stack<SpecialOperation>();
        private Stack<SpecialOperation> SpecialOperationsSecond = new Stack<SpecialOperation>();

        private enum PrimaryOperation { NO_OP, ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION }
        private enum SpecialOperation { EXP, SQRT, LOG, SIN, COS, ONEOVERX}
        private enum SpOpsScope { ALL, FIRST, SECOND}

        private IReadOnlyDictionary<PrimaryOperation, string> primaryOperationStrings = new Dictionary<PrimaryOperation, string>()
        {
            { PrimaryOperation.NO_OP, ""},
            { PrimaryOperation.ADDITION, "+"},
            { PrimaryOperation.SUBTRACTION, "-"},
            { PrimaryOperation.MULTIPLICATION, "*"},
            { PrimaryOperation.DIVISION, @"/"}           
        };

        private IReadOnlyDictionary<SpecialOperation, string> SpecialOperationtrings = new Dictionary<SpecialOperation, string>()
        {
            { SpecialOperation.EXP, "pow({0}, {2})"},
            { SpecialOperation.SQRT, "sqrt({0})"},
            { SpecialOperation.LOG, "log({0}, {2})"},
            { SpecialOperation.SIN, "sin({0})"},
            { SpecialOperation.COS, "cos({0})"},
            { SpecialOperation.ONEOVERX, "(1/({0}))"}
        };

        private IReadOnlyDictionary<SpOpsScope, string> spOpsScopeStrings = new Dictionary<SpOpsScope, string>()
        {
            { SpOpsScope.ALL, "All"},
            { SpOpsScope.FIRST, "1"},
            { SpOpsScope.SECOND, "2"}
        };

        private PrimaryOperation primaryOperation; // currently selected primary artihmetic operation
        private bool lockedPrimaryOperation = false;

        private SpOpsScope currentSpOpsScope = SpOpsScope.ALL;

        public string OperationString => primaryOperationStrings[primaryOperation];
        public string TextboxString => String.Format(inputFormat, inputFirstNumber, OperationString, inputSecondNumber);

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            primaryOperation = PrimaryOperation.NO_OP;

        }

        #region Event handler methods

        private void ChangeCalcInput()
        {
            txtInput.Text = TextboxString;
        }

        /// <summary>
        /// Process Digital button selection/Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitalButton_Click(object sender, RoutedEventArgs e)
        {
            string digit = ((Button)sender).Content.ToString();
            string currentNumberInput = currentNumber == 1 ? inputFirstNumber : inputSecondNumber;
            if (currentNumberInput == "" && digit == ".") return;
            else if (currentNumberInput == "0")
            {
                if (digit == ".")
                {
                    currentNumberInput += digit;
                }
                else
                {
                    currentNumberInput = digit;
                }                
            }
            else
            {
                if (digit == ".")
                {
                    if (currentNumberInput.Contains('.')) return;
                }
                currentNumberInput += digit;
            }

            if (currentNumber == 1) inputFirstNumber = currentNumberInput;
            else if (currentNumber == 2) inputSecondNumber = currentNumberInput;

            ChangeCalcInput();
        }
        /// <summary>
        /// Select arithmetic operation
        /// </summary>
        /// <param name="sender">Reference to event source</param>
        /// <param name="e">Event object</param>
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            string btnContent = ((Button)sender).Content.ToString();

            if (lockedPrimaryOperation) return;

            foreach (var kv in primaryOperationStrings)
            {
                if (btnContent == kv.Value) primaryOperation = kv.Key;
            }

            if (primaryOperation != PrimaryOperation.NO_OP)
            {
                currentNumber = 2;                
            }
            else
            {
                BtnCA_Click(sender, e);
            }

            ChangeCalcInput();
        }
        /// <summary>
        /// Process currently selected operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private double CalculateSpecialOperationsFirstNumber(double firstNumber)
        {
            //Start with the first number special operations
            while (SpecialOperationsFirst.Count > 0)
            {
                SpecialOperation spop = SpecialOperationsFirst.Pop();
                firstNumber = CalculateSpecialOperation(firstNumber, 0, spop);
            }

            return firstNumber;
        }

        private double CalculateSpecialOperation(double firstNumber, double secondNumber, SpecialOperation spop)
        {
            if (spop == SpecialOperation.EXP) return Math.Pow(firstNumber, secondNumber); 
            else if (spop == SpecialOperation.SQRT) return Math.Sqrt(firstNumber);
            else if (spop == SpecialOperation.LOG) return Math.Log(firstNumber, secondNumber);
            else if (spop == SpecialOperation.SIN) return Math.Sin(firstNumber);
            else if (spop == SpecialOperation.COS) return Math.Cos(firstNumber);
            else if (spop == SpecialOperation.ONEOVERX) return 1 / firstNumber;

            throw new Exception("Somehow the spop isn't equal to any of these");
        }

        private double CalculatePrimaryOperation(double firstNumber, double secondNumber, PrimaryOperation op)
        {
            if (op == PrimaryOperation.ADDITION) return firstNumber + secondNumber;
            else if (op == PrimaryOperation.SUBTRACTION) return firstNumber - secondNumber;
            else if (op == PrimaryOperation.MULTIPLICATION) return firstNumber * secondNumber;
            else if (op == PrimaryOperation.DIVISION) return firstNumber / secondNumber;

            throw new Exception("Somehow the op isn't equal to any of these");
        }

        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            double firstNumber = double.Parse(inputFirstNumber);
            double.TryParse(inputSecondNumber, out double secondNumber);

            //Calculate all the special operations to the first number
            firstNumber = CalculateSpecialOperationsFirstNumber(firstNumber);

            //Start with the second number special operations
            while (SpecialOperationsSecond.Count > 0)
            {
                SpecialOperation spop = SpecialOperationsSecond.Pop();
                secondNumber = CalculateSpecialOperation(secondNumber, firstNumber, spop);
            }

            double result = 0;

            //Calculate the primary operation
            if (primaryOperation != PrimaryOperation.NO_OP) result = CalculatePrimaryOperation(firstNumber, secondNumber, primaryOperation);
            else result = firstNumber;

            //Calculate the all-enclosing operations
            while (SpecialOperationsAll.Count > 0)
            {
                SpecialOperation spop = SpecialOperationsAll.Dequeue();
                result = CalculateSpecialOperation(result, secondNumber, spop);
            }

            //Output the result and reset the necessary values
            clearData();
            inputFirstNumber = result.ToString();
            ChangeCalcInput();
        }

        private void clearData()
        {
            //Release the lock of the primary operation if there was one
            lockedPrimaryOperation = false;

            inputFirstNumber = "0";
            inputSecondNumber = "";
            txtInput.Text = inputFirstNumber;
            primaryOperation = PrimaryOperation.NO_OP;
            inputFormat = defaultInputFormat;
            currentNumber = 1;
        }

        /// <summary>
        /// Clear All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCA_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }
        /// <summary>
        /// Quit WPF application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        #endregion

        /// <summary>
        /// Change which number we apply the special functions to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnS_Click(object sender, RoutedEventArgs e)
        {
            //string numberForSpFuncValue = btnS.Content.ToString();
            //SpOpsScope previousOpsScope = spOpsScopeStrings.First(kv => kv.Value == numberForSpFuncValue).Key;

            if (currentSpOpsScope == SpOpsScope.SECOND) currentSpOpsScope = SpOpsScope.ALL;
            else currentSpOpsScope++;

            btnS.Content = spOpsScopeStrings[currentSpOpsScope];
        }

        private void AddSpecialOperation(SpecialOperation operation, bool operationIsAllScoped = false)
        {         
            if(operationIsAllScoped)
            {
                //Only accept this operation if there are no other all encompassing operations already present
                //And if the current number is 1
                if (SpecialOperationsAll.Count == 0 && currentNumber == 1)
                {
                    double firstNumber = double.Parse(inputFirstNumber);

                    //Calculate the operations on the first number first before continuing
                    inputFirstNumber = CalculateSpecialOperationsFirstNumber(firstNumber).ToString();

                    //The operation scope is ALL by default
                    inputFormat = SpecialOperationtrings[operation];
                    SpecialOperationsAll.Enqueue(operation);

                    //Also remove the primary operation and lock it so that it cannot be changed
                    primaryOperation = PrimaryOperation.NO_OP;
                    lockedPrimaryOperation = true;
                    currentNumber = 2;
                }
            }
            else if (currentSpOpsScope == SpOpsScope.ALL)
            {
                inputFormat = String.Format(SpecialOperationtrings[operation], inputFormat);
                SpecialOperationsAll.Enqueue(operation);
            }
            else if (currentSpOpsScope == SpOpsScope.FIRST)
            {
                inputFormat = String.Format(inputFormat, SpecialOperationtrings[operation], "{1}", "{2}");
                SpecialOperationsFirst.Push(operation);
            }
            else if (currentSpOpsScope == SpOpsScope.SECOND && currentNumber == 2)
            {
                string newSpecialOperationtring = String.Format(SpecialOperationtrings[operation], "{2}");
                inputFormat = String.Format(inputFormat, "{0}", "{1}", newSpecialOperationtring);
                SpecialOperationsSecond.Push(operation);
            }

            ChangeCalcInput();
        }

        private void BtnExp_Click(object sender, RoutedEventArgs e)
        {
            AddSpecialOperation(SpecialOperation.EXP, true);
        }

        private void BtnSqrt_Click(object sender, RoutedEventArgs e)
        {
            AddSpecialOperation(SpecialOperation.SQRT);         
        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            AddSpecialOperation(SpecialOperation.LOG, true);
        }

        private void BtnSin_Click(object sender, RoutedEventArgs e)
        {
            AddSpecialOperation(SpecialOperation.SIN);
        }

        private void BtnCos_Click(object sender, RoutedEventArgs e)
        {
            AddSpecialOperation(SpecialOperation.COS);
        }

        private void BtnOneOverX_Click(object sender, RoutedEventArgs e)
        {
            AddSpecialOperation(SpecialOperation.ONEOVERX);
        }
    }
}
