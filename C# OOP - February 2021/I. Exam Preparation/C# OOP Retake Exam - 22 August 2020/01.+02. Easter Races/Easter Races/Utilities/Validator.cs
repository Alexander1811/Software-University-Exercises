using System;

namespace EasterRaces.Utilities
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhiteSpaceOrLessThenMinLength(string value, int minLength, string message)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < minLength)
            {
                throw new ArgumentException(message);
            }
        }
        public static void ThrowIfIntegerIsInRange(int value, int minValue, int maxValue, string message)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentException(message);
            }
        }
        public static void ThrowIfObjectIsNull(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
        }
        public static void ThrowIfIntegerIsLessThanMinValue(int value, int minValue, string message)
        {
            if (value < minValue)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
