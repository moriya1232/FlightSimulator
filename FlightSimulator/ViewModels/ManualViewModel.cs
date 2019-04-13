using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel
    {
        private string throttlePath = "/controls/engines/current-engine/throttle";
        private string rudderPath = "/controls/flight/rudder";
        private string elevatorPath = "/controls/flight/elevator";
        private string aileronPath = "/controls/flight/aileron";
        private ManualModel model;

        public ManualViewModel()
        {
            this.model = new ManualModel();
            //this.model.GetCommand();
        }

        public double Rudder
        {
            set => model.sendCommand("set " + rudderPath + " " + Convert.ToString(value));
        }

        public double Throttle
        {
            set => model.sendCommand("set " + throttlePath + " " + Convert.ToString(value));
        }

        public double Aileron
        {
            set => model.sendCommand("set " + aileronPath + " " + Convert.ToString(value));
        }

        public double Elevator
        {
            set => model.sendCommand("set " + elevatorPath + " " + Convert.ToString(value));
        }
    }
}
