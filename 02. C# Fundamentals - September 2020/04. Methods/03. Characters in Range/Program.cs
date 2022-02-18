using System;

namespace P03_CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            char ASCIIStart = start;
            char ASCIIEnd = end;

            if (start > end)
            {
                ASCIIStart = end;
                ASCIIEnd = start;

            }

            CharachtersInRange(ASCIIStart, ASCIIEnd);

        }

        static void CharachtersInRange(char a, char b)
        {
            for (int i = (int)a + 1; i < (int)b; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
