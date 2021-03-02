using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            //not finished
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> namesDataOverN = new Dictionary<string, int>();

            Func<string, int> getNameValue = name =>
            {
                int count = 0;
                foreach (char letter in name)
                {
                    count += letter;
                }
                return count;
            };

            foreach (string name in names)
            {
                int value = getNameValue(name);
                if (value >= n)
                {
                    namesDataOverN[name] = value;
                }
            }
            namesDataOverN = namesDataOverN.OrderByDescending(b => b.Value).ToDictionary(a => a.Key, b => b.Value);
            foreach (KeyValuePair<string, int> keyValuePair in namesDataOverN)
            {
                Console.WriteLine(keyValuePair.Key);
                break;
            }
        }
    }
}
