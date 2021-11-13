using System;
using System.Collections.Generic;
using System.Linq;
using P06_FoodShortage.Contracts;
using P06_FoodShortage.Models;

namespace P06_FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command.Length == 4) 
                {
                    string name = command[0];
                    int age = int.Parse(command[1]);
                    string id = command[2];
                    string birthdate = command[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    buyers.Add(name, citizen);
                }
                else if (command.Length == 3) 
                {
                    string name = command[0];
                    int age = int.Parse(command[1]);
                    string group = command[2];

                    Rebel rebel = new Rebel(name, age, group);

                    buyers.Add(name, rebel);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string name = input;

                if (buyers.ContainsKey(name))
                {
                    buyers[name].BuyFood();
                }
            }

            Console.WriteLine(buyers.Values.Sum(buyer => buyer.Food));
        }
    }
}
