using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

public class CloseTabSystem
{
    public CloseTabSystem(TabControl abas, TabItem novaAba, StackPanel panel)
    {
        List<TabItem> tabList = new List<TabItem>(); // Listas que receberá todos os ids de todas as abas
        List<TabItem> itemList = new List<TabItem>();

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

        panel.Children.Add(close);

        // Comando de fechar determinada aba
        close.Click += (s2, e2) =>
        {
            abas.Items.Remove(novaAba);
        };
    }
}