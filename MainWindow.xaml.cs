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

namespace GraphicsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MyPaint : Window
    {
        public MyPaint()
        {
            InitializeComponent();

			brushIsDown = false;
            brushThickness = 4;
            currentColor = Brushes.Red;
            fixedRedColor.IsChecked = true;
        }

		Brush currentColor;
		bool brushIsDown;
		double brushThickness;

		private void cmDown(object sender, MouseButtonEventArgs e)
		{
			brushIsDown = true;
		}

		private void cmUp(object sender, MouseButtonEventArgs e)
		{
			brushIsDown = false;
		}

		private void cmMove(object sender, MouseEventArgs e)
		{
			if (brushIsDown)
			{
				if ((e.GetPosition(myCanvas).X < 0) || (e.GetPosition(myCanvas).X > myCanvas.Width))
				{
					return;
				}
				if ((e.GetPosition(myCanvas).Y < 0) || (e.GetPosition(myCanvas).Y > myCanvas.Height))
				{
					return;
				}

				Ellipse ellipse = new Ellipse();
				ellipse.Width = brushThickness;
				ellipse.Height = brushThickness;
				ellipse.Fill = currentColor;
				ellipse.Margin = new Thickness(e.GetPosition(myCanvas).X - brushThickness / 2, e.GetPosition(myCanvas).Y - brushThickness / 2, 0, 0);
				myCanvas.Children.Add(ellipse);
			}
		}

		private void cmClear(object sender, RoutedEventArgs e)
		{
			myCanvas.Children.Clear();
		}

		private void cmRed(object sender, RoutedEventArgs e)
		{
			currentColor = Brushes.Red;
			squareColor.Fill = currentColor;
		}

		private void cmBlue(object sender, RoutedEventArgs e)
		{
			currentColor = Brushes.Blue;
			squareColor.Fill = currentColor;
		}

		private void cmGreen(object sender, RoutedEventArgs e)
		{
			currentColor = Brushes.Green;
			squareColor.Fill = currentColor;
		}

		private void cmYellow(object sender, RoutedEventArgs e)
		{
			currentColor = Brushes.Yellow;
			squareColor.Fill = currentColor;
		}

		private void cmBlack(object sender, RoutedEventArgs e)
		{
			currentColor = Brushes.Black;
			squareColor.Fill = currentColor;
		}

		private void cmPurple(object sender, RoutedEventArgs e)
		{
			currentColor = Brushes.Purple;
			squareColor.Fill = currentColor;
		}

		private void cmSize(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			brushThickness = brushSize.Value;
		}
    }
}
