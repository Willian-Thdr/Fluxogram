using System.Windows.Controls;
using System.Windows.Input;

public class RenameTab
{
    public RenameTab(List<TabItem> abas) // Método onde parâmetro recebe lista de todas as aba da interface
    {
        foreach (TabItem aba in abas) // "Cria" várias abas separadas a partir de todas as abas do parâmetro da classe
        {
            aba.MouseDoubleClick += (s, e) =>
            {
                // Não execulta código se o x:Name for "NaoEditavel"
                if (aba.Name == "NaoEditavel")
                    return;

                // Permite modificar o nome da aba
                TextBox editor = new TextBox
                {
                    Text = aba.Header.ToString()
                };

                // Confirma nome posto quando pressiona enter
                editor.KeyDown += (s2, e2) =>
                {
                    if (e2.Key == Key.Enter)
                    {
                        aba.Header = editor.Text;
                    }
                };

                // É o que vai definir o nome da aba
                aba.Header = editor;
            };
        }
    }
}