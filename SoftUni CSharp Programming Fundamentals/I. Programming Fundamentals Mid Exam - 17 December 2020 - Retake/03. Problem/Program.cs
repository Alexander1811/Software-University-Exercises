using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];

                if (action == "Change")
                {
                    int paintingNumber = int.Parse(command[1]);
                    int changedNumber = int.Parse(command[2]);
                    if (numbers.Contains(paintingNumber))
                    {
                        int index = numbers.IndexOf(paintingNumber);

                        numbers.Remove(paintingNumber);
                        numbers.Insert(index, changedNumber);
                    }
                }
                else if (action == "Hide")
                {
                    int paintingNumber = int.Parse(command[1]);
                    if (numbers.Contains(paintingNumber))
                    {
                        numbers.Remove(paintingNumber);
                    }
                }
                else if (action == "Switch")
                {
                    int firstPaintingNumber = int.Parse(command[1]);
                    int secondPaintingNumber = int.Parse(command[2]);

                    if (numbers.Contains(firstPaintingNumber) && numbers.Contains(secondPaintingNumber))
                    {
                        int firstIndex = numbers.IndexOf(firstPaintingNumber);
                        int secondIndex = numbers.IndexOf(secondPaintingNumber);

                        if (firstIndex > secondIndex)
                        {
                            firstIndex = numbers.IndexOf(secondPaintingNumber);
                            secondIndex = numbers.IndexOf(firstPaintingNumber);

                            numbers.RemoveAt(secondIndex);
                            numbers.RemoveAt(firstIndex);

                            numbers.Insert(firstIndex, firstPaintingNumber);
                            numbers.Insert(secondIndex, secondPaintingNumber);
                        }
                        else
                        {
                            numbers.RemoveAt(secondIndex);
                            numbers.RemoveAt(firstIndex);

                            numbers.Insert(firstIndex, secondPaintingNumber);
                            numbers.Insert(secondIndex, firstPaintingNumber);
                        }                        
                    }
                }
                else if (action == "Insert")
                {
                    int place = int.Parse(command[1]);
                    int paintingNumber = int.Parse(command[2]);

                    if (place >= 0 && place <= numbers.Count - 1)
                    {
                        numbers.Insert(place + 1, paintingNumber);
                    }
                }
                else if (action == "Reverse")
                {
                    numbers.Reverse();
                }
            }

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
