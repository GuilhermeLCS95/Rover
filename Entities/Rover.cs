using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Rovers
{
    internal class Rover
    {
        public int RoverStepsX { get; set; }
        public int RoverStepsY { get; set; }
        public Mars mars { get; set; }
        public WindRose windRose { get; set; }
        public Rover rover { get; set; }

        public Rover(int maxValueX, int maxValueY, int roverStepsX, int roverStepsY, WindRose windRose)
        {
            RoverStepsX = roverStepsX;
            RoverStepsY = roverStepsY;
            this.windRose = windRose;
            mars = new Mars(maxValueX, maxValueY); // inicializa a propriedade mars com uma nova instância de Mars
        }

        public Rover(int roverStepsX, int roverStepsY, WindRose windRose)
        {
            RoverStepsX = roverStepsX;
            RoverStepsY = roverStepsY;
            this.windRose = windRose;
        }

        public bool RoverGreaterThanMars(int roverStepsX, int roverStepsY, int maxValueX, int maxValueY)
        {
            while (roverStepsX > maxValueX|| roverStepsY > maxValueY)
            {
                Console.WriteLine("The rover position cannot exceed Mars' maximum size. Please try again.");
                string[] GettingRoverPos = Console.ReadLine().Split(' ');
                roverStepsX = int.Parse(GettingRoverPos[0]);
                roverStepsY = int.Parse(GettingRoverPos[1]);
                WindRose windRose = (WindRose)Enum.Parse(typeof(WindRose), GettingRoverPos[2].ToUpper());
                
                rover = new Rover(roverStepsX, roverStepsY, windRose);
            }
            return false;
        }
    
        public void RoverTurnToLeft(char ch)
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
        public void RoverTurnToRight(char ch)
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
            public void MoveFoward(char ch)
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
        public void RoverActions(char ch)
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
        public override string ToString()
        {
            return "Output:\n"+ RoverStepsX + " " + RoverStepsY + " " + windRose;
        }
    }
}
