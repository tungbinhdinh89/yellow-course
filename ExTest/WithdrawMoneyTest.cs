using Exercise.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise.Lib.Withdraw;

namespace Exercise.Test
{
    public class WithdrawMoneyTest
    {
        [Theory]
        [InlineData("ABC1", 50, null, 50)]
        [InlineData("ABC2", 300, "Insufficient balance to withdraw money", 0)]
        [InlineData("", 50, "Account does not exist", 0)]
        [InlineData("notValidAccountNumber", 50, "Account does not exist", 0)]
        [InlineData(null, 50, "Account does not exist", 0)]

        public void WithdrawMoney_WithDrawMoneyCorrectly(
            string accountNumber, decimal amount, string expectedError, decimal expectedBalance)
        {
            // Arrange & Act
            var atm = new Withdraw.ATM();
            var result = atm.WithdrawMoney(accountNumber, amount);
            //var withdrawResult = new Withdraw.WithdrawResult();

            // Assert
            Assert.Equal(expectedError, result.Error);
            Assert.Equal(expectedBalance, result.Balance);

            Console.WriteLine($"Error message: {result.Error}");
        }
    }
}
