using System.Text.RegularExpressions;

namespace JG.Application
{
    public static class RegexTools 
    {
        public static bool IsMobileNumber(this string mobile)
        {
            return Regex.IsMatch(mobile, @"\+?[0-9]{10}");
        }

        public static bool IsEmailAddress(this string email)
        {
            return Regex.IsMatch(email, @"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/");
        }
    }
}
