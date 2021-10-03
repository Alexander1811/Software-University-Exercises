﻿using System;
using System.Linq;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Ctor_InitializeWarriors()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Count_IsZero_WhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enroll_ThrowsException_WhenWarriorAlreadyExists()
        {
            string name = "Warrior";

            this.arena.Enroll(new Warrior(name, 50, 50));

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(name, 55, 55)));
        }

        [Test]
        public void Enroll_IncreasesArenaCount()
        {
            this.arena.Enroll(new Warrior("Warrior", 50, 50));

            Assert.That(this.arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_AddsWarriorToWarriors()
        {
            string name = "Warrior";

            this.arena.Enroll(new Warrior(name, 50, 50));

            Assert.That(this.arena.Warriors.Any(warrior => warrior.Name == name), Is.True);
        }

        [Test]
        [TestCase("Attacker", "Attacker", "Defender")]
        [TestCase("Defender", "Attacker", "Defender")]
        [TestCase("Warrior", "Attacker", "Defender")]
        public void Fight_ThrowsException_WhenOneOrBothFightersDoNotExist(string warriorName, string attackerName, string defenderName)
        {
            this.arena.Enroll(new Warrior(warriorName, 50, 50));

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attackerName, defenderName));
        }

        [Test]
        public void Fight_BothWarriorsLoseHealthPointsInFIght()
        {
            int initialHp = 100;

            Warrior attacker = new Warrior("Attacker", 50, initialHp);
            Warrior defender = new Warrior("Warrior", 50, initialHp);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHp - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHp - attacker.Damage));
        }
    }
}
