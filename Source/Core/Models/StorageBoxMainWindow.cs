using System.Windows.Controls;

public class StorageBoxMainWindow
{
    private static StorageBoxMainWindow? _instance;

    public static StorageBoxMainWindow Instance => _instance ??= new StorageBoxMainWindow();

    public List<Canvas>? canva { get; set; } = new();
    public Canvas? mainCanva { get; set; }
    public Button? button { get; set; }
    public Button? salveButton { get; set; }
    public double doubles { get; set; }
    public bool checker { get; set; }
    public ColumnDefinition? coluna { get; set; }
}