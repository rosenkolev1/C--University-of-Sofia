using CodeChangeLib;
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

namespace CodeChangeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            codeGenerator.CodeChange += OnCodeChange;
        }

        public void OnCodeChange(object sender, CodeChangeEventArgs e)
        {
            codeBox.Text += string.Join(" ", e.Code) + " ";
        }

        private void ButtonStatistics_Click(object sender, RoutedEventArgs e)
        {
            var statisticsText = string.Join("", codeBox.Text.Split(" ")
                .Where(x => !string.IsNullOrEmpty(x) && (x[1] - x[0] == 1 || (x[1] == 'А' && x[0] == 'Я')) )
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => $"{x.Key}      {x.Count()}\n"));

            statisticsBox.Text += statisticsText;
        }
    }
}
