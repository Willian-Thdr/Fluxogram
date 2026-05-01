using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Fluxogram.Core.Services;
using Fluxogram.UI.Helper;

namespace Fluxogram.Source.Application;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent(); // Chamo a classe xaml principal e executo ela
        bool check = false;
        AbrirMenu a = new AbrirMenu();

        MenuButton.Click += (s2, e2) =>
        {
            var grid = (Grid)canvasRoot.Children[0];
            var coluna = grid.ColumnDefinitions[0];

            if (coluna.Width.Value > 0)
            {
                new MenuButtonFunc(MenuButton, MainWindowId, true, "<", coluna, coluna.Width.Value, 0, () =>
                {
                    new MenuButtonFunc(MenuButton, MainWindowId, false, "≡", coluna, coluna.Width.Value, 220, null);
                });
            }
        };

        // Evento que será execultado apenas quando a janela terminar de carregar. Para evitar chash e conflitos
        Loaded += (s, e) =>
        {
            var grid = (Grid)canvasRoot.Children[0];
            var coluna = grid.ColumnDefinitions[0];

            List<Button> buttons = GetAllChildrenButton<Button>(this); // Crio uma lista para receber todos os botões da interface
            List<TabItem> tabs = GetAllChildrenTab<TabItem>(this);

            // Chamo os métodos
            new StyleButtonCode(buttons);
            new RenameTab(tabs);
            new MenuButtonStyle(MenuButton, check);

            // Chamo o método de criar novas abas. (Ele recebe o valor do comando do botão pressionado, O nome do TabControl)
            CreateNewTab.Connect(CreateFlux, Abas, tabs);
        };
    }

    public static List<B> GetAllChildrenButton<B>(DependencyObject parent) // Método que pega todos os botões da interface
    where B : DependencyObject // Filtro apenas o que é botão
    {
        List<B> result = new List<B>(); // Lista para receber todos os botões

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++) // Repete o numero de vezes até i ser = ao número de botões
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i); // Pega cada botão da interface e aplica um a um em child

            // Se child for parâmetro B (Definido para buttons), ele adicionará typedChild à lista result
            if (child is B typedChild)
                result.Add(typedChild);

            // Adiciona todos os itens tipo B (buttons) encontrado no child e adiciona à lista
            result.AddRange(GetAllChildrenButton<B>(child));
        }

        // Retorna valor de result para a lista
        return result;
    }

    // Repete o mesmo que o código de cima, mas para itens diferentes
    public static List<T> GetAllChildrenTab<T>(DependencyObject parent)
    where T : DependencyObject
    {
        List<T> result = new List<T>();

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);

            if (child is T typedChild)
                result.Add(typedChild);

            result.AddRange(GetAllChildrenTab<T>(child));
        }

        return result;
    }
}