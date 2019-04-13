﻿using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Windows
{
    public class SettingsWindowViewModel : BaseNotify, IViewModel
    {
        private Window window;
        private ISettingsModel model;

        #region OkCommand
        private ICommand _okCommand;
        public ICommand OkCommand => _okCommand ?? (_okCommand = new CommandHandler(() => OkClicked()));
        private void OkClicked()
        {
            model.SaveSettings();
            CloseWindow();

        }

        #endregion
        public SettingsWindowViewModel(ISettingsModel model, Window win)
        {
            this.model = model;
            this.window = win;

        }

        public SettingsWindowViewModel(Window win)
        {
            model = new ApplicationSettingsModel();
            this.window = win;
        }

        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }

        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }
        
        public int FlightInfoPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }



        public void SaveSettings()
        {
            model.SaveSettings();
        }

        public void ReloadSettings()
        {
            model.ReloadSettings();
        }



        #region Commands
        #region ClickCommand
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            model.SaveSettings();
        }
        #endregion

        #region CancelCommand
        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));
            }
        }
        private void OnCancel()
        {
            model.ReloadSettings();
            CloseWindow();
        }
        #endregion
        #endregion
        

        private void CloseWindow()
        {
            if (this.window!=null) { this.window.Close(); }
        }
    }
}
    

