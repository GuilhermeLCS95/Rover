using RoverProject.Entities;
using RoverProject.Enums;
using RoverProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverProject.Repository
{
    internal class MovingRover : IMovingRover
    {
        // private Mars mars = new Mars();
        private Mars mars;
        private Rover rover;
        IRoverMoveset moveset;
        IEvents events;

        public MovingRover(Mars mars, Rover rover, IEvents events)
        {
            this.mars = mars;
            this.rover = rover;
            this.moveset = new RoverMoveset(mars, rover);
            this.events = events;
        }

        public void UserInputRoverActions()
        {
            Console.Write("Input rover commands: ");
            string commands = Console.ReadLine().ToUpper();
            char[] ch = commands.ToCharArray();
            Console.WriteLine("Rover's path.");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine();
            foreach (char c in ch)
            {

                moveset.RoverActions(c);

                Console.WriteLine("Rover's position X is " + rover.GetRoverPosX() + " and rover's position Y is " + rover.GetRoverPosY());
                events.CheckingDiscoveries();

            }
        }

        public override string ToString()
        {
            return "Output:\n" + rover.GetRoverPosX() + " " + rover.GetRoverPosY() + " " + rover.GetWindRose() + "\n---------------------------------------------------------------------";
        }
    }
}
