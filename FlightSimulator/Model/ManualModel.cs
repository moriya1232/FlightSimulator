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

      /*  public void GetCommand()
        {
            new Thread(delegate ()
            {
                while (!info.Stop)
                {
                    string[] args = info.Read();
                    Aileron = Convert.ToDouble(args[21]);
                    Elevator = Convert.ToDouble(args[22]);
                    Rudder = Convert.ToDouble(args[23]);
                    Throttle = Convert.ToDouble(args[25]);
                }
            }).Start();
        }*/
    }
}
