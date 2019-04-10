using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using FlightSimulator.Model;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private TrackFlightModel model;

        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }

        FlightBoardViewModel()
        {
            //this.model = new TrackFlightModel();
            //model.pro
        }
    }
}
