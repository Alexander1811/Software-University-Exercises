using System;

namespace _05._Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int first = 1; first < n; first++)
            {
                for (int second = 1; second < n; second++)
                {
                    for (int thirdInt = 97; thirdInt < l + 97; thirdInt++) 
                    {
                        char third = Convert.ToChar(thirdInt);
                        for (int fourthInt = 97; fourthInt < l + 97; fourthInt++)
                        {
                            char fourth = Convert.ToChar(fourthInt);
                            for (int fifth = 1; fifth <= n; fifth++)
                            {
                                if (fifth > first && fifth > second)
                                {
                                    Console.Write($"{first}{second}{third}{fourth}{fifth} ");
                                }
                            }                            
                        }                        
                    }
                }
            }
        }
    }
}
