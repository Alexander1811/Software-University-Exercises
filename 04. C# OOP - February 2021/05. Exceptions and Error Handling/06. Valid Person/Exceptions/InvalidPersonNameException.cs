namespace P06_ValidPerson.Exceptions
{
    using System;

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
