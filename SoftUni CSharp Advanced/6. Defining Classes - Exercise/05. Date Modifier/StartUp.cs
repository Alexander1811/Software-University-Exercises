using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDateArgs = Console.ReadLine();
            string secondDateArgs = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            Console.WriteLine(dateModifier.CalculateDifference(firstDateArgs, secondDateArgs));
        }
    }
}
