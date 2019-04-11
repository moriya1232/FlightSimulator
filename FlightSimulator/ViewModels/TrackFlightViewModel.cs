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
            if (model.IsConnected()) // if there is a connection, establish new connections to info and commands
            {
                model.StopRead();
                SendDataToSimulator.Instance.Reset();
                System.Threading.Thread.Sleep(1000); // let info server finish last read
            }
            new Thread(delegate ()
            {
                SendDataToSimulator.Instance.Connect(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort); // conect to simulator
            }).Start();
            model.Open(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort); // open info server


        }



    }
}
