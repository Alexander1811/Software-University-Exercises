using System;

namespace P02_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Convert.ToString(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            
            int attendants = rows * columns;
            
            if (type == "Premiere")
            {
                double income = attendants * 12;
                Console.WriteLine($"{income:f2} leva");
            }
            else if (type == "Normal")
            {
                double income = attendants * 7.5;
                Console.WriteLine($"{income:f2} leva");
            }
            else if (type == "Discount")
            {
                double income = attendants * 5;
                Console.WriteLine($"{income:f2} leva");
            }
        }
    }
}
