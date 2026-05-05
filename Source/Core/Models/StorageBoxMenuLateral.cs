using System.ComponentModel;
using System.Windows.Controls;

public class StorageBoxMenuLateral
{
    private static StorageBoxMenuLateral? _instance;

    public static StorageBoxMenuLateral Instance => _instance ??= new StorageBoxMenuLateral();

    public object? coluna { get; set; }
    public List<Canvas>? canvas { get; set; } = new();
}