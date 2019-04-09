using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class SlidersModel : IFlightComponentModel
    {
        private double rudder;
        private double throttle;


        // properties
        public double Rudder {
            get
            {
                return this.rudder;
            }
            set
            {
                this.rudder = value;
            }
        }
        public double Throttle
        {
            get
            {
                return this.throttle;
            }
            set
            {
                this.throttle = value;
            }


        }

    }
}
