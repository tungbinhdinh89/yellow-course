//using Exercise.Lib;

using Lib.lib;

namespace ExTest
{
    public class IsValidPasswordTest
    {
        [Theory]
        [InlineData("Pass@123", 6, 20, true, true, true, true, null)]
        [InlineData("Short", 6, 20, true, true, true, false, "Password must have minimum 6 character")]
        [InlineData("LongPasswordWithNoSpecialCharacters", 6, 20, true, true, true, false, "Password must have maximum 20 character")]
        [InlineData("NoSpecialCharacter1",6, 20, false, true, true, false, "Password must have special character")]
        [InlineData("noupperlowercase", 6, 20, false, true, false, false, "Password must have lowercase and uppercase character")]
        [InlineData("No@Numbers", 6, 20, true, true, false, false, "Password must have a number character")]
        [InlineData("", 6, 20, true, true, true, false, "Password empty")]
        [InlineData(null, 6, 20, true, true, true, false, "Password empty")]

        public void IsValidPassword_ValidatePasswordCorrectly(
            string password,
            int min, 
            int max,
            bool requiredSpecialCharacter,
            bool requiredLowerCaseOrUpperCaseCharacter,
            bool requiredNumber,
            bool expectedValid,
            string error)
        {
            // Arrange & Act
            var result = PasswordValidator.IsValidPassword(password, min, max, requiredSpecialCharacter, requiredLowerCaseOrUpperCaseCharacter, requiredNumber);

            // Assert
            Assert.Equal(expectedValid, result.valid);

            if(!expectedValid)
            {
                Assert.NotNull(result.error);
                Assert.Equal(result.error, error);  

                Console.WriteLine($"Error message: {result.error}");
            }
        }
    }
}