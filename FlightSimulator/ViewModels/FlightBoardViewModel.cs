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
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    class FlightBoardViewModel : BaseNotify,IViewModel
    {
        private FlightBoardModel model;
        private double? lat;
        private double? lon;

        public double? Lon { get { return model.Lon; } }

        public double? Lat { get { return model.Lat; } }

        public FlightBoardViewModel()
        {
            model = new FlightBoardModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
        }

        private ICommand disconnectCommand;
        public ICommand DisconnectCommand { get { return disconnectCommand ?? (disconnectCommand = new CommandHandler(() => DisconnectClicked())); } }
        void DisconnectClicked()
        {
            this.model.sdts.Disconnect();
            this.model.StopRead();
        }

        private ICommand settingsCommand;
        public ICommand SettingsCommand { get { return settingsCommand ?? (settingsCommand = new CommandHandler(() => SettingsClicked())); } }
        void SettingsClicked()
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }


        private ICommand connectCommand;
        public ICommand ConnectCommand { get { return connectCommand ?? (connectCommand = new CommandHandler(() => ConnectClicked())); } }
        void ConnectClicked()
        {
            if (model.IsConnected())
            {
                model.StopRead();
                Commands.Instance.Reset();
                // a second delay
                System.Threading.Thread.Sleep(1000);
            }
            // open the Commands channel, where our app is a client and the simulator is the server
            new Thread(delegate ()
            {
                // the actual connect to the server, which is the simulator
                Commands.Instance.Connect(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort);
            }).Start();
            // open the Info channel, where our app is the server and the simulator is the client
            model.Open(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort);


        }


    }
    }
