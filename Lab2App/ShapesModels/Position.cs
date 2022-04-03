using System;

namespace Lab2App.ShapesModels;

public class Position : object
{
    public Position(int x, int y)
    {
        if (x < 0)
        {
            throw new ArgumentException("Coordinate can not be less then 0", nameof(x));
        }

        if (y < 0)
        {
            throw new ArgumentException("Coordinate can not be less then 0", nameof(y));
        }

        this.XCoordinate = x;
        this.YCoordinate = y;
    }

    public int XCoordinate { get; }

    public int YCoordinate { get; }

    public bool Equals(Position? other)
    {
        return other is not null
               && ReferenceEquals(this, other)
               && this.XCoordinate == other.XCoordinate
               && this.YCoordinate == other.YCoordinate;
    }

    public override string ToString()
    {
        return $"({this.XCoordinate}, {this.YCoordinate})";
    }
}