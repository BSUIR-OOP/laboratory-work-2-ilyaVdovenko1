namespace Lab2App;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Interfaces;
using Models;
using Models.ShapesModels;
using Line = Models.ShapesModels.Line;
using Rectangle = Models.ShapesModels.Rectangle;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private const int Step = 1;
    private readonly Layer layer;
    private IFigure? figure;
    private Position? startMousePosition;
    private Position? endMousePosition;
    private Brush borderColor;

    public MainWindow()
    {
        this.InitializeComponent();
        this.borderColor = Brushes.Black;
        this.layer = new Layer();
    }

    private void Circle_Btn_Click(object sender, RoutedEventArgs e)
    {
        this.figure = new Circle(this.layer.CurrentFigureId);
    }

    private void Rectangle_Btn_Click(object sender, RoutedEventArgs e)
    {
        this.figure = new Rectangle(this.layer.CurrentFigureId);
    }

    private void Square_Btn_Click(object sender, RoutedEventArgs e)
    {
        this.figure = new Square(this.layer.CurrentFigureId);
    }

    private void Line_Btn_Click(object sender, RoutedEventArgs e)
    {
        this.figure = new Line(this.layer.CurrentFigureId);
    }

    private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var relativeMouseCoordinates = e.GetPosition(this.DrawFieldCanvas);
        this.startMousePosition = new Position((int)relativeMouseCoordinates.X, (int)relativeMouseCoordinates.Y);
    }

    private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
    {
        var relativeMouseCoordinates = e.GetPosition(this.DrawFieldCanvas);

        this.endMousePosition = new Position((int)relativeMouseCoordinates.X, (int)relativeMouseCoordinates.Y);
        if (this.figure is null || this.startMousePosition is null || this.endMousePosition is null)
        {
            return;
        }

        var pen = new Drawer<Canvas>(this.figure, this.DrawFieldCanvas);
        pen.Draw(this.startMousePosition, this.endMousePosition, Step, this.borderColor);
        this.layer.AddFigure(this.figure);
    }

    private void ColorPicker_OnSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
        if (this.ColorPicker.SelectedColor.HasValue)
        {
            var color = this.ColorPicker.SelectedColor.Value;
            this.borderColor = new SolidColorBrush(color);
        }
    }
}