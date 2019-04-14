using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace FlightSimulator
{
    // info opens a server that makes our app capable of receives info
    // from the simulator
    class Info
    {
        public bool Connected { get; set; } = false;
        public bool Stop { get; set; } = false;
        private TcpListener listener;
        private TcpClient client;
        private BinaryReader reader;

        // open the server by the given ip and port
        public void Open(string ip, int port)
        {
            if (listener != null) Close();
            listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            listener.Start();
        }

        public void Close() { client.Close(); listener.Stop(); Connected = false; }

        // read data from the server
        public string[] Read()
        {
            if (!Connected)
            {
                Connected = true;
                client = listener.AcceptTcpClient();
                reader = new BinaryReader(client.GetStream());
            }
            string input = "";
            char s;
            while ((s = reader.ReadChar()) != '\n') input += s;
            string[] data = input.Split(',');
            string[] result = { data[0], data[1] };
            return result;
        }
    }
}
