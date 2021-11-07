using System;
using System.Text;

namespace TestAutomationPractice.Common
{
    public static class StringUtil
    {
        public static string GetSaltString(int length = 8)
        {
            const string SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var salt = new StringBuilder();
            var rnd = new Random();
            while (salt.Length < length)
            { 
                int index = (int)(rnd.NextDouble() * SALTCHARS.Length);
                salt.Append(SALTCHARS.Substring(index, 1));
            }
            return salt.ToString();
        }
    }
}