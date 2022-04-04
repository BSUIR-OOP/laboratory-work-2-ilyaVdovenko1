using System.Collections.Generic;

namespace Lab2App.Models.ShapesModels;

public class Square : Rectangle
{
    public Square(int figureId)
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

    private IEnumerable<Line> RepresentFigureAsLines(Position start, Position initialEnd, int step)
    {
        if (start.XCoordinate > initialEnd.XCoordinate || start.YCoordinate > initialEnd.YCoordinate)
        {
            (start, initialEnd) = (initialEnd, start);
        }

        var length = initialEnd.XCoordinate - start.XCoordinate;
        var end = new Position(start.XCoordinate + length, start.YCoordinate - length);
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