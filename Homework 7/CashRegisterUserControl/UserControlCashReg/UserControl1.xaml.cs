using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UserControlCashReg
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl, INotifyPropertyChanged
    {
        private const decimal TAX = 0.2M;

        private decimal subTotalPrice;

        public decimal SubTotalPrice {
            get => subTotalPrice;
            set 
            {
                this.subTotalPrice = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubTotalPrice)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxPrice)));
            }
        }
        public decimal TaxPrice => SubTotalPrice * TAX;
        public decimal TotalPrice => SubTotalPrice + TaxPrice;

        public event PropertyChangedEventHandler? PropertyChanged;

        public UserControl1()
        {
            InitializeComponent();
            this.SubTotalPrice = 0;
            grid.DataContext = this;

            Binding taxBoxBinding = new Binding("TaxPrice");
            taxBoxBinding.Mode = BindingMode.OneWay;
            taxBoxBinding.StringFormat = "0.00";
            taxBox.SetBinding(TextBox.TextProperty, taxBoxBinding);
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text = "";
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
            bool validNumber = Decimal.TryParse(priceBox.Text, out decimal price);

            if (!validNumber)
            {
                priceBox.Text += "  |  Invalid number entered!";
                return;
            }

            SubTotalPrice += price;
        }

        private void buttonTotal_Click(object sender, RoutedEventArgs e)
        {
            totalBox.Text = TotalPrice.ToString("0.00");
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            this.SubTotalPrice = 0;
            totalBox.Text = "";
            buttonDelete_Click(sender, e);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "1";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "2";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "3";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "4";
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "5";
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "6";
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "7";
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "8";
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "9";
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += "0";
        }

        private void buttonFloatPoint_Click(object sender, RoutedEventArgs e)
        {
            priceBox.Text += ".";
        }
    }
}