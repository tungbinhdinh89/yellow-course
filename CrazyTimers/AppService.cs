using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyTimers
{
    public class AppService
    {
        public static void GetFirstIntro(string msg)
        {
            Console.WriteLine($"{msg} by Rob Miles");
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

            if (hours < 1 || hours > 24 ||days < 1 || days > 30 || months < 1 || months > 12 ||
            (days > 28 && months == 2) || (days > 30 && (months == 4 || months == 6 || months == 9 || months == 11)))
            {
                //throw new ArgumentException("Days or month is invalid.");
                Console.WriteLine("Days or month is invalid.");
                return 0;
            }

            DateTime targetDate = new DateTime(years, months, days, hours, 0, 0);

            if (targetDate <= DateTime.Now)
            {
                //throw new ArgumentException("Days and hours have passed.");
                Console.WriteLine("Days and hours have passed.");
                return 0;
            }

            DateTime startTime = DateTime.Now;
            DateTime endTime = new DateTime(years, months, days, hours, 0, 0);

            TimeSpan timeRemaining = endTime.Subtract(startTime);

            var totalSeconds = (long)timeRemaining.TotalSeconds;
            return totalSeconds;
        }
    }
}
