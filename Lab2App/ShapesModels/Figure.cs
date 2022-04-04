using Lab2App.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab2App.ShapesModels;

public abstract class Figure : IFigure
{
    protected Figure(int figureId)
    {
        this.FigureId = figureId;
    }

    public int FigureId { get; }

    public Func<Position, Position, int, IEnumerable<Dot>> ProvideGenerateDots => this.RepresentFigureAsDots;

    protected abstract IEnumerable<Dot> RepresentFigureAsDots(Position start, Position end, int step);
}