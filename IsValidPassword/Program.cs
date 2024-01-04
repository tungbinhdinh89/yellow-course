using Exercise.Lib;
using Microsoft.Win32;

namespace IsValidPassword
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter your password: ");
            //var validationResult = PasswordValidator.IsValidPassword(Console.ReadLine()!);

            //if (validationResult.valid)
            //{
            //    Console.WriteLine("Password is valid!");
            //}
            //else
            //{
            //    Console.WriteLine($"Invalid password: {validationResult.error}");
            //}

            //Console.Write("Enter the day off : ");
            //var requestLeaveResult = RequestLeaveValidator.RequestLeave(Console.ReadLine()!);
            //if (requestLeaveResult.IsValid)
            //    Console.WriteLine("valid");

            //else
            //    Console.WriteLine(requestLeaveResult.Error);

            //var atm = new Withdraw.ATM();
            //var accountNumber = atm.GetAccountNumber("Enter your account number: ");
            //var amount = atm.GetAmount("Enter the amount you want to withdraw: ");
            //var result = atm.WithdrawMoney(accountNumber, amount);

            //if (result.Error == null)
            //{
            //    Console.WriteLine($"Withdraw {amount} from {accountNumber}, remaining balance = {result.Balance}");
            //}
            //else
            //{ Console.WriteLine($"{result.Error}"); }

            //Console.Write("Enter your email: ");
            //var emailRegister = Console.ReadLine()!;
            //Console.Write("Enter your pass: ");
            //var passwordRegister = Console.ReadLine()!;

            //var user = new LoginRegisterValidate.User();
            //var userRgister = user.RegisterAccount(emailRegister, passwordRegister);

            //Console.Write("Enter your email: ");
            //var emailRegister = Console.ReadLine()!;
            //Console.Write("Enter your pass: ");
            //var passwordRegister = Console.ReadLine()!;
       

             string[] lines = File.ReadAllLines(@"C:\Users\tungb\Desktop\File\MOCK_DATA.csv");
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

            Console.ReadKey();
        }
    }
}


