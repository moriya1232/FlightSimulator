using FlightSimulator.Model;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator.ViewModels
{
    class TrackFlightViewModel : IViewModel
    {
        private TrackFlightModel model;

        // Command for the settings window
        private ICommand settingsCommand;

        public TrackFlightViewModel()
        {
            //model = new TrackFlightModel(new Communication);
        }
        
        private ICommand _connectCommand;
        public ICommand ConnectCommand => _connectCommand ?? (_connectCommand = new CommandHandler(() => ConnectClicked()));
        private void ConnectClicked()
        {
            //comminucation here!!!

        }

        
    }
}
