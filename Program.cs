using RoverProject.Entities;
using RoverProject.Repository;

namespace RoverProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMovingRover movingRover = new MovingRover();

            movingRover.SettingMarsSize();
            movingRover.SettingRoverPos();
            movingRover.UserInputRoverActions();

            Console.WriteLine(movingRover);
        }
    }
}
