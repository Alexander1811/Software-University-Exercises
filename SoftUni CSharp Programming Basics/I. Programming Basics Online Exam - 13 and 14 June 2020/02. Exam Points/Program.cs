using System;

namespace _02._Exam_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            int problem = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());
            string course = Console.ReadLine();
            double result = 0;

            switch (course)
            {
                // Course        "1" "2" "3" "4"
                //Basics          8   9   9   10
                //Fundamentals    11  11  12  13
                //Advanced        14  14  15  16
                case "Basics":
                    switch (problem)
                    {
                        case 1:
                            result = points * 8 * 0.8;
                            break;
                        case 2:
                            result = points * 9;
                            break;
                        case 3:
                            result = points * 9;
                            break;
                        case 4:
                            result = points * 10;
                            break;
                    }
                    break;
                case "Fundamentals":
                    switch (problem)
                    {
                        case 1:
                            result = points * 11;
                            break;
                        case 2:
                            result = points * 11;
                            break;
                        case 3:
                            result = points * 12;
                            break;
                        case 4:
                            result = points * 13;
                            break;
                    }
                    break;
                case "Advanced":
                    switch (problem)
                    {
                        case 1:
                            result = points * 14;
                            break;
                        case 2:
                            result = points * 14;
                            break;
                        case 3:
                            result = points * 15;
                            break;
                        case 4:
                            result = points * 16;
                            break;
                    }
                    break;
            }

            if (course == "Advanced")
            {
                result *= 1.2;
            }

            Console.WriteLine($"Total points: {result/100:f2}");
        }
    }
}
