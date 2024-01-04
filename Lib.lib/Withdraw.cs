namespace Exercise.Lib
{
    public struct WithdrawResult
    {
        public string? Error;
        public decimal Balance;
    }

    public struct Account
    {
        public string AccountNumber;
        public decimal Amount;
    }

    public static class Withdraw
    {
        public class ATM
        {
            private List<Account> accounts = new()
            {
                new(){AccountNumber = "ABC1", Amount = 100},
                new(){AccountNumber = "ABC2", Amount = 200},
                new(){AccountNumber = "ABC3", Amount = 300}
            };

            public WithdrawResult WithdrawMoney(string accountNumber, decimal amount)
            {
                var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

                if (account.AccountNumber == null)
                {
                    return new WithdrawResult { Error = "Account does not exist", Balance = 0 };
                }

                else
                {

                    if (account.Amount < amount)
                    {
                        return new WithdrawResult { Error = "Insufficient balance to withdraw money", Balance = 0 };
                    }

                    return new WithdrawResult { Error = null, Balance = account.Amount - amount };
                }
            }
      
            public string GetAccountNumber(string accountNumber)
            {
                Console.Write(accountNumber);

                if (string.IsNullOrEmpty(accountNumber))
                {
                    throw new Exception();
                }
                return Console.ReadLine()!;
            }

            public decimal GetAmount(string amount)
            {
              while (true)
                {
                    Console.Write(amount);
                    if (decimal.TryParse(Console.ReadLine(), out var money))
                        return money;
                }
            }
        }
    }
}
