using Exercise.Lib;

namespace Exercise.Test
{
    public class RequestLeaveValidatorTest
    {
        [Theory]
        [InlineData("04/01/2024", true, true, true, null)]
        [InlineData("02/01/2024", true, false, false, "Date in the past")]
        [InlineData("06/01/2024", false, true, false, "Leave days cannot be Saturday or Sunday")]
        [InlineData("", true, true, false, "Date is not empty")]
        [InlineData(null, true, true, false, "Date is not empty")]
        [InlineData("01/30/2024", true, true, false, "Invalid date format. It should be format like \"dd/MM/yyyy\"")]

        public void RequestLeave_RequestLeaveCorrectly(
        string leavesDay,
            bool requiredDayNotInThePast,
            bool requiredDayNotInTheWeekend,
            bool expectedValid,
            string expectedError
        )
        {
            // Arrange & Act
            var result = RequestLeaveValidator.RequestLeave(leavesDay, requiredDayNotInThePast, requiredDayNotInTheWeekend);

            // Assert
            Assert.Equal(expectedValid, result.IsValid);
            if (!expectedValid)
            {
                Assert.NotNull(result.Error);
                Assert.Equal(expectedError, result.Error);

                Console.WriteLine($"Error message: {result.Error}");
            }
        }

    }
}
