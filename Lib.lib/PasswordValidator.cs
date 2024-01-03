namespace Lib.lib
{
    public class PasswordValidator
    {
        public static (bool valid, string? error) IsValidPassword(string password,
            int min = 6,
            int max = 20,
            bool RequiredNumber = true,
            bool RequiredLowerCaseOrUpperCase = true,
            bool RequiredSpecialCharacter = true)
        {
            if (string.IsNullOrEmpty(password))
                return (false, "Password empty");

            if (password.Length < min)
                return (false, $"Password must have minimum {min} character");

            if (password.Length > max)
                return (false, $"Password must have maximum {max} character");

            if (RequiredLowerCaseOrUpperCase)
            {
                if (!password.Any(char.IsLower) || !password.Any(char.IsUpper))
                    return (false, "Password must have lowercase and uppercase character");
            }

            if (RequiredSpecialCharacter)
            {
                if (!password.Any(char.IsPunctuation))
                    return (false, "Password must have special character");
            }

            if (RequiredNumber)
            {
                if (!password.Any(char.IsDigit))
                    return (false, "Password must have a number character");
            }

            return (true, null);
        }
    }
}
