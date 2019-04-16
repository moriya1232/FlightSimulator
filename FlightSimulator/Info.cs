using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using FlightSimulator.ViewModels;

namespace FlightSimulator
{
    // info opens a server that makes our app capable of receives info
    // from the simulator
    class Info :BaseNotify
    {
        public bool Connected { get; set; } = false;
        public bool Stop { get; set; } = false;
        private TcpListener listener;
        private TcpClient client;
        private BinaryReader reader;
        private double? lon;
        private double? lat;


        private Info()
        {
            lon = null;
            lat = null;
        }
        #region Singleton
        private static Info m_Instance = null;
        public static Info Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Info();
                }
                return m_Instance;
            }
        }
        #endregion

        // property Lat
        public double? Lat
        {
            get { return this.lat; }
            set
            {
                this.lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        // property Lon
        public double? Lon
        {
            get { return this.lon; }
            set
            {
                this.lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        // open the server by the given ip and port
        public void Open(string ip, int port)
        {
            if (listener != null) Close();
            listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            listener.Start();
        }

        public void Close() { client.Close(); listener.Stop(); Connected = false; }

        // read data from the server
        public String[] Read()
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
            this.Lon = double.Parse(data[0]);
            this.Lat = double.Parse(data[1]);
            string[] result = { data[0], data[1] };

            return result;
        }
    }
}
