using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverProject.Repository
{
    internal interface IMovingRover
    {
        public void SettingMarsSize();
        public void SettingRoverPos();
        public void UserInputRoverActions();

        public string ToString();
    }
}
