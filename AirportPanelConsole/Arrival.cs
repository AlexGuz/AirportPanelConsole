using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanelConsole
{
    //create struct for List<T>
    struct Arrival
    {
        public DateTime Time;
        public string FlNumber;
        public string Town;
        public string Company;
        public Terminal Terminal;
        public FlStatus FlStatus;
        public Gate Gate;
    }
}
