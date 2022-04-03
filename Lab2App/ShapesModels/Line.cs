using System;
using System.Collections.Generic;

namespace Lab2App.ShapesModels;

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
        if (this.startPoint.XCoordinate < this.endPoint.XCoordinate)
        {
            (this.startPoint, this.endPoint) = (this.endPoint, this.startPoint);
        }

        var absStep = Math.Abs(this.step);
        var dots = new List<Dot>();
        var functionalDependence = FindFunctionalDependence(this.startPoint, this.endPoint);
        for (var currentX = this.startPoint.XCoordinate; currentX < this.endPoint.XCoordinate; currentX += absStep)
        {
            dots.Add(new Dot(this.FigureId, new Position(currentX, functionalDependence(currentX))));
        }

        return dots;
    }

    protected override IEnumerable<Dot> RepresentFigureAsDots(Position start, Position end, int step)
    {
        this.step = step;
        this.startPoint = start;
        this.endPoint = end;
        if (this.startPoint.XCoordinate < this.endPoint.XCoordinate)
        {
            (this.startPoint, this.endPoint) = (this.endPoint, this.startPoint);
        }

        var absStep = Math.Abs(this.step);
        var dots = new List<Dot>();
        var functionalDependence = FindFunctionalDependence(this.startPoint, this.endPoint);
        for (var currentX = this.startPoint.XCoordinate; currentX < this.endPoint.XCoordinate; currentX += absStep)
        {
            dots.Add(new Dot(this.FigureId, new Position(currentX, functionalDependence(currentX))));
        }

        return dots;
    }

    private static Func<int, int> FindFunctionalDependence(Position firstPoint, Position secondPoint)
    {
        if (firstPoint.Equals(secondPoint))
        {
            return x => x;
        }

        if (firstPoint.XCoordinate == secondPoint.XCoordinate && firstPoint.YCoordinate != secondPoint.YCoordinate)
        {
            return x => x;
        }

        var xGradient = secondPoint.XCoordinate - firstPoint.XCoordinate;
        var yGradient = secondPoint.YCoordinate - firstPoint.YCoordinate;
        var slope = (decimal)yGradient / xGradient;
        var bias = firstPoint.YCoordinate - (slope * firstPoint.XCoordinate);

        int ResultFunction(int x)
        {
            return (int)Math.Round((slope * x) + bias, MidpointRounding.AwayFromZero);
        }

        return ResultFunction;
    }
}