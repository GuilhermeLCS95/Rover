using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Schema;

namespace Rovers
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Mars mars;
        Rover rover;
            // Getting Cartesian plane' size.
            do { 
                Console.Write("Please, insert the value X and Y. Insert a space between them: ");
                string[] getValueXY = Console.ReadLine().Split(' ');
                int XValue = int.Parse(getValueXY[0]);
                int YValue = int.Parse(getValueXY[1]);
                mars = new Mars(XValue, YValue);
            }
            while (mars.MarsGreaterThanZero(mars.MaxValueX, mars.MaxValueY));
            // Putting a Rover in Cartesian plane with its direction
            do {
                Console.Write("We need to put a Rover somewhere.\nPlease, insert a valid place (based on Cartesian plane) and a direction (N,S,W,E): ");
                string[] GettingRoverPos = Console.ReadLine().Split(' ');
                int RoverPositionX = int.Parse(GettingRoverPos[0]);
                int RoverPositionY = int.Parse(GettingRoverPos[1]);
                WindRose windRose = (WindRose)Enum.Parse(typeof(WindRose), GettingRoverPos[2].ToUpper());
                rover = new Rover(RoverPositionX, RoverPositionY, windRose);
            }  while (rover.RoverGreaterThanMars(rover.RoverStepsX, rover.RoverStepsY, mars.MaxValueX, mars.MaxValueY));
        // What's the direction that the Rover is looking at?
        Console.Write("In order to make the Rover turn to its left, press L.\nIn order to make the Rover turn to its right, press R.");
        Console.Write("\nIf you want to make it take a step, press M.\nInput: ");
        string RoverMoving = Console.ReadLine().ToUpper();
        char[] CHRoverMoving = RoverMoving.ToCharArray();
          foreach (char ch in CHRoverMoving)
          {
           rover.RoverActions(ch);
          }
        // output
        Console.WriteLine(rover);
       
        }
    }
}
