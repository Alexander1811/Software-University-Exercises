using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> usersList = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = command[0];
                string username = command[1];

                RegisterOrUnregisterUsers(usersList, command, action, username);
            }

            PrintUsers(usersList);
        }

        private static void PrintUsers(Dictionary<string, string> usersList)
        {
            foreach (KeyValuePair<string, string> keyValuePair in usersList)
            {
                string username = keyValuePair.Key;
                string licensePlateNumber = keyValuePair.Value;

                Console.WriteLine($"{username} => {licensePlateNumber}");
            }
        }

        private static void RegisterOrUnregisterUsers(Dictionary<string, string> usersList, string[] command, string action, string username)
        {
            if (action == "register")
            {
                string licensePlateNumber = command[2];

                if (usersList.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                }
                else
                {
                    usersList[username] = licensePlateNumber;

                    Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                }
            }
            else if (action == "unregister")
            {
                if (!usersList.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: user {username} not found");
                }
                else
                {
                    usersList.Remove(username);

                    Console.WriteLine($"{username} unregistered successfully");
                }
            }
        }
    }
}
