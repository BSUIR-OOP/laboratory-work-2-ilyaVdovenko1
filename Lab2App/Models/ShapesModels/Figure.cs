namespace Lab2App.Models.ShapesModels;

using System;
using System.Collections.Generic;
using Interfaces;

public abstract class Figure : IFigure
{
    protected Figure(int figureId)
    {
        this.FigureId = figureId;
    }

    public int FigureId { get; set; }

    public Func<Position, Position, int, IEnumerable<Dot>> ProvideGenerateDots => this.RepresentFigureAsDots;

    protected abstract IEnumerable<Dot> RepresentFigureAsDots(Position start, Position end, int step);
}