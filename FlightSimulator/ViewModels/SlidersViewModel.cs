using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class SlidersViewModel : IFlightComponentViewModel
    {
        private IFlightComponentModel model;

        public SlidersViewModel()
        {
            this.model = new SlidersModel();
        }

        //properties of the model
        public double Rudder
        {
            get
            {
                return model.Rudder;
            }
            set
            {
                model.Rudder = value;
            }
        }
        public double Throttle
        {
            get
            {
                return model.Throttle;
            }
            set
            {
                model.Throttle = value;
            }
        }
    }
}
