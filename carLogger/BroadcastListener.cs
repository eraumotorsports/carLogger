using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class BroadcastListener 
{
    private int listenPort = 55555;

    public BroadcastListener(int port)
    {
        listenPort = port;
    }
    
    public void StartListener() 
    {
        bool done = false;
        
        UdpClient listener = new UdpClient(listenPort);
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

        try 
        {
            while (!done) 
            {
                Console.WriteLine("Waiting for broadcast");
                byte[] bytes = listener.Receive( ref groupEP);

                Console.WriteLine("Received broadcast from {0} :\n {1}\n",
                    groupEP.ToString(),
                    Encoding.ASCII.GetString(bytes,0,bytes.Length));
            }
            
        } 
        catch (Exception e) 
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            listener.Close();
        }
    }
}
