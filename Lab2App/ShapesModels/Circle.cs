using System;
using System.Collections.Generic;

namespace Lab2App.ShapesModels;

/// <summary>
/// Represents circle object.
/// </summary>
public class Circle : Figure
{
    public Circle(int figureId)
        : base(figureId)
    {
    }

    protected override IEnumerable<Dot> RepresentFigureAsDots(Position start, Position end, int step)
    {
        if (start.XCoordinate > end.XCoordinate)
        {
            (start, end) = (end, start);
        }

        var absStep = Math.Abs(step);
        var dots = new List<Dot>();
        var functionalDependence = this.GenerateFunctionalDependence(start, end);
        for (var currentX = start.XCoordinate; currentX < end.XCoordinate; currentX += absStep)
        {
            var (firstY, secondY) = functionalDependence(currentX);
            dots.Add(new Dot(this.FigureId, new Position(currentX, firstY)));
            if (firstY != secondY)
            {
                dots.Add(new Dot(this.FigureId, new Position(currentX, secondY)));
            }
        }

        return dots;
    }

    private Func<int, (int firstResultCoordinate, int secondResultCoordinate)> GenerateFunctionalDependence(Position start, Position end)
    {
        var radius =
            (int)Math.Round(
                Math.Sqrt(((end.XCoordinate - start.XCoordinate) * (end.XCoordinate - start.XCoordinate)) +
                          ((end.XCoordinate - start.XCoordinate) * (end.XCoordinate - start.XCoordinate))),
                MidpointRounding.AwayFromZero);
        (int firstFunctionResult, int secondFunctionResult) FactoryFunction(int x)
        {
            var discriminant = (radius - x + start.XCoordinate) * (radius + x - start.XCoordinate);
            if (discriminant == 0)
            {
                return (start.YCoordinate, start.YCoordinate);
            }

            if (discriminant < 0)
            {
                throw new ArgumentException($"Could not create this circle, {start.ToString()} and radius {radius}");
            }

            var squareRootFromDiscriminant = (int)Math.Round(Math.Sqrt(discriminant), MidpointRounding.AwayFromZero);

            return (start.YCoordinate + squareRootFromDiscriminant, start.YCoordinate - squareRootFromDiscriminant);
        }

        return FactoryFunction;
    }
}