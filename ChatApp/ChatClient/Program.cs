using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Type your name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You can't connect to the server because you sucks");
                return;
            }
            TcpClient client = new TcpClient("127.0.0.1", 13000);

            Console.WriteLine("The connection was success");

            NetworkStream clientStream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(name);
            await clientStream.WriteAsync(buffer, 0, buffer.Length);

            byte[] buffer2 = new byte[1024];
            int bu = await clientStream.ReadAsync(buffer2, 0, buffer2.Length);
            string welcomeMessage = Encoding.UTF8.GetString(buffer2, 0, bu);
            Console.WriteLine(welcomeMessage);


            var broadcastTask = Task.Run(() => BroadcastListenerMessage(client));

            while (true)
            {
                Console.Write("You> ");
                string message = Console.ReadLine();
                string messageWithName = $"{message}";
                if (message == "Exit") break;

                byte[] buffer3 = Encoding.UTF8.GetBytes(messageWithName);
                await clientStream.WriteAsync(buffer3, 0, buffer3.Length);
            }
            await broadcastTask;
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static async Task BroadcastListenerMessage(TcpClient client)
    {
        try
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            while (true)
            {
                int bytes = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytes == 0)
                {
                    // El servidor cerró la conexión
                    Console.WriteLine("Disconnected from server.");
                    break;
                }
                string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                Console.WriteLine(message);
                Console.Write("You> ");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}