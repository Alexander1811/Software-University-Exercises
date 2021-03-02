using System;

namespace _07._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            double takenSeats = 0;
            double sumTickets = 0;
            double studentTickets = 0;
            double standardTickets = 0;
            double kidTickets = 0;
            while (movie != "Finish")
            {                               
                int seats = int.Parse(Console.ReadLine());
                
                for (takenSeats = 0; seats > takenSeats; takenSeats++)
                {
                    string type = Console.ReadLine(); 
                    if (type == "student")
                    {
                        studentTickets++;
                    }
                    else if (type == "standard")
                    {
                        standardTickets++;
                    }
                    else if (type == "kid")
                    {
                        kidTickets++;
                    }
                    if (type == "End")
                    {
                        break;
                    }
                }
                
                sumTickets += takenSeats;
                Console.WriteLine($"{movie} - {(takenSeats / seats * 100):f2}% full.");
                movie = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {sumTickets}");
            Console.WriteLine($"{studentTickets / sumTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{standardTickets / sumTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{kidTickets / sumTickets * 100:f2}% kids tickets.");
        }
    }
}
