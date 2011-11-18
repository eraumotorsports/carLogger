using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Dashboard
{
    public class BroadcastListener
    {
        private UdpClient mpUdpClient;
        private IPEndPoint mpEndPoint;
        private bool mpActive, mpMessageReceived;
        
        public event EventHandler<UdpEventArgs> Received;

        /// <summary>
        /// Creates a UDP BroadcastListener
        /// </summary>
        /// <param name="port">The port to listen for UDP messages on</param>
        public BroadcastListener(int port)
        {
            mpUdpClient = new UdpClient(port);
            mpEndPoint = new IPEndPoint(IPAddress.Any, port);
        }

        public void StartListener()
        {
            mpActive = true;

            while (mpActive)
            {
                mpMessageReceived = false;
                //byte[] bytes = mpUdpClient.Receive(ref mpEndPoint);
                mpUdpClient.BeginReceive(new AsyncCallback(ReceiveCallback), this.mpUdpClient);

                while (!mpMessageReceived)
                    Thread.Sleep(100);

            }
        }

        public void StopListener()
        {
            mpActive = false;
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            byte[] bytes = mpUdpClient.EndReceive(ar, ref mpEndPoint);
            UdpEventArgs udpAgs = new UdpEventArgs(Encoding.ASCII.GetString(bytes, 0, bytes.Length));
            OnReceived(udpAgs);
            mpMessageReceived = true;
        }

        protected virtual void OnReceived(UdpEventArgs e)
        {
            if (Received != null)
                Received(this, e);
        }
    }

    public class UdpEventArgs : EventArgs
    {
        public UdpEventArgs(string message) {
            this.message = message;
            }

        public string message;
    }
}
