using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace carLogger
{
    public class TCPSocket
    {
        private Configuration mConfig = new Configuration();
        private Socket mSocket;
        private NetworkStream mStream;
        private StreamReader mReader;

        public TCPSocket()
        {
            try
            {
                IPHostEntry host;
                host = Dns.GetHostEntry(mConfig.Hostname);
                mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                mSocket.Connect(host.AddressList, mConfig.Port);
                mStream = new NetworkStream(mSocket);
                mReader = new StreamReader(mStream);
            }
            catch (IOException ex)
            {
                
            }
            catch (SocketException ex)
            {

            }
        }

        public string ReadLine()
        {
            try
            {
                if (Open())
                    return mReader.ReadLine();
                else
                    return "SOCKET ERROR";
            }
            catch (IOException ex)
            {
                return "SOCKET ERROR";
            }
        }

        public void RefreshSettings()
        {
            try
            {
                if (Open())
                {
                    mReader.Close();
                    mStream.Close();
                    mSocket.Close();
                }
                IPHostEntry host;
                host = Dns.GetHostEntry(mConfig.Hostname);
                mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                mSocket.Connect(host.AddressList, mConfig.Port);
                mStream = new NetworkStream(mSocket);
                mReader = new StreamReader(mStream);
            }
            catch (IOException ex)
            {

            }
            catch (SocketException ex)
            {

            }
        }

        public void Close()
        {
            mReader.Close();
            mStream.Close();
            mSocket.Close();
        }

        public bool Open()
        {
            return mSocket.Connected;
        }
    }
}
