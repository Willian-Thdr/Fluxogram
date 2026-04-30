using System.Windows.Controls;
using System.Windows.Input;

public class RenameTab
{
    public RenameTab(List<TabItem> abas)
    {
        foreach (TabItem aba in abas)
        {
            aba.MouseDoubleClick += (s, e) =>
            {
                if (aba.Name == "NaoEditavel")
                    return;

                TextBox editor = new TextBox
                {
                    Text = aba.Header.ToString()
                };

                editor.KeyDown += (s2, e2) =>
                {
                    if (e2.Key == Key.Enter)
                    {
                        aba.Header = editor.Text;
                    }
                };

                aba.Header = editor;
            };
        }
    }
}