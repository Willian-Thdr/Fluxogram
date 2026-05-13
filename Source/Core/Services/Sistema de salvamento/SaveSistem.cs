using System.IO;

public class SaveSistem : Salve
{
    public void Salvar(string content)
    {
        string archiveWay = @"C:\Users\angel\OneDrive\Documents\Fluxogram\" + content + ".txt";
        try
        {
            string? pasta = Path.GetDirectoryName(archiveWay);
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            File.WriteAllText(archiveWay, content);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error " + e.Message);
        }
    }

    public string Content()
    {
        return "Salvo";
    }
}