using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;

public class MouseTabInteractive
{
    public static void Connect(Canvas? canva)
    {
        if (canva == null)
            return;

        ContextMenu menu = new ContextMenu();

        MenuItem item1 = new MenuItem();
        item1.Header = "Criar objeto";
        item1.Click += (s, e) =>
        {
            CriarObjeto.Connect(canva);
        };

        MenuItem item2 = new MenuItem();
        item2.Header = "Criar conexão";
        item2.Click += (s, e) =>
        {
            MessageBox.Show("item2 funcionando");
        };

        menu.Items.Add(item1);
        menu.Items.Add(item2);

        canva.ContextMenu = menu;
    }
}