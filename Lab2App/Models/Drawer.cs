namespace Lab2App.Models;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Interfaces;
using ShapesModels;

public class Drawer<T>
    where T : Canvas
{
    private readonly IFigure figure;
    private readonly T drawingProvider;

    public Drawer(IFigure figure, T drawingProvider)
    {
        this.figure = figure;
        this.drawingProvider = drawingProvider;
    }

    public void Draw(Position start, Position end, int step, Brush brush)
    {
        var dots = this.figure.ProvideGenerateDots.Invoke(start, end, step);
        var myPolygon = new Polygon
        {
            Stroke = brush,
            StrokeThickness = 1,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
        };
        foreach (var dot in dots)
        {
            myPolygon.Points.Add(new Point(dot.Point.XCoordinate, dot.Point.YCoordinate));
        }

        this.drawingProvider.Children.Add(myPolygon);
    }
}