using System;

namespace _01._Logger
{
    public class Validator
    {
        public static void ThrowInvalidLayoutTypeException(string type)
        { 
            throw new ArgumentException($"{type} is invalid Layout type.");
        }
        public static void ThrowInvalidAppenderTypeException(string type)
        {
            throw new ArgumentException($"{type} is invalid Appender type.");
        }
    }
}
