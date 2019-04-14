using System.ComponentModel;
using FlightSimulator.Model;
using System.Windows.Input;
using System;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private TrackFlightModel model;
        private double lat;
        private double lon;

        public double Lon
        {
            get { return this.lon; }
            set { this.lon = value; }
        }

        public double Lat
        {
            get { return this.lat; }
            set { this.lat = value; }
        }
        
        FlightBoardViewModel()
        {
            this.model = new TrackFlightModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Lat") { Lat = model.Lat; }
                else if (e.PropertyName == "Lon") { Lon = model.Lon; }
                NotifyPropertyChanged(e.PropertyName);
            };
        }

    }
}
