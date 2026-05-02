using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace Fluxogram.Core.Services;

public class CreateNewTab
{
    static List<TabItem> tabList = new List<TabItem>(); // Listas que receberá todos os ids de todas as abas
    static List<Canvas>? canvaList;

    public static void Connect(Button button, TabControl abas)
    {
        int num = 0; // Numerdor do total de abas

        // Evento de quando o botão de criar aba é clicado
        button.Click += (s, e) =>
        {
            num++; // Aumento o numerador em 1
            string idName = "Fluxograma_" + num; // Nomeio o id da aba a partir de sua numeração
            string name = "Novo Fluxograma";

            TabItem novaAba = new TabItem(); // Item que cria nova aba

            TextBlock title = new TextBlock // Define o nome da aba e seu alinhamento
            {
                Text = name,
                VerticalAlignment = VerticalAlignment.Center
            };

            Color color0 = (Color)ColorConverter.ConvertFromString("#5B1094");
            Color color1 = (Color)ColorConverter.ConvertFromString("#708AEF");
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(1, 1);
            brush.GradientStops.Add(new GradientStop(color0, 0));
            brush.GradientStops.Add(new GradientStop(color1, 1));

            Canvas canvas = new Canvas // Permite colocar o botão de fechar na aba
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = brush
            };

            StackPanel panel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            panel.Children.Add(title);

            // Faço a modificação da aba
            novaAba.Header = panel;
            novaAba.Content = canvas;
            novaAba.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#207c7c7c"));
            novaAba.BorderBrush = Brushes.Black;
            novaAba.Margin = new Thickness(5, 0, 0, 0);
            novaAba.HorizontalAlignment = HorizontalAlignment.Center;

            TextBlock text = new TextBlock
            {
                Text = "Ideias de projeto",
                FontSize = 24
            };

            Canvas.SetTop(text, 20);
            Canvas.SetLeft(text, 25);

            canvaList = new List<Canvas>();
            canvas.Children.Add(text);
            canvaList.Add(canvas);

            // Adiciono as abas criadas ao TabControl
            abas.Items.Add(novaAba);

            /* Adiciono todas as abas novas criadas à lista e chamo 
            a classe da modificação do nome da aba pra que modifique todos os itens da lista */
            tabList.Add(novaAba);
            new RenameTab(tabList);
            new CloseTabSystem(abas, novaAba, panel);

            foreach (Canvas canvaItem in canvaList)
            {
                StorageBox.Instance.canvas.Add(canvaItem);
            }
        };
    }
}