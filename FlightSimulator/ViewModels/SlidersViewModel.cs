using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class SlidersViewModel : BaseNotify, IViewModel
    {
        private SlidersModel model;

        public SlidersViewModel()
        {
            this.model = new SlidersModel();
        }

        //properties
        public double Rudder
        {
            get { return this.model.Rudder; }
            set {
                this.model.Rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }
        public double Throttle
        {
            get { return this.model.Throttle; }
            set
            {
                this.model.Throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }


    }
}
