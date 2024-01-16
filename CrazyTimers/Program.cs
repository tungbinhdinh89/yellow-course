namespace CrazyTimers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AppService.GetFirstIntro("Countdown Timer Calculator");

            //var hour = AppService.GetNumber("Enter the number of hours: ");
            //while (!(hour > 0 && hour < 24))
            //{
            //    Console.WriteLine("The hours cannot be greater than 23 or less than 0.");
            //    hour = AppService.GetNumber("Enter the number of hours: ");
            //}

            //var minutes = AppService.GetNumber("Enter the number of minutes: ");
            //while (!(minutes > 0 && minutes < 60))
            //{
            //    Console.WriteLine("The minutes cannot be greater than 59 or less than 0.");
            //    minutes = AppService.GetNumber("Enter the number of minutes: ");
            //}

            //var seconds = AppService.GetNumber("Enter the number of seconds: ");
            //while (!(seconds > 0 && seconds < 60
            //{
            //    Console.WriteLine("The seconds cannot be greater than 59 or less than 0.");
            //    seconds = AppService.GetNumber("Enter the number of seconds: ");
            //}

            //AppService.ConvertToSecond(hour, minutes, seconds);

            //Reverse Countdown

            //AppService.GetFirstIntro("Reverse Countdown Timer Calculator");

            //var totalSeconds = AppService.GetNumber("Enter the number of total seconds: ");
            //while (!(totalSeconds > 0))
            //{
            //    Console.WriteLine("The total seconds cannot be less than 0.");
            //    totalSeconds = AppService.GetNumber("Enter the number of seconds: ");
            //}

            //AppService.ConvertSecondToHour(totalSeconds);


            // Seconds to Event

            AppService.GetFirstIntro("Seconds to Calculator");

            var hour = AppService.GetNumber("Enter the number of hours: ");
  
            var days = AppService.GetNumber("Enter the number of days: ");
       
            var months = AppService.GetNumber("Enter the number of months: ");
         
            var years = AppService.GetNumber("Enter the number of years: ");
     
            var totalSeconds = AppService.CalculateTotalSeconds(hour,days,months,years);

            Console.WriteLine($"The total number of seconds is: {totalSeconds}");

            Console.ReadKey();
        }
    }
}
