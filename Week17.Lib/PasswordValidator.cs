using System.Text.RegularExpressions;

namespace Week17.Lib
{
    public class PasswordValidator
    {
        public static (bool valid, string? error) IsValidPassword(string password,
            int min = 6,
            int max = 20,
            bool requiresSpecialCharacters = true,
            bool requiresLowercaseUpperCase = true,
            bool requiresNumber = true)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "Password must not empty");
            }

            if (password.Length < min)
            {
                return (false, $"Password must have minimum {min} character");
            }

            if (password.Length > max)
            {
                return (false, $"Password must have maximum {max} character");
            }

            if (requiresSpecialCharacters)
            {
                if (!Regex.IsMatch(password, @".*[^a-zA-Z0-9].*"))
                    return (false, "Password must have special characters");
            }

            if (requiresLowercaseUpperCase)
            {
                if (!Regex.IsMatch(password, "[a-z]") || !Regex.IsMatch(password, "[A-Z]"))
                    return (false, "Password must have lowercase and uppercase");
            }

            if (requiresNumber)
            {
                if (!Regex.IsMatch(password, ".*\\d.*"))
                    return (false, "Password must have numbers");
            }

            return (true, null);
        }
    }
}
