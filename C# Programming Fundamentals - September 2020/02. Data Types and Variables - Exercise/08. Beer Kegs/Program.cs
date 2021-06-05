using System;
using System.Runtime.InteropServices;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            float previousVolume = 0;
            float currentVolume = 0;
            string biggestKeg = "";

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                currentVolume = (float) (Math.PI * radius * radius * height);
                if (currentVolume > previousVolume)
                {
                    previousVolume = currentVolume;
                    biggestKeg = model;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
