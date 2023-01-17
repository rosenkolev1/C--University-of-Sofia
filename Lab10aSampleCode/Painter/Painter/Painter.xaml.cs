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

namespace Painter
{
    public partial class MainWindow : Window
    {
        private int diameter = 8; 
        private Brush brushColor = Brushes.Black; 
        private bool shouldErase = false; 
        private bool shouldPaint = false;

        List<int> lastAddedCounts = new List<int>();

        private enum Sizes 
        {
            SMALL = 4,
            MEDIUM = 8,
            LARGE = 10
        } 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PaintCircle(Brush circleColor, Point position)
        {
            Ellipse newEllipse = new Ellipse();

            newEllipse.Fill = circleColor; 
            newEllipse.Width = diameter; 
            newEllipse.Height = diameter; 

            Canvas.SetTop(newEllipse, position.Y);
            Canvas.SetLeft(newEllipse, position.X);

            paintCanvas.Children.Add(newEllipse);

            this.lastAddedCounts[this.lastAddedCounts.Count - 1] += 1;
        }

        private void paintCanvas_MouseLeftButtonDown(object sender,
           MouseButtonEventArgs e)
        {
            shouldPaint = true;
            lastAddedCounts.Add(0);
        }

        private void paintCanvas_MouseLeftButtonUp(object sender,
           MouseButtonEventArgs e)
        {
            shouldPaint = false;
        }

        private void paintCanvas_MouseRightButtonDown(object sender,
           MouseButtonEventArgs e)
        {
            shouldErase = true; 
        }

        private void paintCanvas_MouseRightButtonUp(object sender,
           MouseButtonEventArgs e)
        {
            shouldErase = false; 
        }

        private void paintCanvas_MouseMove(object sender,
           MouseEventArgs e)
        {
            if (shouldPaint)
            {
                Point mousePosition = e.GetPosition(paintCanvas);
                PaintCircle(brushColor, mousePosition);
            }
            else if (shouldErase)
            {
                Point mousePosition = e.GetPosition(paintCanvas);
                PaintCircle(paintCanvas.Background, mousePosition);
            }
        } 

        private void smallRadioButton_Checked(object sender,
           RoutedEventArgs e)
        {
            diameter = (int)Sizes.SMALL;
        } 

        private void mediumRadioButton_Checked(object sender,
           RoutedEventArgs e)
        {
            diameter = (int)Sizes.MEDIUM;
        } 

        private void largeRadioButton_Checked(object sender,
           RoutedEventArgs e)
        {
            diameter = (int)Sizes.LARGE;
        } 

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            int count = paintCanvas.Children.Count;

            while(this.lastAddedCounts.Count > 0 && this.lastAddedCounts.Last() == 0)
            {
                this.lastAddedCounts.RemoveAt(this.lastAddedCounts.Count - 1);
            }

            int mostRecentCount = this.lastAddedCounts.Count == 0 ? 0 : this.lastAddedCounts.Last();
            if (this.lastAddedCounts.Count != 0) this.lastAddedCounts.RemoveAt(this.lastAddedCounts.Count - 1);

            paintCanvas.Children.RemoveRange(count - mostRecentCount, mostRecentCount);
        } 

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            paintCanvas.Children.Clear();
        } 
    }
}
