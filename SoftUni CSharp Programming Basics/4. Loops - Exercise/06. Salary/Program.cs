using System;

namespace _06._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            double fine = 0;

            for (int i = 1; i <= tabs; i++)
            {
                string tabName = Console.ReadLine();

                if (tabName == "Facebook")
                {
                    fine += 150;
                }
                if (tabName == "Instagram")
                {
                    fine += 100;
                }
                if (tabName == "Reddit")
                {
                    fine += 50;
                }
            }

            if (salary <= fine)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary - fine);
            }
        }
    }
}
