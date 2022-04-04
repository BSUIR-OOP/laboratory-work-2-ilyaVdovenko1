namespace Lab2App.Models;

using System.Collections.Generic;
using Interfaces;
public class Layer
{
    private readonly List<IFigure> figures;

    public Layer()
    {
        this.figures = new List<IFigure>();
    }

    public int CurrentFigureId { get; private set; }

    public void AddFigure(IFigure figure)
    {
        this.CurrentFigureId = this.figures.Count;
        figure.FigureId = this.CurrentFigureId;
        this.figures.Add(figure);
    }
}