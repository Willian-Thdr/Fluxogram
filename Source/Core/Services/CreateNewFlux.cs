using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace Fluxogram.Core.Services;

public static class CreateNewFlux
{
    public static void Connect(Button button, TabControl abas)
    {
        List<int> numerator = new List<int>();
        List<TabItem> tabList = new List<TabItem>();
        int num = 0;

        button.Click += (s, e) =>
        {
            num++;
            numerator.Add(num);
            string idName = "Fluxograma_" + num;
            string tabName = "Fluxograma " + numerator.Count;

            TabItem novaAba = new TabItem();

            novaAba.Header = tabName;
            novaAba.Background = Brushes.White;
            novaAba.Opacity = 0.5;
            novaAba.BorderBrush = Brushes.Black;
            novaAba.Margin = new Thickness(5, 0, 0, 0);
            novaAba.HorizontalAlignment = HorizontalAlignment.Center;
            novaAba.Name = idName;

            novaAba.Content = new TextBlock
            {
                Text = "Ideias de projeto",
                Margin = new Thickness(10)
            };

            abas.Items.Add(novaAba);

            tabList.Add(novaAba);
            new RenameTab(tabList);
        };
    }
}