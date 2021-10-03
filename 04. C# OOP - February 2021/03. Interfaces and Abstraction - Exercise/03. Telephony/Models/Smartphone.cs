﻿namespace _03._Telephony.Models
{
    public class Smartphone : Phone
    {
        public override string Call(string number)
        {
            Validator.ThrowIfIsInvalidNumber(number);

            return $"Calling... {number}";
        }
    }
}
