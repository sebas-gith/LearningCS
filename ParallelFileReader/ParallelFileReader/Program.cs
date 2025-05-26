using System;
using System.IO;
using System.IO.Enumeration;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
class Program
{
    public static async Task Main(string[] args)
    {
        if (!Directory.Exists("Files"))
        {
            throw new Exception("The file folder doesn't exist");
        }
        string[] files = Directory.GetFiles("files");

        List<Task> tasks = new List<Task>();

        foreach (string file in files) 
        {
            tasks.Add(ReadFile(file));
        }

        await Task.WhenAll(tasks);
    }

    public static async Task ReadFile(string path)
    {
        try
        {
            long wordsTotal = 0;
            long chTotal = 0;
            int lines = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    wordsTotal += line.Split(" ").Length;
                    chTotal += line.Length;
                    ++lines;
                }
            }

            Console.WriteLine($"{path} Tiene \n{wordsTotal} palabras.\n{chTotal} caracteres\n{lines} lineas");
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }

    }
}
