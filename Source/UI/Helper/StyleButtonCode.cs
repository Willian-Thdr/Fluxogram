using System.Windows.Controls;
using System.Windows.Media;

namespace Fluxogram.UI.Helper;

public class StyleButtonCode
{
    public StyleButtonCode(List<Button> button)
    {
        style(button); // Chamo a classe de modificação para modificar itens chamados no parâmetro da classe
    }

    private static void style(List<Button> buttons) // Cria uma classe que receberá o valor do parâmetro da classe principal
    {
        foreach (Button button in buttons) // Eu "crio" botões independentes a partir de quantos haver na Lista do parâmetro
        {
            // Evento de mouse
            button.MouseEnter += (s, e) =>
            {
                ((Button)s).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#207ab3da")); // Quando o mouse estiver em cima, muda o Background para DimGray 
            };

            button.MouseLeave += (s, e) =>
            {
                ((Button)s).Background = Brushes.Transparent; // Quando o mouse não estiver em cima, o background permanece normal
            };
        }
    }
}