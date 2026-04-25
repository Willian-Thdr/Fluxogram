using System.Windows;
using System.Windows.Controls;

namespace Fluxogram.Core.Services;

public static class CreateNewFlux
{
    public static void Connect(Button button)
    {
        button.Click += (s, e) =>
        {
            MessageBox.Show("Yeahhhh");
        };
    }
} 