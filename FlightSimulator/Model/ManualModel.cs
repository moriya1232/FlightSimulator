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
        public void implement(string command)
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
