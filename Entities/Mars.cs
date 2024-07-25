using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverProject.Entities
{
    internal class Mars
    {
        private int MarsSizeX { get; set; }
        private int MarsSizeY { get; set; }


        public int GetMarsSizeX()
        {
            return MarsSizeX;
        }

        public void SetMarsSizeX(int posX)
        {
            MarsSizeX = posX;
        }

        public int GetMarsSizeY()
        {
            return MarsSizeY;
        }

        public void SetMarsSizeY(int posY)
        {
            MarsSizeY = posY;
        }



    }
       
}
