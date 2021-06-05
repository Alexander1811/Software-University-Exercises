using System;

namespace _02._Validation_Attributes.Attributes
{
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
