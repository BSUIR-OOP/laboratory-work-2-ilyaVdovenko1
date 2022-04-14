namespace Lab2App.Models.ShapesModels;

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