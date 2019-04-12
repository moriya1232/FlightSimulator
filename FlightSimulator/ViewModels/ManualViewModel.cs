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
        private string throttleSet = "/controls/engines/current-engine/throttle";
        private string rudderSet = "/controls/flight/rudder";
        private string elevatorSet = "/controls/flight/elevator";
        private string aileronSet = "/controls/flight/aileron";
        private ManualModel model;

        public ManualViewModel()
        {
            this.model = new ManualModel();
        }

        public double Rudder
        {
            set => model.implement("set " + rudderSet + " " + Convert.ToString(value));
        }

        public double Throttle
        {
            set => model.implement("set " + throttleSet + " " + Convert.ToString(value));
        }

        public double Aileron
        {
            set => model.implement("set " + aileronSet + " " + Convert.ToString(value));
        }

        public double Elevator
        {
            set => model.implement("set " + elevatorSet + " " + Convert.ToString(value));
        }
    }
}
