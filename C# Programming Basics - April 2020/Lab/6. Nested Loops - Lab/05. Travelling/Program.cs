using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double saving = double.Parse(Console.ReadLine());
                double savedMoney = saving; 
                
                if (destination != "End")
                {                    
                    while (savedMoney < budget)
                    {
                        saving = double.Parse(Console.ReadLine());
                        savedMoney += saving;
                    }

                    Console.WriteLine($"Going to {destination}!");
                    destination = Console.ReadLine();
                }
            }
            // Alternative/My solution
            //double savedMoney = 0;
            //while (true)
            //{
            //    string destination = Console.ReadLine();
            //    if (destination != "End")
            //    {
            //        double neededMoney = double.Parse(Console.ReadLine());
            //        while (savedMoney != neededMoney)
            //        {
            //            double saving = double.Parse(Console.ReadLine());
            //            savedMoney += saving;
            //            if (savedMoney >= neededMoney)
            //            {
            //                savedMoney = 0;
            //                break;
            //            }
            //        }
            //        Console.WriteLine($"Going to {destination}!");
            //    }
            //    else
            //    {
            //       break;
            //    }
            //}
        }
    }
}
