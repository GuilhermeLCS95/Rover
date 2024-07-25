using RoverProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverProject.Entities
{
    internal class Rover
    {
        private int RoverPosX { get; set; }
        private int RoverPosY { get; set; }
        private WindRose WindRose { get; set; }

        public int GetRoverPosX()
        {
            return RoverPosX;
        }

        public void SetRoverPosX(int posX)
        {
            RoverPosX = posX;
        }

        public int GetRoverPosY()
        {
            return RoverPosY;
        }

        public void SetRoverPosY(int posY)
        {
            RoverPosY = posY;
        }

        public WindRose GetWindRose()
        {
            return WindRose;
        }

        public void SetWindRose(WindRose windRose)
        {
            WindRose = windRose;
        }

    
    }
}
