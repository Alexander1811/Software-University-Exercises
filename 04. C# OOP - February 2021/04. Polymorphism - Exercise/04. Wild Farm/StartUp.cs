namespace P04WildFarm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P04WildFarm.Animals;
    using P04WildFarm.Animals.Mammals;
    using P04WildFarm.Animals.Birds;
    using P04WildFarm.Foods;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalParts = input.Split(" ").ToArray();

                Animal animal = CreateAnimal(animalParts);
                animals.Add(animal);

                string[] foodParts = Console.ReadLine().Split(" ").ToArray();

                Food food = CreateFood(foodParts);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Animal CreateAnimal(string[] animalParts)
        {
            string animalType = animalParts[0];
            string name = animalParts[1];
            double weight = double.Parse(animalParts[2]);

            Animal animal = null;

            if (animalType == nameof(Hen))
            {
                double wingSize = double.Parse(animalParts[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else if (animalType == nameof(Owl))
            {
                double wingSize = double.Parse(animalParts[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == nameof(Dog))
            {
                string livingRegion = animalParts[3];

                animal = new Dog(name, weight, livingRegion);
            }
            else if (animalType == nameof(Mouse))
            {
                string livingRegion = animalParts[3];

                animal = new Mouse(name, weight, livingRegion);
            }
            else if (animalType == nameof(Cat))
            {
                string livingRegion = animalParts[3];
                string breed = animalParts[4];

                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (animalType == nameof(Tiger))
            {
                string livingRegion = animalParts[3];
                string breed = animalParts[4];

                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }

        private static Food CreateFood(string[] foodParts)
        {
            string foodType = foodParts[0];
            int quantity = int.Parse(foodParts[1]);

            Food food = null;

            if (foodType == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (foodType == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (foodType == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }

    }
}
