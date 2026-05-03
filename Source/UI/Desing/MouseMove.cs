using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

public class MouseMove
{
    public static void SetMouse(Canvas? canva)
    {
        if (canva == null)
            return;

        Ellipse mouseGlow = new Ellipse
        {
            Width = 40,
            Height = 40,
            IsHitTestVisible = false,
            Fill = new RadialGradientBrush
            {
                GradientStops =
                    {
                        new GradientStop((Color)ColorConverter.ConvertFromString("#20FFFFFF"), 0),
                        new GradientStop((Color)ColorConverter.ConvertFromString("#01FFFFFF"), 1)
                    }
            }
        };

        canva.MouseMove += (s2, e2) =>
        {
            Point mouse = e2.GetPosition(canva);

            Canvas.SetLeft(mouseGlow, mouse.X - mouseGlow.Width / 2);
            Canvas.SetTop(mouseGlow, mouse.Y - mouseGlow.Height / 2);
        };

        canva.Children.Add(mouseGlow);
    }
}