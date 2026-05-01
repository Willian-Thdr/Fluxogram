using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

public class AbrirMenu
{
    public AbrirMenu()
    {

    }

    public void Function(Canvas canvas, bool checker, Action? onClick)
    {
        Button? antigo = canvas.Children.OfType<Button>().FirstOrDefault(b => b.Tag?.ToString() == "OpenMenuButton");

        if (antigo != null)
            canvas.Children.Remove(antigo);

        if (!checker)
            return;

        Button open = new Button
        {
            Content = "≡",
            Width = 20,
            Height = 20,
            Margin = new Thickness(0, 5, 0, 0),
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bbbbbb")),
            HorizontalAlignment = HorizontalAlignment.Left,
            Tag = "OpenMenuButton"
        };

        open.MouseEnter += (s, e) =>
        {
            open.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#207ab3da"));
            open.Content = ">";
        };

        open.MouseLeave += (s, e) =>
        {
            open.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bbbbbb"));
            open.Content = "≡";
        };

        open.Click += (s, e) => onClick?.Invoke();

        Canvas.SetTop(open, 10);
        Canvas.SetLeft(open, 0);

        canvas.Children.Add(open);
    }
}