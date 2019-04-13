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

        private ICommand settingsCommand;

        public TrackFlightViewModel()
        {
            model = new TrackFlightModel();
        }

        private ICommand connectCommand;
        public ICommand ConnectCommand { get { return connectCommand ?? (connectCommand = new CommandHandler(() => ConnectClicked())); } }
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
            Console.WriteLine("The port is: " + Convert.ToString(ApplicationSettingsModel.Instance.FlightCommandPort));
                Commands.Instance.Connect(ApplicationSettingsModel.Instance.FlightServerIP, 5402); // conect to simulator
            }).Start();
            model.Open(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort); // open info server


        }



        }
    }
