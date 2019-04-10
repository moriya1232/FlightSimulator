using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightSimulator;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class TrackFlightModel
    {
        private Communication communicationInfo;
        private double lon;
        private double lat;

        public TrackFlightModel()
        {
            this.communicationInfo = new Communication();
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

        public void open(string ip, int port)
        {
            this.communicationInfo.open(ip, port);
        }
    }
}
