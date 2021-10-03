using System;
using _06._Valid_Person.Exceptions;

namespace _06._Valid_Person
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person("Peter", null, 18);
            }
            catch (Exception ex)
                when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException || ex is InvalidPersonNameException)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
        }
    }
}
