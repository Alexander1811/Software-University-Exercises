using System;

namespace _03._Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            double years = double.Parse(Console.ReadLine()); 
            char gender = char.Parse(Console.ReadLine());

            if (gender == 'm')
            {
                if (years < 16)
                {
                    Console.WriteLine("Master");
                }
                else if (years >= 16)
                {
                    Console.WriteLine("Mr."); 
                }
            }
            else if (gender == 'f')
            {
                if (years < 16)
                {
                    Console.WriteLine("Miss");
                }
                else if (years >= 16)
                {
                    Console.WriteLine("Ms.");
                }
            }
        }
    }
}
