using System;

namespace _02._Animal_Type
{
    class Program
    {
        static void Main(string[] args)
        {
            string animal = Convert.ToString(Console.ReadLine());

            switch (animal)
            {
                case "dog":
                    Console.WriteLine("mammal");
                    break;

                case "crocodile":
                    Console.WriteLine("reptile");
                    break;
                case "tortoise":
                    Console.WriteLine("reptile");
                    break;
                case "snake":
                    Console.WriteLine("reptile");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;
            }

        }
    }
}
