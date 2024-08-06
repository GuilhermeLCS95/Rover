using RoverProject.Entities;
using RoverProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverProject.Services
{
    internal class Events : IEvents
    {
        private Discoveries discoveries = new Discoveries();
        private Mars mars;
        private Rover rover;
        Random random = new Random();


        public Events(Mars mars, Rover rover)
        {
            this.mars = mars;
            this.rover = rover;
        }

        public void GeneratingDiscoveries()
        {
            int marsSizeX = mars.GetMarsSizeX();
            int marsSizeY = mars.GetMarsSizeY();

            int randomPosX = random.Next(0, marsSizeX);
            discoveries.SetDiscoveryPosX(randomPosX);
            int randomPosY = random.Next(0, marsSizeY);
            discoveries.SetDiscoveryPosY(randomPosY);

            Console.WriteLine("Alien: " + randomPosX + " " + randomPosY);
        }

        public void CheckingDiscoveries()
        {
            if (rover.GetRoverPosX() == discoveries.GetDiscoveryPosX() && rover.GetRoverPosY() == discoveries.GetDiscoveryPosY())
            {

                Console.WriteLine("You found something. Is that an alien?");
            }
        }
       

    }
}
