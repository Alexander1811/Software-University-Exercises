using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchedBook = Console.ReadLine();
            string enteredBook;
            bool isFound = false;
            int amount = int.Parse(Console.ReadLine());
            int count = amount;

            while (count != 0)
            {
                enteredBook = Console.ReadLine();
                isFound = enteredBook == searchedBook;
                if (isFound)
                {
                    Console.WriteLine($"You checked {amount - count} books and found it."); 
                    break;
                }
                count--;
            }
            if (isFound == false)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {amount} books.");
            }
        }
    }
}
