using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;

public class ObjectOptions
{
    public static void Connections(Grid obj, TextBlock txt)
    {
        if (txt == null)
            return;

        TextBox editor = new TextBox
        {
            Text = txt.Text,
            TextWrapping = TextWrapping.Wrap,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            FontSize = 16
        };

        int index = obj.Children.IndexOf(txt);

        obj.Children.Remove(txt);
        obj.Children.Insert(index, editor);

        editor.KeyDown += (s2, e2) =>
        {
            if (e2.Key == Key.Enter)
            {
                txt.Text = editor.Text;
                txt.HorizontalAlignment = editor.HorizontalAlignment;
                txt.VerticalAlignment = editor.VerticalAlignment;
                txt.FontSize = editor.FontSize;

                obj.Children.Remove(editor);
                obj.Children.Insert(index, txt);
            }
        };
    }
}