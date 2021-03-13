using System;
using System.Linq;

namespace _03._Telephony
{
    public class Validator
    {
        public static void ThrowIfIsInvalidNumber(string number)
        {
            if (number.Any(character => !char.IsDigit(character)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
        }
        public static void ThrowIfIsInvalidURL(string url)
        {
            if (url.Any(character => char.IsDigit(character)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
        }
    }
}
