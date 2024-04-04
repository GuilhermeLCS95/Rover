using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Rovers
{
    internal class Rover
    {
        public int RoverStepsX { get; set; }
        public int RoverStepsY { get; set; }
        public WindRose windRose { get; set; }
        public Rover()
        {

        }


        int roverQuantityAux;
        public void RoversQuantity()
        {
            do
            {
                Console.Write("How many rovers would you like to send to Mars? teste");
                int roverQuantity = int.Parse(Console.ReadLine());
                roverQuantityAux = roverQuantity;
                Console.WriteLine();
            } while (RoverQuantityBelowThanZero());
           
        }

        public bool RoverQuantityBelowThanZero()
        {
            if (roverQuantityAux <= 0)
            {
                Console.WriteLine("Quantity of rover cannot be less than zero.");
                Console.WriteLine();
                return true;
            }
            return false;
        }


        string windRoseAux;
        string toStringAux;
        public void RoverInitialPos()
        {
            for (int i = 0; i < roverQuantityAux; i++)
            {
                do
                {
                    Console.WriteLine("Rover number #" + (i + 1) + " is about to land on Mars. It's time to inform where it'll land.");
                    Console.Write("Please, insert X, Y and in which direction (N,S,W,E) rover will be facing.\n Do not forget to put a space between values. (ex: 5 5 W): ");
                    string[] getRoverInitialPosition = Console.ReadLine().Split(' ');
                    int roverPositionX = int.Parse(getRoverInitialPosition[0]);
                    int roverPositionY = int.Parse(getRoverInitialPosition[1]);
                    // windRose = (WindRose)Enum.Parse(typeof(WindRose), getRoverInitialPosition[2].ToUpper());
                    windRoseAux = getRoverInitialPosition[2].ToUpper();
                    RoverStepsX = roverPositionX;
                    RoverStepsY = roverPositionY;
                    Console.WriteLine();

                } while ((ValidatingWindRose()) || (RoverBelowZeroInitialPos()));

                InsertingRoverCommands();
                toStringAux = this.ToString();
                Console.WriteLine(toStringAux);
                Console.WriteLine();
            }
        }
        private bool ValidatingWindRose()
        {
            bool success = Enum.IsDefined(typeof(WindRose), windRoseAux);
            if (success)
            {
                windRose = (WindRose)Enum.Parse(typeof(WindRose), windRoseAux);
                return false;
            }
            else
            {
                Console.WriteLine("Please, insert a valid direction value. Valid values are N, S, W, E.");
                Console.WriteLine();
                return true;
            }
        }
        private bool RoverBelowZeroInitialPos()
        {
            if (RoverStepsX < 0 || RoverStepsY < 0)
            {
                Console.WriteLine("Rover cannot be placed on a negative value place. Please, try again.");
                Console.WriteLine();
                return true;
            }

            return false;
        }

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
        private void MoveFoward(char ch)
        {                        
            switch (windRose)
            {
                case WindRose.N:
                    RoverStepsY = RoverStepsY + 1;
                break;

                case WindRose.W:
                    RoverStepsX = RoverStepsX - 1;                   
                break;

                case WindRose.S:
                    RoverStepsY = RoverStepsY - 1;
                break;

                case WindRose.E:
                    RoverStepsX = RoverStepsX + 1;                   
                break;                  
            }
        }                    
        private void RoverActions(char ch)
        {
            if (ch == 'R')
            {
                RoverTurnToRight(ch);
            }
            if (ch == 'L')
            {
                RoverTurnToLeft(ch);
            }
            if (ch == 'M')
            {    
                MoveFoward(ch);
            }
            else if (!(ch == 'R' || ch == 'L' || ch == 'M'))
            {
            Console.WriteLine(ch + " is an invalid character.");
            }           
        }

        string roverInsertCommands;
        private void InsertingRoverCommands()
        {
            Console.WriteLine("Now, all you have to do is control the rover.\nYou have three options here: R to make it turn to its right; L to make it turn to its left and M to make it take one step ahead.");
            Console.WriteLine("Please, DO NOT PUT SPACE BETWEEN COMMANDS. For example, to make the rover turn to its right and then take one step ahead, put 'RM'.");
            Console.Write("Insert rover commands: ");
            roverInsertCommands = Console.ReadLine().ToUpper();
            char[] roverCommands = roverInsertCommands.ToCharArray();
            foreach (char c in roverCommands)
            {
                RoverActions(c);
            }
        }


        public override string ToString()
        {
            return "Output:\n"+ RoverStepsX + " " + RoverStepsY + " " + windRose + "\n---------------------------------------------------------------------";
        }
    }
}
