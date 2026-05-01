using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace Fluxogram.Core.Services;

public static class CreateNewTab
{
    public static void Connect(Button button, TabControl abas, List<TabItem> items)
    {
        List<TabItem> tabList = new List<TabItem>(); // Listas que receberá todos os ids de todas as abas
        int num = 0; // Numerdor do total de abas

        // Evento de quando o botão de criar aba é clicado
        button.Click += (s, e) =>
        {
            num++; // Aumento o numerador em 1
            string idName = "Fluxograma_" + num; // Nomeio o id da aba a partir de sua numeração
            string tabName = "Novo Fluxograma"; // Nomeio a aba a partir de sua numeração

            TabItem novaAba = new TabItem(); // Item que cria nova aba

            TextBlock title = new TextBlock // Define o nome da aba e seu alinhamento
            {
                Text = tabName,
                VerticalAlignment = VerticalAlignment.Center
            };

            StackPanel header = new StackPanel // Permite colocar o botão de fechar na aba
            {
                Orientation = Orientation.Horizontal
            };

            // Adiciono os itens ao header (A nova aba e o botão de fechar)
            header.Children.Add(title);

            // Faço a modificação da aba
            novaAba.Header = header;
            novaAba.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#207c7c7c"));
            novaAba.BorderBrush = Brushes.Black;
            novaAba.Margin = new Thickness(5, 0, 0, 0);
            novaAba.HorizontalAlignment = HorizontalAlignment.Center;
            novaAba.Name = "MainWindowId";

            // Adiciono o conteúdo dentro da janela da aba
            novaAba.Content = new TextBlock
            {
                Text = "Ideias de projeto",
                Margin = new Thickness(10)
            };

            // Adiciono as abas criadas ao TabControl
            abas.Items.Add(novaAba);

            /* Adiciono todas as abas novas criadas à lista e chamo 
            a classe da modificação do nome da aba pra que modifique todos os itens da lista */
            tabList.Add(novaAba);
            new RenameTab(tabList);
            new CloseTabSystem(abas, header, novaAba);
        };
    }
}