namespace Week17_ClassLibraries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var firstNumber = GetNumber($"Enter the x coordinate", 9, 0);
            //Console.WriteLine(firstNumber);
            //Console.ReadKey();
            // Enter your password: xxxx
            // Password must be at least 6 characters
            // Password must have maximum 20 characters
            // Password must have number or special characters
            // Password must have lowercase and uppercase characters
        }

        static int GetNumber(string str, int min, int max) // signature or prototype
        {
            if (max < min)
            {
                throw new Exception("Invalid range");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException("String is empty");
            }

            while (true)
            {
                Console.Write(str + $" ({min} to {max}) : ");
                if (int.TryParse(Console.ReadLine(), out var number))
                {
                    if (number < min)
                    {
                        Console.WriteLine("Number is too small");
                    }
                    else if (number > max)
                    {
                        Console.WriteLine("Number is too big");
                    }
                    else
                    {
                        return number;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number");
                }
            }
        }
    }
}
