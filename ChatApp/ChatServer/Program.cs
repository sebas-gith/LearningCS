using System;
using System.Net.Sockets;
using System.Net;
using System.Text;


class Program
{
    static List<TcpClient> tcpClients= new List<TcpClient>();
    static readonly object clientLocks = new object();
    static async Task Main(string[] args)
    {
        int port = 13000;
        TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
        tcpListener.Start();

        Console.WriteLine($"Listening in iP: {IPAddress.Any} and port: {port}");
        while (true)
        {
            TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
            lock (clientLocks)
            {
                tcpClients.Add(tcpClient);
            }
            _ = Task.Run(() => HandleClientAsync(tcpClient));
        }
    }

    static async Task BreadCastMessageAsync(string message, TcpClient excludedClient)
    {
        Byte[] buffer = Encoding.UTF8.GetBytes(message);

        List<TcpClient> tcpClientsCopy;

        lock (clientLocks)
        {
            tcpClientsCopy = tcpClients.ToList();
        }

        foreach (TcpClient tcpClient in tcpClientsCopy)
        {
            if (tcpClient == excludedClient) continue;

            try
            {
                NetworkStream stream = tcpClient.GetStream();
                await stream.WriteAsync(buffer, 0, buffer.Length); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }

    public static async Task HandleClientAsync(TcpClient tcpClient)
    {
        try
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[1024];
            int byteRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string name = Encoding.UTF8.GetString(buffer, 0, byteRead);


            byte[] welcomeData = Encoding.UTF8.GetBytes($"Welcome {name}, you are successfully connected");
            await stream.WriteAsync(welcomeData, 0, welcomeData.Length);

            IPEndPoint? remoteEndpoint = tcpClient.Client.RemoteEndPoint as IPEndPoint;
            string ip = remoteEndpoint?.Address.ToString();
            Console.WriteLine($"The user {name} is connected from ip {ip}");

            while (true)
            {
                byte[] messageBytes = new byte[1024];
                int byteR = await stream.ReadAsync(messageBytes, 0, messageBytes.Length);

                if (byteR == 0)
                {
                    lock (clientLocks)
                    {
                        tcpClients.Remove(tcpClient);
                    }
                    tcpClient.Close();
                    Console.WriteLine($"{name} disconnected.");
                    break;
                }

                string message = Encoding.UTF8.GetString(messageBytes, 0, byteR);
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine($"{name}> {message} ");

                    await BreadCastMessageAsync($"\n{name}> {message}", tcpClient);
                }
            }
            Console.WriteLine("Client disconnected");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


}