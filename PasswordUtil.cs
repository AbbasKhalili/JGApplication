using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace JG.Application
{
    public static class PasswordUtil
    {
        public static bool ValidatePasswordPolicy(this string pass)
        {
            return Regex.IsMatch(pass, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
        }

        public static bool EqualPasswordRePassword(this string password, string rePassword)
        {
            return password.GetHashCode() == rePassword.GetHashCode();
        }

        public static string CryptPassword(this string pass)
        {
            var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(pass);
            var hash = sha256.ComputeHash(bytes);
            var result = new StringBuilder();
            foreach (var t in hash)
            {
                result.Append(t.ToString("X2"));
            }
            return result.ToString();
        }
    }
}