using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfAlexandria
{
    public class Validator
    {

        public static int ValidateUserNumber()
        {
            int result = 0;

            while(!int.TryParse(Console.ReadLine(),out result))
            {
                Console.WriteLine("Sorry, that input is not valid. Please try again.");
            }
            return result;
        }

       public static int GetNumberInRange(int min, int max)
        {
            bool numberInRange;
            int value = ValidateUserNumber();
            if (value >= min && value <= max)
            {
                numberInRange = true;
                return value;
            }
            else
            {
                Console.WriteLine("That number is out of range. Please, try again.");
                return -1;
            }
        }
    }
}
