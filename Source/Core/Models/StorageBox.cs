using System.Windows.Controls;

public class StorageBox
{
    private static StorageBox? _instance;

    public static StorageBox Instance => _instance ??= new StorageBox();

    public bool verify { get; set; }
    public List<TextBlock> titles { get; set; } = new();
}