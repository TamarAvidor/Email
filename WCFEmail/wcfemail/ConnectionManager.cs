using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WcfEmail
{
    public class ConnectionManager
    {
        public event Action<TcpClient> UserRequestEvent;

        private Thread _listenerThread;

        private static readonly ConnectionManager _instance = new ConnectionManager();

        private ConnectionManager() { }

        public static ConnectionManager Instance
        {
            get 
            {
                return _instance; 
            }
        }

        public void StartListensing()
        {
            _listenerThread = new Thread(RunServer);
            _listenerThread.IsBackground = true;
            _listenerThread.Start();
        }

        private void RunServer()
        {
            IPAddress SerIp = IPAddress.Parse("127.0.0.1");
            TcpListener listen = new TcpListener(SerIp, 2525);
            listen.Start();

            while (true)
            {
                var client = listen.AcceptTcpClient();

                if (UserRequestEvent != null)
                {
                    UserRequestEvent(client);
                }
            }
        }

        public void Send(StreamWriter writer, string message)
        {
            writer.WriteLine(message);

            writer.Flush();
        }

    }
}
