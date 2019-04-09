using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    interface IFlightComponentModel
    {
        double Rudder { get; set; }          // The Aileron
        double Throttle { get; set; }           // The Throttle
    }
}
