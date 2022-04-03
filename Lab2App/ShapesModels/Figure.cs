using System;
using System.Collections.Generic;

namespace Lab2App.ShapesModels;

public abstract class Figure
{
    protected Figure(int figureId)
    {
        this.FigureId = figureId;
    }

    public int FigureId { get; }

    public virtual Func<Position, Position, int, IEnumerable<Dot>> Draw()
    {
        return this.RepresentFigureAsDots;
    }

    protected abstract IEnumerable<Dot> RepresentFigureAsDots(Position start, Position end, int step);
}