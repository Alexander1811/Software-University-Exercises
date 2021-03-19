using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            const int cherryBomb = 60;
            const int daturaBomb = 40;
            const int smokeDecoyBomb = 120;

            int cherryBombCounter = 0;
            int daturaBombCounter = 0;
            int smokeDecoyBombCounter = 0;

            bool isBombPouchFilled = false;

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                int currentBombEffect = bombEffects.Peek();
                int currentBombCasing = bombCasings.Peek();
                int sum = currentBombEffect + currentBombCasing;
                if (sum == cherryBomb || sum == daturaBomb || sum == smokeDecoyBomb)
                {
                    bombCasings.Pop();
                    bombEffects.Dequeue();

                    if (sum == cherryBomb)
                    {
                        cherryBombCounter++;
                    }
                    else if (sum == daturaBomb)
                    {
                        daturaBombCounter++;
                    }
                    else if (sum == smokeDecoyBomb)
                    {
                        smokeDecoyBombCounter++;
                    }

                    //switch (sum)
                    //{
                    //    case daturaBomb:
                    //        daturaBombCounter++;
                    //        break;
                    //    case cherryBomb:
                    //        cherryBombCounter++;
                    //        break;
                    //    case smokeDecoyBomb:
                    //        smokeDecoyBombCounter++;
                    //        break;
                    //}
                }
                else
                {
                    bombCasings.Pop();
                    bombCasings.Push(currentBombCasing - 5);
                }

                if (cherryBombCounter >= 3 && daturaBombCounter >= 3 && smokeDecoyBombCounter >= 3)
                {
                    isBombPouchFilled = true;
                    break;
                }
            }

            if (isBombPouchFilled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombCounter}");
            Console.WriteLine($"Datura Bombs: {daturaBombCounter}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombCounter}");
        }
    }
}
