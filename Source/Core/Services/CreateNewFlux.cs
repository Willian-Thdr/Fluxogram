using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace Fluxogram.Core.Services;

public static class CreateNewFlux
{
    public static void Connect(Button button, TabControl abas)
    {
        List<int> numerator = new List<int>(); // Lista que enumera quantas abas foram criadas
        List<TabItem> tabList = new List<TabItem>(); // Listas que receberá todos os ids de todas as abas
        int num = 0; // Numerdor do total de abas

        // Evento de quando o botão de criar aba é clicado
        button.Click += (s, e) =>
        {
            num++; // Aumento o numerador em 1
            numerator.Add(num); // Adiciono o numerador à lista
            string idName = "Fluxograma_" + num; // Nomeio o id da aba a partir de sua numeração
            string tabName = "Fluxograma " + numerator.Count; // Nomeio a aba a partir de sua numeração

            TabItem novaAba = new TabItem(); // Item que cria nova aba

            TextBlock title = new TextBlock // Define o nome da aba e seu alinhamento
            {
                Text = tabName,
                VerticalAlignment = VerticalAlignment.Center
            };

            Button close = new Button // Item que cria botão para fechar aba
            {
                Content = "x", // Conteúdo do botão
                Width = 18, // Largura do botão
                Height = 18, // Altura do botão
                Margin = new Thickness(0), // Margem dele em relação ao TabItem
                Padding = new Thickness(0), // Espaço interno do botão
                Background = Brushes.Transparent, // Defino a cor do fundo
                BorderBrush = Brushes.Transparent, // Defino a cor da borda
                Cursor = System.Windows.Input.Cursors.Hand // Reconhece quando cursor pass por cima
            };

            StackPanel header = new StackPanel // Permite colocar o botão de fechar na aba
            {
                Orientation = Orientation.Horizontal
            };

            // Adiciono os itens ao header (A nova aba e o botão de fechar)
            header.Children.Add(title);
            header.Children.Add(close);

            // Faço a modificação da aba
            novaAba.Header = header;
            novaAba.Background = Brushes.White;
            novaAba.Opacity = 0.5;
            novaAba.BorderBrush = Brushes.Black;
            novaAba.Margin = new Thickness(5, 0, 0, 0);
            novaAba.HorizontalAlignment = HorizontalAlignment.Center;
            novaAba.Name = idName;

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
        };
    }
}