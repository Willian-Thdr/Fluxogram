using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

public class RenameTab
{
    public static void Rename(TabItem abas) // Método onde parâmetro recebe lista de todas as aba da interface
    {
        // Não execulta código se o x:Name for "NaoEditavel"
        if (abas.Name == "NaoEditavel")
            return;

        // Se aba não estiver em header, ele retorna
        if (abas.Header is not StackPanel header)
            return;

        // Permite modificar o nome da aba
        TextBlock? title = header.Children.OfType<TextBlock>().FirstOrDefault();

        // Retorna caso não haja título
        if (title == null)
            return;


        // Responsável por adicionar e retirar o texto na modificação
        TextBox editor = new TextBox
        {
            Text = title.Text,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            FontSize = 14,
            Width = 120
        };

        // Descobre qual o posição do title no header (StackPanel)
        int index = header.Children.IndexOf(title);

        // Substitui o título do editor
        header.Children.Remove(title);
        header.Children.Insert(index, editor);

        editor.Focus(); // Coloca o cursor automaticamente no TextBox
        editor.SelectAll(); // Seleciona todo o texto

        // Confirma nome posto quando pressiona enter
        editor.KeyDown += (s2, e2) =>
        {
            if (e2.Key == Key.Enter)
            {
                title.Text = editor.Text;
                title.HorizontalAlignment = editor.HorizontalAlignment;
                title.VerticalAlignment = editor.VerticalAlignment;
                title.FontSize = editor.FontSize;

                header.Children.Remove(editor);
                header.Children.Insert(index, title);
            }
        };
    }
}