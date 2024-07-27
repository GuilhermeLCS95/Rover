using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverProject.Entities
{
    internal class Discoveries
    {
        private int DiscoveryPosX { get; set; }
        private int DiscoveryPosY { get; set; }

        public int GetDiscoveryPosX()
        {
            return DiscoveryPosX;
        }

        public void SetDiscoveryPosX(int posX)
        {
            DiscoveryPosX = posX;
        }

        public int GetDiscoveryPosY()
        {
            return DiscoveryPosY;
        }

        public void SetDiscoveryPosY(int posY)
        {
            DiscoveryPosY = posY;
        }
    }
}
