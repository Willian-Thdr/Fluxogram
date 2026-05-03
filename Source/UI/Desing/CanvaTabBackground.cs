using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

public class CanvaTabBackground
{
    static List<object>? window;
    static Ellipse? elipseName;

    public static void Connect(object? tela, Ellipse? elipse)
    {
        window = (List<object>?)tela;
        elipseName = elipse;
    }

    private void AreaMove(object? sender, MouseEventArgs e)
    {
        var canvases = window.OfType<Canvas>();

        foreach (var canvas in canvases)
        {
            Point mouse = e.GetPosition(canvas);

            Canvas.SetLeft(elipseName, mouse.X - elipseName.Width / 2);
            Canvas.SetLeft(elipseName, mouse.Y - elipseName.Height / 2);
        }
    }
}