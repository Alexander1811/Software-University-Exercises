using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, string, bool> startsWith = (name, substring) => name.StartsWith(substring);
            Func<string, string, bool> endsWith = (name, substring) => name.EndsWith(substring);
            Func<string, string, bool> length = (name, count) => name.Length == int.Parse(count);

            Func<List<string>, string, List<string>> removeNames = (names, name) =>
            {
                List<string> newNames = names.GetRange(0, names.Count);
                foreach (string currentName in names)
                {
                    if (currentName == name)
                    {
                        newNames.RemoveAll(names => names.Contains(name));
                    }
                }
                return newNames;
            };
            Func<List<string>, string, List<string>> doubleNames = (names, name) =>
            {
                List<string> newNames = names.GetRange(0, names.Count);
                foreach (string currentName in names)
                {
                    if (currentName == name)
                    {
                        newNames.Insert(names.IndexOf(name), name);
                    }
                }
                return newNames;
            };

            Func<List<string>, string, string, string, List<string>> manipulateList = (names, criteriaType, actionType, parameter) =>
            {
                Func<List<string>, string, List<string>> action = (names, name) => { return names; };
                Func<string, string, bool> criteria = (name, content) => { return true; };

                if (actionType == "Remove")
                {
                    action = removeNames;
                }
                else if (actionType == "Double")
                {
                    action = doubleNames;
                }

                if (criteriaType == "StartsWith")
                {
                    criteria = startsWith;
                }
                else if (criteriaType == "EndsWith")
                {
                    criteria = endsWith;
                }
                else if (criteriaType == "Length") 
                { 
                    criteria = length; 
                }

                HashSet<string> namesUnique = names.ToHashSet();
                foreach (string name in namesUnique)
                {
                    if (criteria(name, parameter))
                    {
                        names = action(names, name);
                    }
                }

                return names;
            };

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];
                string criteria = command[1];
                string parameter = command[2];

                names = manipulateList(names, criteria, action, parameter);
            }

            if (names.Any())
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
