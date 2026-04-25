using System.DirectoryServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Fluxogram.Core.Services;
using Fluxogram.UI.Helper;

namespace Fluxogram.Source.Application;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Loaded += (s, e) =>
        {
            List<Button> buttons = GetAllChildren<Button>(this);
            new StyleButtonCode(buttons);

            CreateNewFlux.Connect(CreateFlux);
        };
    }

    public static List<T> GetAllChildren<T>(DependencyObject parent)
    where T :DependencyObject
    {
        List<T> result = new List<T>();

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);

            if (child is T typedChild)
                result.Add(typedChild);

            result.AddRange(GetAllChildren<T>(child));
        }

        return result;
    }
}