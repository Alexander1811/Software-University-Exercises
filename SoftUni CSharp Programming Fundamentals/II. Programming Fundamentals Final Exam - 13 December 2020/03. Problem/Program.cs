using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> usersList = new Dictionary<string, List<string>>();
            List<string> emailsList = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] command = input.Split("->").ToArray();
                string action = command[0];
                string username = command[1];

                if (action == "Add")
                {
                    if (usersList.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    else if (!usersList.ContainsKey(username))
                    {
                        emailsList = new List<string>();
                        usersList.Add(username, emailsList);
                    }
                }
                else if (action == "Send")
                {
                    string email = command[2];

                    usersList[username].Add(email);

                }
                else if (action == "Delete")
                {
                    if (usersList.ContainsKey(username))
                    {
                        usersList.Remove(username);
                    }
                    else if (!usersList.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} not found!");
                    }                    
                }
            }

            usersList = usersList.OrderByDescending(b => b.Value.Count).ThenBy(a => a.Key).ToDictionary(a => a.Key, b => b.Value);
            Console.WriteLine($"Users count: {usersList.Count}");
            foreach (KeyValuePair<string, List<string>> keyValuePair in usersList)
            {
                string username = keyValuePair.Key;
                List<string> emails = keyValuePair.Value;

                Console.WriteLine($"{username}");

                foreach (string email in emails)
                {
                    Console.WriteLine($" - {email}");
                }
            }
        }
    }
}
