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

            long i = 0;
            bool down = false;
            string message;

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("192.168.1.255");
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);

            while (true)
            {
                message = i.ToString() + "," + (i + 1).ToString() + "," + (i + 2).ToString() + "," + (i + 3).ToString() + "," + (i + 4).ToString() + "," + (i + 5).ToString();
                byte[] sendbuf = Encoding.ASCII.GetBytes(message);

                s.SendTo(sendbuf, ep);

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
        }
    }
}
