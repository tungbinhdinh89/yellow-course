using Exercise.Lib;

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

            var atm = new Withdraw.ATM();
            var accountNumber = atm.GetAccountNumber("Enter your account number: ");
            var amount = atm.GetAmount("Enter the amount you want to withdraw: ");
            var result = atm.WithdrawMoney(accountNumber, amount);

            if (result.Error == null)
            {
                Console.WriteLine($"Withdraw {amount} from {accountNumber}, remaining balance = {result.Balance}");
            }
            else
            { Console.WriteLine($"{result.Error}"); }

            Console.ReadKey();
        }
    }
}


