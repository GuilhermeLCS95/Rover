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

            mars = new Mars();
            rover = new Rover();
            Console.WriteLine("Hi! Today, You will control a rover that is walking on Mars. First of all, You have to set Mars' bounds.\nRemember that the lower value will always be zero, but the max value is up to you.\nWithout further ado, LET'S BEGIN!!!");
            Console.WriteLine();

            mars.InsertingMarsValues();
            rover.RoversQuantity();
            rover.RoverInitialPos();

        }
            
    }
}
