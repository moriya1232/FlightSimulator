using FlightSimulator.Model;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Drawing;

namespace FlightSimulator.ViewModels
{
    class TrackFlightViewModel : IViewModel
    {
        private TrackFlightModel model;
        

        // Command for the settings window
        private ICommand settingsCommand;

        public TrackFlightViewModel()
        {
            model = new TrackFlightModel();
        }

        private ICommand connectCommand;
        public ICommand ConnectCommand => connectCommand ?? (connectCommand = new CommandHandler(() => ConnectClicked()));
        void ConnectClicked()
        {
            if (model.IsConnected())
            {
                model.StopRead();
                Commands.Instance.Reset();
                System.Threading.Thread.Sleep(1000);
            }
            new Thread(delegate ()
            {
                Commands.Instance.Connect(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort); // conect to simulator
            }).Start();
            model.Open(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort); // open info server


        }



    }
}
