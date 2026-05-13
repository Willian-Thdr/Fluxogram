using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

public class SelectProject
{
    public static void Connect()
    {
        Window window = new Window()
        {
            Title = "Selecionar projeto",
            Width = 720,
            Height = 480
        };

        TreeView tree = new TreeView()
        {
            Margin = new Thickness(10),
            BorderBrush = Brushes.Black,
            BorderThickness = new Thickness(3)
        };

        Grid grid = new Grid();

        grid.Children.Add(tree);
        window.Content = grid;
        foreach (TextBlock tab in StorageBox.Instance.titles)
        {
            tree.Items.Add(tab.Text);
        }

        window.Show();
    }
}