using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string personName = command[0];
                string productName = command[1];

                Person person = people[personName];
                Product product = products[productName];

                try
                {
                    person.AddProduct(product);

                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (Exception ex)
                when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }


            }

            foreach (Person person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Product> ReadProducts()
        {
            Dictionary<string, Product> result = new Dictionary<string, Product>();

            string[] products = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string productArgs in products)
            {
                string[] productDate = productArgs.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = productDate[0];
                decimal cost = decimal.Parse(productDate[1]);

                result[name] = new Product(name, cost);
            }

            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            Dictionary<string, Person> result = new Dictionary<string, Person>();

            string[] people = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string personArgs in people)
            {
                string[] personData = personArgs.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);

                result[name] = new Person(name, money);
            }

            return result;
        }
    }
}
