using System;

namespace _06._Valid_Person.Exceptions
{
    public class InvalidPersonNameException : Exception
    {
        private const string InvalidPersonNameExceptionMessage = "Name must contain only letters";
        public InvalidPersonNameException()
            : base(InvalidPersonNameExceptionMessage)
        {

        }

        public InvalidPersonNameException(string message)
            : base(message)
        {

        }
    }
}
