using System.Windows.Controls;

public class MenuButtonStyle
{
    public MenuButtonStyle(Button button, bool checker)
    {
        Style(button, checker);
    }

    private static void Style(Button button, bool checker)
    {
        button.MouseEnter += (s, e) =>
        {
            if (checker == false)
            {
                button.Content = "<";
            }
            else
            {
                button.Content = ">";
            }
        };

        button.MouseLeave += (s2, e2) =>
        {
            button.Content = "≡";
        };
    }
}