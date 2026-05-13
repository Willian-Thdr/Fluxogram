using System.Windows.Controls;

public class DelObjects
{
    public static void Delete(Canvas canva, Grid vis)
    {
        var RemoveConnections = StorageConnections.Connections.Where(c => c.Start == vis || c.End == vis).ToList();

        foreach (var conn in RemoveConnections)
        {
            canva.Children.Remove(conn.Line);
            StorageConnections.Connections.Remove(conn);
        }

        canva.Children.Remove(vis);
    }
}