using System.Windows.Controls;
using System.Windows.Shapes;

public class Connection
{
    public Grid Start { get; set; }
    public Grid End { get; set; }
    public Path Line { get; set; }

    public Connection(Grid start, Grid end, Path line)
    {
        Start = start;
        End = end;
        Line = line;
    }
}