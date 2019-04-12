using FlightSimulator.Model;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    class TextScriptViewModel : INotifyPropertyChanged
    {
        private TextScriptModel model;
        private string data;
        private ICommand okCommand;
        // draw is used for drawing the background with pink or white
        private Brush draw = Brushes.White;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Data
        {
            get { return this.data; }
            set {
                this.data = value;
                if (!string.IsNullOrEmpty(Data)) Draw = Brushes.LightPink;
                else if (string.IsNullOrEmpty(Data)) Draw = Brushes.White;
            }
        }

        // Property for the current color of the background
        public Brush Draw
        {
            get { return this.draw; }
            set { draw = value;
                NotifyPropertyChanged("Draw");
            }
        }

        public TextScriptViewModel()
        {
            TextScriptModel model = new TextScriptModel();
            this.model = model;
        }

        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() =>
                {
                    string toBeSent = Data;
                    Data = ""; // remove text
                    Draw = Brushes.White; // make the background white again
                    model.operation(toBeSent);
                }));
            }
        }

        public void NotifyPropertyChanged(string name) {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}