using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Exercise.Lib
{



    public struct RegisterResult
    {
        public bool IsValid { get; set; }
        public string? Error { get; set; }
    }

    public struct LoginResult
    {
        public bool IsValid { get; set; }
        public string? Error { get; set; }
    }

    public static class LoginRegisterValidate
    {
        public class Account
        {
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
        }

        public class User
        {
            private List<Account> accounts = new()
        {
            new(){Email = "abc@abc.com", Password = "1111"},
            new(){Email = "abc1@abc.com", Password = "1111"},
            new(){Email = "abc2@abc.com", Password = "1111"}
        };

            private static string HashPassword(string password)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }

            public RegisterResult RegisterAccount(string email, string password)
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException();
                }

                var account = accounts.SingleOrDefault(x => x.Email == email);
                if (account == null)
                {
                    var hashPassword = HashPassword(password);
                    Account newAccount = new() { Email = email, Password = hashPassword };
                    accounts.Add(newAccount);
                    return new RegisterResult { IsValid = true, Error = null };
                }
                return new RegisterResult { IsValid = false, Error = "Email is exist!" };
            }

            public LoginResult LoginAccount(string email, string password)
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException();
                }

                var account = accounts.SingleOrDefault(y => y.Email == email);
                if (account == null)
                {
                    return new LoginResult { IsValid = false, Error = "Email is not exist" };
                }

                var hashPassword = HashPassword(password);
                if (account.Password != hashPassword)
                {
                    return new LoginResult { IsValid = false, Error = "Password is not match" };
                }

                return new LoginResult { IsValid = true, Error = null };
            }
        }
    }
}

