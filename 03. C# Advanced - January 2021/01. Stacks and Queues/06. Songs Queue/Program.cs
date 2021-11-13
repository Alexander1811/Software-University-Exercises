using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsSequence = Console.ReadLine().Split(", ").ToArray();

            Queue<string> songs = new Queue<string>(songsSequence);

            while (songs.Any())
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();
                string command = input[0];

                if (command == "Add")
                {
                    string song = "";
                    for (int i = 1; i < input.Length; i++)
                    {
                        song += input[i] + " ";
                    }

                    song = song.Trim();

                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
