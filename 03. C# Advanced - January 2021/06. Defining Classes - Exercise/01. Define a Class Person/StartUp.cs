﻿using System;

namespace _01.Defining_a_Class_Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = "Pesho";
            int age = 20;
            Person person = new Person()
            {
                Name = name,
                Age = age
            };

            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
