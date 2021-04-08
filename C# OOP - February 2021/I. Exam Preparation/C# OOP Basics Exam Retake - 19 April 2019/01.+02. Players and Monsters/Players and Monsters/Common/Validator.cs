using System;
namespace Players_and_Monsters.Common
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }
        public static void ThrowIfIntegerIsBelowZero(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
        
        public static void ThrowIfObjectIsNull(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
