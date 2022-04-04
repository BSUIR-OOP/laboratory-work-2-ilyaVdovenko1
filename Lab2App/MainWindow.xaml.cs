using Lab2App.Interfaces;
using Lab2App.ShapesModels;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab2App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IFigure figure;
        private int idCounter;
        private Position startMousePosition;
        private Position endMousePosition;


        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Circle_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.figure = new Circle(this.idCounter++);
        }

        private void Rectangle_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.figure = new ShapesModels.Rectangle(this.idCounter++);
        }

        private void Square_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.figure = new Square(this.idCounter++);
        }

        private void Line_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.figure = new ShapesModels.Line(this.idCounter++);
        }

        private void Canvas_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var relativeMouseCoordinates = e.GetPosition(this.DrawField_Canvas);
            this.startMousePosition = new Position((int)relativeMouseCoordinates.X, (int)relativeMouseCoordinates.Y);
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var relativeMouseCoordinates = e.GetPosition(this.DrawField_Canvas);

            this.endMousePosition = new Position((int)relativeMouseCoordinates.X, (int)relativeMouseCoordinates.Y);
            if (this.figure is not null)
            {
                var dots = this.figure.ProvideGenerateDots.Invoke(this.startMousePosition, this.endMousePosition, 1);
                var myPolygon = new Polygon();
                myPolygon.Stroke = Brushes.Black;
                myPolygon.StrokeThickness = 1;
                myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
                myPolygon.VerticalAlignment = VerticalAlignment.Center;
                foreach (var dot in dots)
                {
                    myPolygon.Points.Add(new Point(dot.Point.XCoordinate, dot.Point.YCoordinate));
                }

                this.DrawField_Canvas.Children.Add(myPolygon);
            }
        }
    }
}