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
        //from sliders
        private double rudder;
        private double throttle;

        //from joystick
        private double aileron;
        private double elevator;


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
        public double Aileron
        {
            get
            {
                return this.aileron;
            }
            set
            {
                this.aileron = value;
            }
        }
        public double Elevator
        {
            get
            {
                return this.elevator;
            }
            set
            {
                this.elevator = value;
            }
        }
    }
}
