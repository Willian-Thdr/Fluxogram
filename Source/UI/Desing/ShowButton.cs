using System.Windows;
using System.Windows.Controls;
using Fluxogram.Source.Application;

public class ShowButton
{
    static List<Canvas>? canvaList = new List<Canvas>();

    public static void ShowBtn(List<Canvas> canvas, bool check)
    {
        foreach (Canvas canva in canvas)
        {
            if (canva == null)
                return;

            if (!check)
                return;

            Button lateralButton = new Button()
            {
                Content = "≡",
                Width = 22,
                Height = 18,
                FontSize = 18,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };

            Canvas.SetTop(lateralButton, 100);

            canva.Children.Add(lateralButton);

            lateralButton.Click += (s, e) =>
            {
                Hide(canva, lateralButton);
            };
        }
    }

    public static void getCanva1(bool check)
    {
        canvaList = StorageBoxMenuLateral.Instance.canvas;
        ShowBtn(canvaList, check);
    }

    private static void Hide(Canvas? canvas, Button? lateralButton)
    {
        Button? button = StorageBoxMainWindow.Instance.button;
        double colunaWV = StorageBoxMainWindow.Instance.doubles;
        ColumnDefinition? coluna = StorageBoxMainWindow.Instance.coluna;
        bool? check = StorageBoxMainWindow.Instance.checker;

        MainWindow.MenuAction(button, coluna, colunaWV, 220);
        canvas.Children.Remove(lateralButton);
    }
}