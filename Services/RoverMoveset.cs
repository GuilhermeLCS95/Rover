using RoverProject.Entities;
using RoverProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverProject.Services
{
    internal class RoverMoveset : IRoverMoveset
    {
        Mars mars;
        Rover rover;

        public RoverMoveset(Mars mars, Rover rover)
        {
            this.mars = mars;
            this.rover = rover;
        }

        private void RoverTurnToLeft(char ch)
        {
            switch (rover.GetWindRose())
            {
                case WindRose.N:
                    rover.SetWindRose(WindRose.W);
                    break;

                case WindRose.W:
                    rover.SetWindRose(WindRose.S);
                    break;

                case WindRose.S:
                    rover.SetWindRose(WindRose.E);
                    break;

                case WindRose.E:
                    rover.SetWindRose(WindRose.N);
                    break;
            }
        }

        private void RoverTurnToRight(char ch)
        {
            switch (rover.GetWindRose())
            {
                case WindRose.N:
                    rover.SetWindRose(WindRose.E);
                    break;

                case WindRose.E:
                    rover.SetWindRose(WindRose.S);
                    break;

                case WindRose.S:
                    rover.SetWindRose(WindRose.W);
                    break;

                case WindRose.W:
                    rover.SetWindRose(WindRose.N);
                    break;
            }
        }

        private void RoverMoving(char ch)
        {
            switch (rover.GetWindRose())
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
                    rover.SetWindRose(WindRose.S);
                }
                else
                {
                    rover.SetRoverPosY(0);
                    rover.SetWindRose(WindRose.N);
                }

            }
            else if (coordenate == "X")
            {
                if (orientation == "E")
                {
                    rover.SetRoverPosX(mars.GetMarsSizeX());
                    rover.SetWindRose(WindRose.W);
                }
                else
                {
                    rover.SetRoverPosX(0);
                    rover.SetWindRose(WindRose.E);
                }
            }
            Console.WriteLine("Rover cannot surpass Mars' limits to " + orientation + ". It's turning to the opposite way.");
        }

        public void RoverActions(char ch)
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
    }
}
