﻿using System;

namespace P05_ComapringObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.name.CompareTo(other.name) != 0)
            {
                return this.name.CompareTo(other.name);
            }

            if (this.age.CompareTo(other.age) != 0)
            {
                return this.age.CompareTo(other.age);
            }

            if (this.town.CompareTo(other.town) != 0)
            {
                return this.town.CompareTo(other.town);
            }

            return 0;
        }
    }
}
