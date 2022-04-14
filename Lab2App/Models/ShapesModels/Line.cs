namespace Lab2App.Models.ShapesModels;

using System.Collections.Generic;
public sealed class Line : Figure
{
    private Position startPoint;
    private Position endPoint;
    private int step;

    public Line(int figureId)
        : base(figureId)
    {
    }

    public Line(int figureId, Position start, Position end, int step)
        : base(figureId)
    {
        this.startPoint = start;
        this.endPoint = end;
        this.step = step;
    }

    public IEnumerable<Dot> RepresentFigureAsDots()
    {
        var dots = new List<Dot>
        {
            new Dot(this.FigureId, this.startPoint),
            new Dot(this.FigureId, this.endPoint),
        };
        return dots;
    }

    protected override IEnumerable<Dot> RepresentFigureAsDots(Position start, Position end, int step)
    {
        this.step = step;
        this.startPoint = start;
        this.endPoint = end;
        if (this.startPoint.XCoordinate > this.endPoint.XCoordinate)
        {
            (this.startPoint, this.endPoint) = (this.endPoint, this.startPoint);
        }

        var dots = new List<Dot>
        {
            new (this.FigureId, this.startPoint),
            new (this.FigureId, this.endPoint),
        };

        return dots;
    }
}