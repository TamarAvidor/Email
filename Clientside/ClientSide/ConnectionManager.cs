using ClientSide.ServerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ClientSide
{
    public class ConnectionManager
    {
        public event Action AcknowledgeEvent;
        public event Action DisconnectEvent;

        private static readonly ConnectionManager _instance = new ConnectionManager();
        private EmailServiceClient _server;
        private TcpClient _client;
        private bool _isConnected;
        private string _ipAddress;
        private string _username;
        private string _password;

        private NetworkStream _stream;
        private StreamReader _reader;
        private StreamWriter _writer;

        public EmailServiceClient Server 
        { 
            get 
            {
                return _server;
            }
        }

        public TcpClient Client
        {
            get
            {
                return _client;
            }
        }

        public NetworkStream Stream
        {
            get
            {
                return _stream;
            }
        }

        public StreamReader Reader
        {
            get
            {
                return _reader;
            }
        }

        public StreamWriter Writer
        {
            get
            {
                return _writer;
            }
        }

        private ConnectionManager() { _isConnected = false; }

        public static ConnectionManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Init(string ipAddress, string username, string password)
        {
            _ipAddress = ipAddress;
            _username = username;
            _password = password;
        }

        public void WCFConnect()
        {
            _server = new EmailServiceClient();
            _server.Connect();
        }

        public bool Connect()
        {
            if (!_isConnected)
            {
                try
                {
                    _client = new TcpClient();
                    _client.Connect(_ipAddress, 2525);

                    _stream = _client.GetStream();
                    _reader = new StreamReader(_stream);
                    _writer = new StreamWriter(_stream);

                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("Connecting");
                    builder.AppendLine(_username);
                    builder.AppendLine(_password);

                    _isConnected = true;
                    Send(builder.ToString());
                    HandleConnectionResponse();
                }
                catch (Exception ex)//find which ex is the correct one.
                {
                    _isConnected = false;
                }
            }

            return _isConnected;
        }

        public void Close()
        {
            _isConnected = false;
            try
            {
                _client.Close();
            }
            catch { }
        }

        public void Send(string message)
        {
            if(Connect())
            {
                _writer.WriteLine(message);

                _writer.Flush();
            }
        }

        public void Send(byte[] message)
        {
            if (Connect())
            {
                _stream.Write(message, 0, message.Length);
            }
        }

        public static T BinaryDeserialize<T> ()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            return (T)binaryFormatter.Deserialize(ConnectionManager.Instance.Stream);
        }

        private void HandleConnectionResponse()
        {
            bool shouldWait = true;

            while (shouldWait)
            {
                string userRequest = _reader.ReadLine();

                if (userRequest == "Acknowledge")
                {
                    shouldWait = false;

                    if (AcknowledgeEvent != null)
                    {
                        AcknowledgeEvent();
                    }
                }
                
                else if (userRequest == "Disconnect")
                {
                    shouldWait = false;
                    Close();

                    if(DisconnectEvent != null)
                    {
                        DisconnectEvent();
                    }
                }

            }
        }

    }
}
