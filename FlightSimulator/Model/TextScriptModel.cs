using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class TextScriptModel
    {
        public void operation(string data)
        {
             SendDataToSimulator.Instance.SendCommands(data);
        }
    }
}
