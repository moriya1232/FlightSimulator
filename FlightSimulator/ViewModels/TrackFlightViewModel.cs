using FlightSimulator.Model;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator.ViewModels
{
    class TrackFlightViewModel : IViewModel
    {
        private TrackFlightModel model;

        public TrackFlightViewModel()
        {
            model = new TrackFlightModel();
        }
    }
}
