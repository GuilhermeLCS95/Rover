
using System.Reflection.Metadata.Ecma335;

namespace Rovers
{
    internal class Mars
    {
        public int MaxValueX { get; set; }
        public int MaxValueY { get; set; }
        public Rover rover { get; set; }
        public Mars mars { get; set; }

        public Mars(int maxValueX, int maxValueY)
        {
            MaxValueX = maxValueX;
            MaxValueY = maxValueY;
        }

      

        public bool MarsGreaterThanZero(int maxValueX, int maxValueY)
        {
            while (maxValueX <= 0 || maxValueY <= 0)
            {
                Console.Write("The values of X and Y must be greater than zero. Please try again. ");
                string[] getValueXY = Console.ReadLine().Split(' ');
                maxValueX = int.Parse(getValueXY[0]);
                maxValueY = int.Parse(getValueXY[1]);
                mars = new Mars(maxValueX, maxValueY);
            }
            return false;
        }
    }
    
}
