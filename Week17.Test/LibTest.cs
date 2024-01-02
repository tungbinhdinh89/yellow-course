using Week17.Lib;

namespace Week17.Test
{
    public class LibTest
    {
        [Theory]
        [InlineData("Pass@123", 6, 20, true, true, true, true, null)]
        [InlineData("Short", 6, 20, true, true, true, false, "Password must have minimum 6 character")]
        [InlineData("LongPasswordWithNoSpecialCharacters", 6, 20, true, true, true, false, "Password must have maximum 20 character")]
        [InlineData("NoSpecialCharacters", 6, 20, true, true, false, false, "Password must have special characters")]
        [InlineData("nouppercase", 6, 20, false, true, false, false, "Password must have lowercase and uppercase")]
        [InlineData("NoNumbers", 6, 20, false, true, true, false, "Password must have numbers")]
        [InlineData("", 6, 20, true, true, true, false, "Password must not empty")]
        [InlineData(null, 6, 20, true, true, true, false, "Password must not empty")]
        public void IsValidPassword_ValidatesPasswordCorrectly(
            string password,
            int min,
            int max,
            bool requiresSpecialCharacters,
            bool requiresLowercaseUpperCase,
            bool requiresNumber,
            bool expectedValid,
            string error)
        {
            // Arrange & Act
            var result = PasswordValidator.IsValidPassword(password, min, max, requiresSpecialCharacters, requiresLowercaseUpperCase, requiresNumber);

            // Assert
            Assert.Equal(expectedValid, result.valid);

            if (!expectedValid)
            {
                Assert.NotNull(result.error);
                Assert.Equal(result.error, error);

                Console.WriteLine($"Error message: {result.error}");
            }
        }
    }
}