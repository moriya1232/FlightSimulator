using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator
{
    class Commands
    {
        private TcpClient client;

        private BinaryWriter writer;

        public bool Connected { get; set; } = false;

        #region Singleton
        private static Commands m_Instance = null;
        public static Commands Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Commands();
                }
                return m_Instance;
            }
        }
        #endregion

        public void Reset() { m_Instance = null; }

        public void Connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            while (!client.Connected) // keep trynig to connect
            {
                try { client.Connect(ep); }
                catch (Exception) { }
            }
            Connected = true;
            writer = new BinaryWriter(client.GetStream());

        }

        public void SendCommands(string input)
        {
            if (string.IsNullOrEmpty(input)) return;
            string[] commands = input.Split('\n');
            foreach (string command in commands)
            {
                string tmp = command + "\r\n";
                writer.Write(System.Text.Encoding.ASCII.GetBytes(tmp));
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}

