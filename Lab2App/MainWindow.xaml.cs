using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Lab2App.Interfaces;
using Lab2App.ShapesModels;

namespace Lab2App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Step = 1;
        private IFigure? figure;
        private int idCounter;
        private Position? startMousePosition;
        private Position? endMousePosition;

        public MainWindow()
        {
            this.InitializeComponent();
            this.idCounter = 0;
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

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var relativeMouseCoordinates = e.GetPosition(this.drawFieldCanvas);
            this.startMousePosition = new Position((int)relativeMouseCoordinates.X, (int)relativeMouseCoordinates.Y);
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var relativeMouseCoordinates = e.GetPosition(this.drawFieldCanvas);

            this.endMousePosition = new Position((int)relativeMouseCoordinates.X, (int)relativeMouseCoordinates.Y);
            if (this.figure is null || this.startMousePosition is null || this.endMousePosition is null)
            {
                return;
            }

            var dots = this.figure.ProvideGenerateDots.Invoke(this.startMousePosition, this.endMousePosition, Step);
            var myPolygon = new Polygon
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };
            foreach (var dot in dots)
            {
                myPolygon.Points.Add(new Point(dot.Point.XCoordinate, dot.Point.YCoordinate));
            }

            this.drawFieldCanvas.Children.Add(myPolygon);
        }
    }
}