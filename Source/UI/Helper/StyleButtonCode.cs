using System.Windows.Controls;
using System.Windows.Media;

namespace Fluxogram.UI.Helper;

public class StyleButtonCode
{
    public StyleButtonCode(List<Button> button)
    {
        ApplyStyle(button); // Chamo a classe de modificação para modificar itens chamados no parâmetro da classe
    }

    public static void ApplyStyle(List<Button> buttons) // Cria uma classe que receberá o valor do parâmetro da classe principal
    {
        foreach (Button button in buttons) // Eu "crio" botões independentes a partir de quantos haver na Lista do parâmetro
        {
            // Evento de mouse
            button.MouseEnter += (s, e) =>
            {
                ((Button)s).Background = Brushes.DimGray; // Quando o mouse estiver em cima, muda o Background para DimGray 
            };

            button.MouseLeave += (s, e) =>
            {
                ((Button)s).Background = Brushes.Transparent; // Quando o mouse não estiver em cima, o background permanece normal
            };
        }
    }
}