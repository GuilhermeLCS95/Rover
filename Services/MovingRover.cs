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
        private Rover rover = new Rover();
        WindRose windRose;

        public MovingRover(Mars mars, Rover rover)
        {
            this.mars = mars;
            this.rover = rover;
        }

        // Mars
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
                windRose = (WindRose)Enum.Parse(typeof(WindRose), windRoseAux);
                return false;
            }
            else
            {
                Console.WriteLine("Please, insert a valid direction value. Valid values are N, S, W and E.");
                Console.WriteLine();
                return true;
            }
        }


        // Rover movements
        private void RoverTurnToLeft(char ch)
        {
            switch (windRose)
            {
                case WindRose.N:
                    windRose = WindRose.W;
                    break;

                case WindRose.W:
                    windRose = WindRose.S;
                    break;

                case WindRose.S:
                    windRose = WindRose.E;
                    break;

                case WindRose.E:
                    windRose = WindRose.N;
                    break;
            }
        }

        private void RoverTurnToRight(char ch)
        {
            switch (windRose)
            {
                case WindRose.N:
                    windRose = WindRose.E;
                    break;

                case WindRose.E:
                    windRose = WindRose.S;
                    break;

                case WindRose.S:
                    windRose = WindRose.W;
                    break;

                case WindRose.W:
                    windRose = WindRose.N;
                    break;
            }
        }

        private void RoverMoving(char ch)
        {
            switch (windRose)
            {
                case WindRose.N:
                    rover.SetRoverPosY(rover.GetRoverPosY() + 1);
                    if (rover.GetRoverPosY() > mars.GetMarsSizeY())
                    {
                        ValidatePosition("Y", "N");
                    }
                    break;

                case WindRose.E:
                    rover.SetRoverPosX(rover.GetRoverPosX() + 1);
                    if (rover.GetRoverPosX() > mars.GetMarsSizeX())
                    {
                        ValidatePosition("X", "E");
                    }
                    break;

                case WindRose.S:
                    rover.SetRoverPosY(rover.GetRoverPosY() - 1);
                    if (rover.GetRoverPosY() < 0)
                    {
                        ValidatePosition("Y", "S");
                    }
                    break;

                case WindRose.W:
                    rover.SetRoverPosX(rover.GetRoverPosX() - 1);
                    if (rover.GetRoverPosX() < 0)
                    {
                        ValidatePosition("X", "W");
                    }
                    break;
            }
        }

        private void ValidatePosition(string coordenate, string orientation)
        {
            if (coordenate == "Y")
            {
                if (orientation == "N")
                {
                    rover.SetRoverPosY(mars.GetMarsSizeY());
                    windRose = WindRose.S;
                }
                else
                {
                    rover.SetRoverPosY(0);
                    windRose = WindRose.N;
                }
                
            }
            else if(coordenate == "X")
            {
                if (orientation == "E")
                {
                    rover.SetRoverPosX(mars.GetMarsSizeX());
                    windRose = WindRose.W;
                }
                else
                {
                    rover.SetRoverPosX(0);
                    windRose = WindRose.E;
                }
            }
            Console.WriteLine("Rover cannot surpass Mars' limits to " + orientation + ". It's turning to the opposite way.");
        }

        private void RoverActions(char ch)
        {
            if (ch == 'R')
            {
                RoverTurnToRight(ch);
            }
            else if (ch == 'L')
            {
                RoverTurnToLeft(ch);
            }
            else if (ch == 'M')
            {
                RoverMoving(ch);
            }
            else
            {
                Console.WriteLine(ch + " is an invalid input value.");
            }
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
                RoverActions(c);
                Console.WriteLine("Rover's position X is " + rover.GetRoverPosX() + " and rover's position Y is " + rover.GetRoverPosY());

            }
        }

        public override string ToString()
        {
            return "Output:\n" + rover.GetRoverPosX() + " " + rover.GetRoverPosY() + " " + windRose + "\n---------------------------------------------------------------------";
        }
    }
}
