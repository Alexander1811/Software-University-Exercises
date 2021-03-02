using System;

namespace _03._Exam_Categories
{
    class Program
    {
        static void Main(string[] args)
        {
            int complexity = int.Parse(Console.ReadLine());
            int twistedness = int.Parse(Console.ReadLine());
            int pages = int.Parse(Console.ReadLine());

            if (complexity >= 80 && twistedness >= 80 && pages >= 8)
            {
                Console.WriteLine("Legacy");
                return;
            }
            else if (complexity >= 80 && twistedness <= 10)
            {
                Console.WriteLine("Master");
                return;
            }
            else if (complexity <= 10)
            {
                Console.WriteLine("Elementary");
                return;
            }
            else if (complexity <= 30 && pages <= 1)
            {
                Console.WriteLine("Easy");
                return;
            }            
            else if (twistedness >= 50 && pages >= 2)
            {
                Console.WriteLine("Hard");
                return;
            }            
            else
            {
                Console.WriteLine("Regular");
            }
        }
    }
}
