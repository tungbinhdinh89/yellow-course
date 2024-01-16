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

        public static int GetNumber(string input)
        {
            Console.Write(input);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var value) )
                {
                    return value;
                }
                //Console.WriteLine("Invalid value");
            }
        }

        public static void ConvertToSecond(int hour, int minute, int second) 
        {
            Console.WriteLine($"The total number of seconds is : {hour * 60 * 60 + minute * 60 + second}") ;
        
        }

        public static void ConvertSecondToHour(int totalSeconds)
        {
            const int secondsInMinute = 60;
            const int minutesInHour = 60;
            Console.WriteLine($"This is equal to {totalSeconds / (minutesInHour * secondsInMinute)} hour, {(totalSeconds % (minutesInHour * secondsInMinute)) / secondsInMinute} minutes and {totalSeconds % secondsInMinute} seconds ");
        }

        public static long CalculateTotalSeconds(int hours, int days, int months, int years)
        {
            const int secondsInMinute = 60;
            const int minutesInHour = 60;
            const int hoursInDay = 24;
            const int daysInMonth = 30; 

            long totalSeconds = years * 365 * daysInMonth * hoursInDay * minutesInHour * secondsInMinute
                              + months * daysInMonth * hoursInDay * minutesInHour * secondsInMinute
                              + days * hoursInDay * minutesInHour * secondsInMinute
                              + hours * minutesInHour * secondsInMinute;

            return totalSeconds;
        }
    }
}
