using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = CreateHero(heroType, name);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);
            }

            int bossHealthPoints = int.Parse(Console.ReadLine());

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (heroes.Sum(hero => hero.Power) >= bossHealthPoints)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string heroType, string name)
        {
            BaseHero hero = null;

            if (heroType == nameof(Druid))
            {
                hero = new Druid(name);
            }
            else if (heroType == nameof(Paladin))
            {
                hero = new Paladin(name);
            }
            else if (heroType == nameof(Rogue))
            {
                hero = new Rogue(name);
            }
            else if (heroType == nameof(Warrior))
            {
                hero = new Warrior(name);
            }

            return hero;
        }
    }
}
