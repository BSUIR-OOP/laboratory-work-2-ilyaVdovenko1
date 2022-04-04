using Lab2App.ShapesModels;
using System;
using System.Collections.Generic;

namespace Lab2App.Interfaces
{
    public interface IFigure
    {
        public Func<Position, Position, int, IEnumerable<Dot>> ProvideGenerateDots { get; }
    }
}
