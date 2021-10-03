using System;

namespace _05._Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projectsNum = int.Parse(Console.ReadLine());
            int hours = projectsNum * 3;

            Console.WriteLine($"The architect {name} will need {hours} hours to complete {projectsNum} project/s.");
        }
    }
}
