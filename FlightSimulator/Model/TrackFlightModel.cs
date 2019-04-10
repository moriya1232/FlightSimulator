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

        TrackFlightModel(Communication ci)
        {
            this.communicationInfo = ci;
        }

        private double Lat
        {
            get { return this.lat; }
            set { this.lat = value; }
        }

        private double Lon
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
