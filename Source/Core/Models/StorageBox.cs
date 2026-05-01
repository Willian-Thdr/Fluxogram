using System.Windows.Controls;

public class StorageBox
{
    private static StorageBox? _instance;

    public static StorageBox Instance => _instance ??= new StorageBox();

    public List<object> elementUi { get; set; } = new();
    public List<object> something { get; set; } = new();
    public bool checker { get; set; }
    public List<object> doubles { get; set; } = new();
    public Action? onClick { get; set; }

    // Armazenagem dos componentes de AbrirMenu
    public object canva { get; set; }
}