using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;

public class CriarProgresso
{
    public static Path Create(Point start, Point end)
    {
        double dx = end.X - start.X;

        double offset = Math.Max(Math.Abs(dx) * 0.5, 60);

        BezierSegment bezier = new BezierSegment(
            new Point(start.X + offset, start.Y),
            new Point(end.X - offset, end.Y),
            end,
            true
        );

        PathFigure figure = new PathFigure
        {
            StartPoint = start,
            Segments = new PathSegmentCollection { bezier }
        };

        PathGeometry geometry = new PathGeometry();
        geometry.Figures.Add(figure);

        return new Path
        {
            Stroke = Brushes.Black,
            StrokeThickness = 2,
            Data = geometry
        };
    }
}