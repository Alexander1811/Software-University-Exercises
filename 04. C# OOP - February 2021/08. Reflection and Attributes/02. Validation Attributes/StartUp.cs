namespace P02_ValidationAttributes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Person person = new Person("Alex", -2);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
