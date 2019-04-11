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
    class Info
    {
        public bool Connected { get; set; } = false;
        public bool Stop { get; set; } = false;
        private TcpListener server;
        private TcpClient client;
        private BinaryReader reader;

        public void open(string ip, int port)
        {
            this.server = new TcpListener(IPAddress.Parse(ip), port);
            server.Start();
        }

        public string read()
        {
            Byte[] bytes = new Byte[256];
            String data = null;

            while (true)
            {
                Console.Write("Waiting for a connection... ");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = null;
                NetworkStream stream = client.GetStream();
                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

               
                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }
            }
            return data;
        }

        public string[] Read()
        {
            if (!Connected)
            {
                Connected = true;
                client = server.AcceptTcpClient();
                reader = new BinaryReader(client.GetStream());
            }
            string input = ""; 
            char s;
            while ((s = reader.ReadChar()) != '\n') input += s;
            string[] param = input.Split(','); 
            string[] ret = { param[0], param[1] }; 
            return ret;

        }

     
        public void close()
        {
            this.server.Stop();
            this.client.Close();
        }

    }
}
