using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Pizza_Calories
{
    public class Validator
    {
        public static void ThrowIfValueIsNotInRange(int minValue, int maxValue, int value, string message)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfValueIsNotAllowed(HashSet<string> allowedValues, string value, string message)
        {
            if (!allowedValues.Contains(value))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
