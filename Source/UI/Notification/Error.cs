using System.Windows;

public class Error
{
    public static void ShowError(string txt)
    {
        if (txt.IsWhiteSpace())
            return;

        MessageBox.Show(txt);
    }
}