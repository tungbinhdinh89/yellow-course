using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyTimers
{
    public class AppService
    {
        public static void GetFirstIntro()
        {
            Console.WriteLine("Countdown Timer Calculator by Rob Miles");
            Console.WriteLine("Version 1.0");
        }

        public static int GetHourNumber(string input)
        {
            Console.Write(input);
            
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out var value) && (value > 0 && value <24))
                {
                    return value;
                }
                Console.WriteLine("Invalid value");
            }
        }

        public static int GetMinuteSecondNumber(string input)
        {
            Console.Write(input);

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var value) && (value > 0 && value < 60))
                {
                    return value;
                }
                Console.WriteLine("Invalid value");
            }
        }

        public static void ConvertToSecond(int hour, int minute, int second) 
        {
            Console.WriteLine($"The total number of seconds is : {hour * 60 * 60 + minute * 60 + second}") ;
        
        }
    }
}
