using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < amount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                leftSum = leftSum + num;
            }
            for (int i = 0; i < amount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                rightSum = rightSum + num;
            }
            int total = Math.Abs(leftSum - rightSum);
            if (total == 0)
            {
                Console.WriteLine("Yes, sum = {0}", leftSum);
            }
            else if (total != 0)
            {
                Console.WriteLine("No, diff = {0}", Math.Abs(leftSum - rightSum));
            }
        }
    }
}
