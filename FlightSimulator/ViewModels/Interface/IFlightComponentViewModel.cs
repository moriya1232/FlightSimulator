using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    interface IFlightComponentViewModel
    {
       
        double Rudder { get; set; }           // The Rudder
        double Throttle { get; set; }           // The Throttle

    }
}
