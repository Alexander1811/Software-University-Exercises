using System;

namespace _05._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHours = int.Parse(Console.ReadLine());
            int initialMinutes = int.Parse(Console.ReadLine());

            if (initialHours < 24)
            {
                if (initialMinutes < 60)
                {
                    int time = initialHours * 60 + initialMinutes + 15;

                    int newHours = time / 60;
                    if (newHours == 24)
                    {
                        newHours = 0;
                    }
                    int newMinutes = time % 60;

                    if (newMinutes < 10)
                    {
                        Console.WriteLine($"{newHours}:0{newMinutes}");
                    }
                    else
                    {
                        Console.WriteLine($"{newHours}:{newMinutes}");
                    }
                }
            }
        }
    }
}
