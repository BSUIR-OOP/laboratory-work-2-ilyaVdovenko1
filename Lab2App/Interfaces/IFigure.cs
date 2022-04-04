namespace Lab2App.Interfaces;

using System;
using System.Collections.Generic;
using Models.ShapesModels;

public interface IFigure
{
    public Func<Position, Position, int, IEnumerable<Dot>> ProvideGenerateDots { get; }

    public int FigureId { get; set; }
}