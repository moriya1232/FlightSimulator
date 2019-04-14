using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ManualModel
    {
        private double rudder;
        private double throttle;
        private double aileron;
        private double elevator;
        private Info info;
        private Commands sdts;

        // constructor
        public ManualModel()
        {
            this.info = new Info();
            this.sdts = new Commands();
        }

        public double Rudder
        {
            set { this.rudder = value; }
        }

        public double Throttle
        {
            set { this.throttle = value; }
        }

        public double Aileron
        {
            set { this.aileron = value; }
        }

        public double Elevator
        {
            set { this.elevator = value; }
        }

        // send the given command to the simulator
        public void sendCommand(string command)
        {
            if(Commands.Instance.Connected)
            {
                new Thread(delegate ()
                {
                    Commands.Instance.SendCommands(command);
                }).Start();
            }
        }
    }
}
