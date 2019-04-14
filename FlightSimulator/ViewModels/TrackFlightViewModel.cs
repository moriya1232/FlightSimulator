﻿using FlightSimulator.Model;
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
    class TrackFlightViewModel : BaseNotify,IViewModel
    {
        private TrackFlightModel model;

        public double Lon { get; set; }

        public double Lat { get; set; }

        public TrackFlightViewModel()
        {
            model = new TrackFlightModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Lat") Lat = model.Lat;
                else if (e.PropertyName == "Lon") Lon = model.Lon;
                NotifyPropertyChanged(e.PropertyName);
            };

        }

        private ICommand settingsCommand;


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
