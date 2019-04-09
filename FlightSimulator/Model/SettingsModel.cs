using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class SettingsModel : ISettingsModel
    {

        //change the exceptions!
        public string FlightServerIP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int FlightInfoPort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int FlightCommandPort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ReloadSettings()
        {
            throw new NotImplementedException();
        }

        public void SaveSettings()
        {
            throw new NotImplementedException();
        }
    }
}
