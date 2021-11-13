using System;

namespace P02_BeehiveRole
{
    class Program
    {
        static void Main(string[] args)
        {
            int intellect = int.Parse(Console.ReadLine());
            int strength = int.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            if (intellect >= 80 && strength >= 80 && gender == "female")
            {
                Console.WriteLine("Queen Bee ");
                return;
            }
            else if (intellect >= 80)
            {
                Console.WriteLine("Repairing Bee");
                return;
            }
            else if (intellect >= 60)
            {
                Console.WriteLine("Cleaning Bee");
                return;
            }
            else if (strength >= 80 && gender == "male")
            {
                Console.WriteLine("Drone Bee");
                return;
            }
            else if (strength >= 60)
            {
                Console.WriteLine("Guard Bee");
                return;
            }
            else 
            {
                Console.WriteLine("Worker Bee");
            }
        }
    }
}
