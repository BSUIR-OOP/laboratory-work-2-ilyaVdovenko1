using System.Collections.Generic;

namespace Lab2App.ShapesModels;

/// <summary>
/// Represents dot figure.
/// </summary>
public class Dot
{
    public Dot(int figureId, Position point)
    {
        this.DotId = figureId;
        this.Point = point;
    }

    public Position Point { get; }

    public int DotId { get; }
}