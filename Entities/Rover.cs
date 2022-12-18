using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Rovers
{
    internal class Rover : Mars
    {
        public int RoverStepsX { get; set; }
        public int RoverStepsY { get; set; }
        public Mars Mars { get; set; }
        public WindRose windRose { get; set; }
        public Rover(int maxValueX, int maxValueY, int roverStepsX, int roverStepsY, WindRose windRose) : base(maxValueX, maxValueY)
        {
            RoverStepsX = roverStepsX;           
            RoverStepsY = roverStepsY;            
            this.windRose = windRose;
        }                  
        public void MarsLimits()
        {
           if(MaxValueX < RoverStepsX || MaxValueY < RoverStepsY)
           {
                Console.WriteLine("Rover cannot be positioned beyond Mars' limits. ");
                Environment.Exit(0);
           }            
        }
        public void NegativeRoverPos()
        {
            if (0 > RoverStepsX || 0 > RoverStepsY)
            {
                Console.WriteLine("Rover cannot be at a negative number position.");
                Environment.Exit(0);
            }
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
