using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverProject.Services
{
    internal interface IEvents
    {
        public void GeneratingDiscoveries();
        public void CheckingDiscoveries();
    }
}
