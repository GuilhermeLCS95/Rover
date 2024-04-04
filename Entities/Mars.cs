
using System.Reflection.Metadata.Ecma335;

namespace Rovers
{
    internal class Mars
    {
        public int MaxValueX { get; set; }
        public int MaxValueY { get; set; }
        public Mars mars { get; set; }

        public Mars()
        {
        }
        

        public void InsertingMarsValues() 
        {
            do
            {
                Console.Write("Please, insert the max value of X, space and, after that, put Y's value. (ex:10 10): ");
                string[] getMarsBounds = Console.ReadLine().Split(' ');
                int valueX = int.Parse(getMarsBounds[0]);
                int valueY = int.Parse(getMarsBounds[1]);
                MaxValueX = valueX;
                MaxValueY = valueY;
                
            } while (MarsGreaterThanZero());
        }


        private bool MarsGreaterThanZero()
        {
            if (MaxValueX <= 0 || MaxValueY <= 0) {
                Console.WriteLine("Mars' size cannot be a negative value. Please, try again.");
                return true;
            }
            return false;
        }

        // IGNORA ABAIXO, JOÃO

        private bool MarsNullValue (int maxValueX, int maxValueY)
        {
            if (maxValueX == null || maxValueY == null)
            {
                Console.WriteLine("You must insert a valid value. It cannot be null.");
                return true;
            }
            return false;
        }

       
    }
    
}
