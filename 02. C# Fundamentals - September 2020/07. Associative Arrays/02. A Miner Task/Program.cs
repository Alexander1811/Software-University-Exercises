using System;
using System.Collections.Generic;

namespace P02_AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> repository = new Dictionary<string, int>();

            string resource;
            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!repository.ContainsKey(resource))
                {
                    repository[resource] = 0;
                }

                repository[resource] += quantity;
            }

            foreach (var keyValuePair in repository)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
