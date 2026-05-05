using System.Windows.Controls;

public class StorageBox
{
    private static StorageBox? _instance;

    public static StorageBox Instance => _instance ??= new StorageBox();

    public List<object> something { get; set; } = new();
    public Action? onClick { get; set; }
}