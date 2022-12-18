
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
        public void BelowZeroMars()
        {           
            if (MaxValueY < 0 || MaxValueX < 0)
            {
                Console.WriteLine("Mars' size cannot be less than zero. ");
                Environment.Exit(0);
            }            
        }     
    }
}
