using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

public class AbrirMenuSubTabs
{
    public void Function(Canvas? canvas, bool check)
    {
        Button? antigo = canvas.Children.OfType<Button>().FirstOrDefault(b => b.Tag?.ToString() == "OpenMenuButton");
        Action? onClick = StorageBox.Instance.onClick;

        if (antigo != null)
            canvas.Children.Remove(antigo);

        if (!check || canvas == null)
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

        open.Click += (s, e) =>
        {
            onClick?.Invoke();

            Button button = (Button)StorageBox.Instance.elementUi[0];
            Canvas canva = (Canvas)StorageBox.Instance.elementUi[1];
            List<Canvas>? canva2 = StorageBox.Instance.canvas;

            bool check = false;

            ColumnDefinition coluna = (ColumnDefinition)StorageBox.Instance.something[0];

            new MenuButtonFunc(button, canva, canva2, check, "≡", coluna, 0, 220);
        };

        Canvas.SetTop(open, 10);
        Canvas.SetLeft(open, 0);

        canvas.Children.Add(open);
    }
}