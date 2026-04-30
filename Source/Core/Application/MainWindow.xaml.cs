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
            List<Button> buttons = GetAllChildrenButton<Button>(this);
            List<TabItem> tabs = GetAllChildrenTabs<TabItem>(this);
            List<TabItem> newTabs = GetAllChildrenTab<TabItem>(this);
            new StyleButtonCode(buttons);
            new RenameTab(newTabs);

            CreateNewFlux.Connect(CreateFlux, Abas);
        };
    }

    public static List<B> GetAllChildrenButton<B>(DependencyObject parent)
    where B : DependencyObject
    {
        List<B> result = new List<B>();

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);

            if (child is B typedChild)
                result.Add(typedChild);

            result.AddRange(GetAllChildrenButton<B>(child));
        }

        return result;
    }

    public static List<T> GetAllChildrenTabs<T>(DependencyObject parent)
    where T : DependencyObject
    {
        List<T> result = new List<T>();

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);

            if (child is T typedChild)
                result.Add(typedChild);

            result.AddRange(GetAllChildrenTabs<T>(child));
        }

        return result;
    }

    public static List<T> GetAllChildrenTab<T>(DependencyObject parent)
    where T : DependencyObject
    {
        List<T> result = new List<T>();

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);

            if (child is T typedChild)
                result.Add(typedChild);

            result.AddRange(GetAllChildrenTab<T>(child));
        }
        return result;
    }

}