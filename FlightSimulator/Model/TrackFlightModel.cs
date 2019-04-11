using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightSimulator;
using System.Threading.Tasks;
using System.Threading;

namespace FlightSimulator.Model
{
    class TrackFlightModel
    {
        private Info info;
        private Commands sdts;
        private double lon;
        private double lat;

        public TrackFlightModel()
        {
            this.info = new Info();
            this.sdts = new Commands();
        }

        public double Lat
        {
            get { return this.lat; }
            set { this.lat = value; }
        }

        public double Lon
        {
            get { return this.lon; }
            set {
                this.lon = value;
            }
        }

        public void Open(string ip, int port)
        {
            this.info.open(ip, port);
            StartRead();
        }

        void StartRead()
        {
            new Thread(delegate ()
            {
                while (!info.Stop)
                {
                    string[] args = info.Read();
                    Lon = Convert.ToDouble(args[0]);
                    Lat = Convert.ToDouble(args[1]);
                }
            }).Start();
        }

        public bool IsConnected() { return info.Connected; }

        public void StopRead() { info.Stop = true; }
    }
}
