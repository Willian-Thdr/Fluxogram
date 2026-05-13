using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Windows.Shapes;

namespace Fluxogram.Core.Services;

public class CreateNewTab
{
    static List<TabItem> tabList = new List<TabItem>(); // Listas que receberá todos os ids de todas as abas
    static List<Canvas>? canvaList;
    public static void Connect(Button button, TabControl abas)
    {
        int num = 0; // Numerdor do total de abas
        ColumnDefinition? coluna = StorageBoxMenuLateral.Instance.coluna as ColumnDefinition;

        // Evento de quando o botão de criar aba é clicado
        button.Click += (s, e) =>
        {
            num++; // Aumento o numerador em 1
            string idName = "Fluxograma_" + num; // Nomeio o id da aba a partir de sua numeração
            string name = "Novo Fluxograma";
            var element = (FrameworkElement)s;

            TabItem novaAba = new TabItem()
            {
                Name = idName,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#207c7c7c")),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(5, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBlock title = new TextBlock // Define o nome da aba e seu alinhamento
            {
                Text = name,
                VerticalAlignment = VerticalAlignment.Center
            };

            Color color0 = (Color)ColorConverter.ConvertFromString("#708AEF");
            Color color1 = (Color)ColorConverter.ConvertFromString("#5B1094");

            LinearGradientBrush brush = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
            };

            brush.GradientStops.Add(new GradientStop(color0, 0));
            brush.GradientStops.Add(new GradientStop(color1, 1));

            StackPanel panel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            panel.Children.Add(title);

            Canvas canvas = new Canvas // Permite colocar o botão de fechar na aba
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = brush
            };

            // Faço a modificação da aba
            novaAba.Header = panel;
            novaAba.Content = canvas;

            TextBlock text = new TextBlock
            {
                Text = "Ideias de projeto",
                FontSize = 24
            };

            MouseTabInteractive.Connect(canvas);
            MouseMove.SetMouse(canvas);

            Canvas.SetTop(text, 20);
            Canvas.SetLeft(text, 25);

            tabList.Add(novaAba);
            StorageBox.Instance.titles.Add(title);
            new CloseTabSystem(abas, novaAba, panel);

            canvaList = new List<Canvas>();

            ContextMenu menu = new ContextMenu();
            MenuItem item = new MenuItem();
            item.Header = "Renomear aba";
            item.Click += (s, e) =>
            {
                RenameTab.Rename(novaAba);
            };

            menu.Items.Add(item);

            novaAba.ContextMenu = menu;

            canvas.Children.Add(text);

            StorageBoxMenuLateral.Instance.canvas.Add(canvas);

            if (StorageBoxMainWindow.Instance.doubles == 0)
            {
                ShowButton.getCanva1(StorageBoxMainWindow.Instance.checker);
            }

            // Adiciono as abas criadas ao TabControl
            abas.Items.Add(novaAba);
            StorageBox.Instance.verify = true;
        };
    }
}