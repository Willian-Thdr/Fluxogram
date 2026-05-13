using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

public class MoveObject
{
    public static void Move(Grid? grid, Canvas? canva)
    {
        if (grid == null)
            return;

        bool dragging = false;
        Point offset = new Point();

        grid.MouseLeftButtonDown += (s, e) =>
        {
            dragging = true;

            Point mouse = e.GetPosition(canva);

            offset.Y = mouse.Y - Canvas.GetTop(grid);
            offset.X = mouse.X - Canvas.GetLeft(grid);

            grid.CaptureMouse();
        };

        grid.MouseMove += (s, e) =>
        {
            if (!dragging)
                return;

            Point mouse = e.GetPosition(canva);

            Canvas.SetTop(grid, mouse.Y - grid.ActualHeight / 2);
            Canvas.SetLeft(grid, mouse.X - grid.Width / 2);
            UpdateConnections(grid);
        };

        grid.MouseLeftButtonUp += (s, e) =>
        {
            dragging = false;
            grid.ReleaseMouseCapture();
        };
    }

    public static void UpdateConnections(Grid grid)
    {
        foreach (var conn in StorageConnections.Connections)
        {
            if (conn.Start == grid || conn.End == grid)
            {
                Point start = CriarObjeto.RightSide(conn.Start);
                Point end = CriarObjeto.LeftSide(conn.End);

                conn.Line.Data = CriarProgresso.Create(start, end).Data;
            }
        }
    }
}