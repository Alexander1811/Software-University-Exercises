using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex patternRegex = new Regex(@"^(U\$)(?<username>[A-Z]{1}[A-Za-z]{2,})(U\$)(P@\$)(?<password>[A-Za-z]{5,}[0-9]+)(P@\$)$");

            List<string> successfulRegistrations = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match registration = patternRegex.Match(input);

                if (registration.Success)
                {
                    string username = registration.Groups["username"].Value;
                    string password = registration.Groups["password"].Value;

                    successfulRegistrations.Add(username);

                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {successfulRegistrations.Count}");
        }
    }
}
