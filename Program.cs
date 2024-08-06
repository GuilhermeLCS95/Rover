using RoverProject.Entities;
using RoverProject.Enums;
using RoverProject.Repository;
using RoverProject.Services;

namespace RoverProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mars mars = new Mars();
            Rover rover = new Rover();
            IInitializingMarsAndRover initializing = new InitializingMarsAndRover(mars, rover);
            IEvents events = new Events(mars, rover);
            IMovingRover movingRover = new MovingRover(mars, rover, events);
            
           
            
            initializing.SettingMarsSize();
            events.GeneratingDiscoveries();
            initializing.SettingRoverPos();
            movingRover.UserInputRoverActions();
            Console.WriteLine(movingRover);
        }
    }
}
