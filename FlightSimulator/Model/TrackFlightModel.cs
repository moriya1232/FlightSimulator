﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
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
        public event PropertyChangedEventHandler LatLonChanged;

        // a constructor
        public TrackFlightModel()
        {
            this.info = new Info();
            this.sdts = new Commands();
        }

        // property Lat
        public double Lat
        {
            get { return this.lat; }
            set { this.lat = value; }
        }

        // property Lon
        public double Lon
        {
            get { return this.lon; }
            set {
                this.lon = value;
            }
        }

        // open the Info channel and receive data in another thread
        public void Open(string ip, int port)
        {
            info.Open(ip, port);
            GetData();
        }

        // receive data about the lon, lat properties from the simulator
        void GetData()
        {
            new Task(delegate ()
            {
                while (!info.Stop)
                {
                    // get the updated info and set the new values
                    string[] args = info.Read();
                    Lon = Convert.ToDouble(args[0]);
                    Lat = Convert.ToDouble(args[1]);
                }
            }).Start();
        }

        // returns the connection status
        public bool IsConnected() { return info.Connected; }

        // stops the data receiving
        public void StopRead() { info.Stop = true; }
    }
}
