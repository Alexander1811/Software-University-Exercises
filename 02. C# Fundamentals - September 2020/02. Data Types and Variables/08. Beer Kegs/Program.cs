using System;

namespace P08_BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            float previousVolume = 0;
            float currentVolume;
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
