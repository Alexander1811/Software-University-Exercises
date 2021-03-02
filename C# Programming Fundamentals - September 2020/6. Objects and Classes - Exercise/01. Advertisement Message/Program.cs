using System;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};
            Random number = new Random();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int indexPhrases = number.Next(0, phrases.Length);
                int indexEvents = number.Next(0, events.Length);
                int indexAuthors = number.Next(0, authors.Length);
                int indexCities = number.Next(0, cities.Length);

                Console.WriteLine($"{phrases[indexPhrases]} {events[indexEvents]} {authors[indexAuthors]} – {cities[indexCities]}.");
            }
        }
    }

    class Message
    {
        public Message(string phrases, string events, string authors, string cities)
        {
            Phrases = phrases;
            Events = events;
            Authors = authors;
            Cities = cities;
        }

        public string Phrases { get; set; }
        public string Events { get; set; }
        public string Authors { get; set; }
        public string Cities { get; set; }
    }
}
