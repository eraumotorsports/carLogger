using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkStream networkStream;
            StreamWriter clientWriter;
            StreamReader clientReader;

            int port = 23;
            long i = 0;
            bool down = false;

            // create a new TCPListener
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(localAddr, port);

            // start the listener
            try
            {
                server.Start();
            }
            catch (SocketException)
            {
                Console.WriteLine("Unable to open socket.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Waiting for a connection on port " + port);
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("connected");

                // create reader and writer
                networkStream = client.GetStream();
                clientWriter = new StreamWriter(networkStream);
                clientReader = new StreamReader(networkStream);

                while (client.Connected)
                {
                    try
                    {
                        clientWriter.WriteLine(i.ToString() + "," + (i + 1).ToString() + "," + (i + 2).ToString() + "," + (i + 3).ToString() + "," + (i + 4).ToString() + "," + (i + 5).ToString());
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("unable to write to client");
                        clientWriter.Close();
                        continue;
                    }
                    Thread.Sleep(10);
                    if (!down)
                        i++;
                    else
                        i--;

                    if (!down && i >= 400)
                        down = true;
                    else if (down && i <= 0)
                        down = false;
                }
                i = 0;
                clientReader.Close();
                clientWriter.Close();
                networkStream.Close();
                client.Close();
            }
        }
    }
}
