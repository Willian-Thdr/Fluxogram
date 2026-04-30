using System.Windows.Controls;
using System.Windows.Media;

namespace Fluxogram.UI.Helper;

public class StyleButtonCode
{
    public StyleButtonCode(List<Button> button)
    {
        ApplyStyle(button);
    }

    public static void ApplyStyle(List<Button> buttons)
    {
        foreach (Button button in buttons)
        {
            button.MouseEnter += (s, e) =>
            {
                ((Button)s).Background = Brushes.DimGray;
            };

            button.MouseLeave += (s, e) =>
            {
                ((Button)s).Background = Brushes.Transparent;
            };
        }
    }
}