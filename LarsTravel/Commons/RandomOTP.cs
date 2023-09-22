using System;

namespace LarsTravelClient.Commons
{
    public class RandomOTP
    {
        private static readonly Random random = new Random();
        private const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomOtpCodeg(int length = 5)
        {
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }

            return new string(result);
        }
    }
}
