using RoverProject.Entities;
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
            IMovingRover movingRover = new MovingRover(mars, rover);
            IEvents events = new Events(mars, rover);

            movingRover.SettingMarsSize();
            events.GeneratingDiscoveries();           
            movingRover.SettingRoverPos();
            movingRover.UserInputRoverActions();
            events.CheckingDiscoveries();
            Console.WriteLine(movingRover);
        }
    }
}
