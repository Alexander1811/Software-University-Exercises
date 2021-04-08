using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Utilities
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhitespace(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfIntegerIsLessOrEqualToZero(int value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfDecimalIsLessOrEqualToZero(decimal value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
