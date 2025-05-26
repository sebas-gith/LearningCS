using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Net;

class Program
{

    public static async Task Main(string[] args)
    {
        IList<string> linkList = new List<string>();
        try
        {
            using (StreamReader reader = new StreamReader("links.txt"))
            {
                string? line; 
                while ((line = reader.ReadLine())!= null) { 
                    linkList.Add(line);
                }
            } 
        }
        catch (Exception ex) {
            Console.WriteLine(ex);       
        }

        string imagesDirectory = "images";
        if (!Directory.Exists(imagesDirectory))
            Directory.CreateDirectory(imagesDirectory);

        HttpClient client = new HttpClient();

        string BaseName = "image";

        int i = 1; 
        foreach (string link in linkList)
        {
            Console.WriteLine($"Descargando imagen {BaseName}{i} ....");
            byte[] buffer = await client.GetByteArrayAsync(link);

            string fullPath = Path.Combine(imagesDirectory, $"{BaseName}{i}.jpg");

            File.WriteAllBytes(fullPath, buffer);
            ++i;
            Console.WriteLine($"{BaseName}{i}.jpg guardada correctamente");
        }

        Console.WriteLine("");
    }
}