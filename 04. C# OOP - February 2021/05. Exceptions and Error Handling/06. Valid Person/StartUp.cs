namespace P06_ValidPerson
{
    using System;

    using P06_ValidPerson.Exceptions;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person("Peter", null, 18);
            }
            catch (Exception ex)
                when (ex is ArgumentNullException 
                   || ex is ArgumentOutOfRangeException 
                   || ex is InvalidPersonNameException)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
        }
    }
}
