using RoverProject.Entities;
using RoverProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverProject.Services
{
    internal class InitializingMarsAndRover : IInitializingMarsAndRover
    {
        Mars mars;
        Rover rover;

        public InitializingMarsAndRover(Mars mars, Rover rover)
        {
            this.mars = mars;
            this.rover = rover;

        }

        public void SettingMarsSize()
        {
            do
            {
                Console.Write("Mars X and Y: ");
                string[] marsSize = Console.ReadLine().Split(' ');
                mars.SetMarsSizeX(int.Parse(marsSize[0]));
                mars.SetMarsSizeY(int.Parse(marsSize[1]));

            } while (InvalidMarsSize());
        }


        private bool InvalidMarsSize()
        {
            if (mars.GetMarsSizeX() <= 1 || mars.GetMarsSizeY() <= 1)
            {
                Console.WriteLine("Mars' size has to be greater than what you've just inserted. Please, try again.");
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }
        }

        // Rover

        string windRoseAux;
        public void SettingRoverPos()
        {
            do
            {
                Console.Write("Rover X, Y and direction it's facing at: ");
                string[] roverPos = Console.ReadLine().Split(' ');
                rover.SetRoverPosX(int.Parse(roverPos[0]));
                rover.SetRoverPosY(int.Parse(roverPos[1]));
                windRoseAux = roverPos[2].ToUpper();


            } while (InvalidRoverPos() || RoverPosGreaterThanMars() || InvalidWindRoseValue());
        }

        private bool InvalidRoverPos()
        {
            if (rover.GetRoverPosX() < 0 || rover.GetRoverPosY() < 0)
            {
                Console.WriteLine("Rover cannot be placed on a negative value place. Please, try again.");
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool RoverPosGreaterThanMars()
        {
            if (rover.GetRoverPosX() > mars.GetMarsSizeX() || rover.GetRoverPosY() > mars.GetMarsSizeY())
            {
                Console.WriteLine("Rover cannot be placed on a place greater than Mars' size. Please, try again.");
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool InvalidWindRoseValue()
        {
            bool success = Enum.IsDefined(typeof(WindRose), windRoseAux);
            if (success)
            {
                rover.SetWindRose((WindRose)Enum.Parse(typeof(WindRose), windRoseAux));
                Console.WriteLine("Aaaaaa: " + rover.GetWindRose());
                return false;
            }
            else
            {
                Console.WriteLine("Please, insert a valid direction value. Valid values are N, S, W and E.");
                Console.WriteLine();
                return true;
            }
        }
    }
}
