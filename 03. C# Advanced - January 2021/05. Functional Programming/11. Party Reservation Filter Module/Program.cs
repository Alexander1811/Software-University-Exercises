using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> originalNames = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> previousNames = originalNames.GetRange(0, originalNames.Count);
            List<string> currentNames = new List<string>();

            Func<string, string, bool> startsWith = (name, substring) => name.StartsWith(substring);
            Func<string, string, bool> endsWith = (name, substring) => name.EndsWith(substring);
            Func<string, string, bool> length = (name, count) => name.Length == int.Parse(count);
            Func<string, string, bool> contains = (name, substring) => name.Contains(substring);

            Func<List<string>, List<string>, string, List<string>> removeNames = (originalNames, previousNames, name) =>
            {
                List<string> currentNames = previousNames.GetRange(0, previousNames.Count);
                currentNames.RemoveAll(previousNames => previousNames.Contains(name));
                foreach (string currentName in previousNames)
                {
                    if (currentName == name)
                    {
                        currentNames.Insert(previousNames.IndexOf(name), "");
                    }
                }
                return currentNames;
            };
            Func<List<string>, List<string>, string, List<string>> addNames = (originalNames, previousNames, name) =>
            {
                List<string> currentNames = previousNames.GetRange(0, previousNames.Count);
                foreach (string currentName in originalNames)
                {
                    if (currentName == name)
                    {
                        currentNames.Insert(originalNames.IndexOf(name), name);
                    }
                }
                return currentNames;
            };

            Func<List<string>, List<string>, List<string>, string, string, string, List<string>> manipulateList = (currentNames, originalNames, previousNames, criteriaType, actionType, parameter) =>
            {
                Func<List<string>, List<string>, string, List<string>> action = (originalNames, previousNames, name) => { return originalNames; };
                Func<string, string, bool> criteria = (name, content) => { return true; };

                if (actionType == "Add filter")
                {
                    action = removeNames;
                }
                else if (actionType == "Remove filter")
                {
                    action = addNames;
                }

                if (criteriaType == "Starts with")
                {
                    criteria = startsWith;
                }
                else if (criteriaType == "Ends with")
                {
                    criteria = endsWith;
                }
                else if (criteriaType == "Length")
                {
                    criteria = length;
                }
                else if (criteriaType == "Contains")
                {
                    criteria = contains;
                }

                foreach (string name in originalNames)
                {
                    if (criteria(name, parameter))
                    {
                        currentNames = action(originalNames, previousNames, name);
                    }
                }

                return currentNames;
            };

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] command = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];
                string criteria = command[1];
                string parameter = command[2];

                currentNames = manipulateList(currentNames, originalNames, previousNames, criteria, action, parameter);
                previousNames = currentNames.GetRange(0, currentNames.Count);
            }

            currentNames.RemoveAll(names => names == "");
            Console.WriteLine(string.Join(" ", currentNames));
        }
    }
}
