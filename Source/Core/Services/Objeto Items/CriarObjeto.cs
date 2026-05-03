using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

public class CriarObjeto
{
    private static int num;
    private static double y;
    private static double x;

    public static void Connect(Canvas canva)
    {
        num++;

        Grid vis = new Grid
        {
            Width = 160,
            Height = 28
        };

        Rectangle objeto = new Rectangle
        {
            Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#20FFFFFF")),
            Stroke = Brushes.White,
            StrokeThickness = 2,
            RadiusX = 15,
            RadiusY = 15
        };

        TextBlock txt = new TextBlock
        {
            Text = "Ideia " + num,
            FontSize = 16,
            TextWrapping = TextWrapping.Wrap,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Padding = new Thickness(5)
        };

        vis.Children.Add(objeto);
        vis.Children.Add(txt);

        Point mouse = Mouse.GetPosition(canva);

        Canvas.SetTop(vis, mouse.Y - vis.ActualHeight / 2);
        Canvas.SetLeft(vis, mouse.X - vis.Width / 2);

        MoveObject.Move(vis, canva);

        ContextMenu objMenu = new ContextMenu();

        MenuItem item1 = new MenuItem();
        item1.Header = "Renomear";
        item1.Click += (s, e) =>
        {
            ObjectOptions.Connections(vis, txt);
        };

        MenuItem item2 = new MenuItem();
        item2.Header = "Mudar cor";

        MenuItem item3 = new MenuItem();
        item3.Header = "Mudar formato";

        MenuItem item4 = new MenuItem();
        item4.Header = "Criar linha de fluxo";

        MenuItem item5 = new MenuItem();
        item5.Header = "Recolher conteúdo";

        MenuItem item6 = new MenuItem();
        item6.Header = "Expandir conteúdo";

        item5.Click += (s, e) =>
        {
            vis.Height = 26;
            objMenu.Items.Remove(item5);
            objMenu.Items.Add(item6);
        };

        item6.Click += (s, e) =>
        {
            vis.Height = double.NaN;
            objMenu.Items.Remove(item6);
            objMenu.Items.Add(item5);
        };

        objMenu.Items.Add(item1);
        objMenu.Items.Add(item2);
        objMenu.Items.Add(item3);
        objMenu.Items.Add(item4);

        if (double.IsNaN(vis.Height))
        {
            objMenu.Items.Add(item5);
        }
        else
        {
            objMenu.Items.Add(item6);
        }

        vis.ContextMenu = objMenu;

        ObjectOptions.Connections(vis, txt);

        canva.Children.Add(vis);
    }
}