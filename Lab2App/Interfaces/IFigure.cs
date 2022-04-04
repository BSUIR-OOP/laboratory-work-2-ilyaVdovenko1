using System;
using System.Collections.Generic;
using Lab2App.Models.ShapesModels;

namespace Lab2App.Interfaces
{
    public interface IFigure
    {
        public Func<Position, Position, int, IEnumerable<Dot>> ProvideGenerateDots { get; }
    }
}
