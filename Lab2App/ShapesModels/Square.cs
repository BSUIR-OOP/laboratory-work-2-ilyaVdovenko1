using System.Collections.Generic;

namespace Lab2App.ShapesModels;

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

    private IEnumerable<Line> RepresentFigureAsLines(Position start, Position end, int step)
    {
        var length = end.XCoordinate - start.XCoordinate;
        var listOfLines = new List<Line>
        {
            new (this.FigureId, new Position(start.XCoordinate, length), start, step),
            new (this.FigureId, start, new Position(start.XCoordinate + length, start.YCoordinate + length), step),
            new (this.FigureId, new Position(start.XCoordinate + length, start.YCoordinate + length),
                new Position(start.XCoordinate + length, start.YCoordinate - length), step),
            new (this.FigureId, end, new Position(start.XCoordinate, start.YCoordinate - length), step),
        };
        return listOfLines;
    }
}