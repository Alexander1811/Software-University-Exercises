using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Shopping_Spree
{
    public class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message);
            }
        }
        
        public static void ThrowIfMoneyIsNegative(decimal value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
