using System.ComponentModel;
using FlightSimulator.Model;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private TrackFlightModel model;

        public double Lon
        {
            get { return this.model.Lon; }
        }

        public double Lat
        {
            get;
        }
        
        FlightBoardViewModel()
        {
            this.model = new TrackFlightModel();
        }

        private ICommand connectCommand;
        private ICommand ConnectCommand { get { return connectCommand ?? (connectCommand = new CommandHandler(() => OnClickConnect())); } }
        void OnClickConnect()
        {
          
        }
    }
}
