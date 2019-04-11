using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightSimulator.Model;
using System.Windows.Input;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class TextScriptViewModel
    {
        private TextScriptModel model;
        private string data;
        private ICommand okCommand;
        public string Data
        {
            get { return this.data; }
            set { this.data = value; }
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
                    model.operation(toBeSent);
                }));
            }
        }

    }
}