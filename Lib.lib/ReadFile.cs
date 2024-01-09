namespace Exercise.Lib
{
    public class ReadFile
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\tungb\source\repos\yellow-course\Lib.lib\sample_data.csv";
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines.Skip(1))
            {
                var arr = line.Split(',');
                var dob = DateTime.Parse(arr.Last());

                int CalculateAge(DateTime dob)
                {
                    var today = DateTime.Today;
                    int age = today.Year - dob.Year;
                    if (dob.Date > today.AddYears(-age)) age--;
                    return age;
                }

                int age = CalculateAge(dob);

                if (age > 18)
                {
                    Console.WriteLine($"{arr[1]} {arr[2]} is {age} years old");
                }
            }
        }
    }
}