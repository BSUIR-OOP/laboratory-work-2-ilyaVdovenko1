namespace Lab2App.Models.ShapesModels;
using System.Collections.Generic;

/// <summary>
/// Represents Rectangle.
/// </summary>
public class Rectangle : Quadrangle
{
    public Rectangle(int figureId)
        : base(figureId)
    {
    }

    protected override IEnumerable<Dot> RepresentFigureAsDots(Position start, Position end, int step)
    {
        var dots = new List<Dot>();
        foreach (var line in this.RepresentFigureAsLines(start, end, step))
        {
            dots.AddRange(line.RepresentFigureAsDots());
        }

        return dots;
    }

    private IEnumerable<Line> RepresentFigureAsLines(Position start, Position end, int step)
    {
        if (start.XCoordinate > end.XCoordinate || start.YCoordinate > end.YCoordinate)
        {
            (start, end) = (end, start);
        }

        var listOfLines = new List<Line>
        {
            new (this.FigureId, new Position(start.XCoordinate, end.YCoordinate), start, step),
            new (this.FigureId, start, new Position(end.XCoordinate, start.YCoordinate), step),
            new (this.FigureId, new Position(end.XCoordinate, start.YCoordinate), end, step),
            new (this.FigureId, end, new Position(start.XCoordinate, end.YCoordinate), step),
        };
        return listOfLines;
    }
}