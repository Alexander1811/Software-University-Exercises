namespace Aquariums.Tests
{
    using System;

    using NUnit.Framework;

    public class AquariumsTests
    {
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("AquaTopia", 10);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_ThrowsException_WhenNameIsInvalid(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 10), "Invalid aquarium name!");
        }

        [Test]
        [TestCase(-10)]
        public void Ctor_ThrowsException_WhenNameIsInvalid(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("AquaTopia", capacity), "Invalid aquarium capacity!");
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < this.aquarium.Capacity; i++)
            {
                this.aquarium.Add(new Fish($"Nemo{i}"));
            }

            string name = "InvalidName";

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(new Fish(name)), $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void Add_AddsFish()
        {
            this.aquarium.Add(new Fish("Nemo"));

            Assert.That(this.aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_ThrowsException_WhenFishDoesNotExist()
        {
            Fish fish = new Fish("Nemo");

            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish(fish.Name), $"Fish with the name {fish.Name} doesn't exist!");
        }

        [Test]
        public void Remove_RemovesFish()
        {
            Fish fish = new Fish("Nemo");

            this.aquarium.Add(fish);
            this.aquarium.RemoveFish(fish.Name);

            Assert.That(this.aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void SellFish_ThrowsException_WhenFishDoesNotExist()
        {
            Fish fish = new Fish("Nemo");

            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish(fish.Name), $"Fish with the name {fish.Name} doesn't exist!");
        }

        [Test]
        public void SellFish_ReturnsFish()
        {
            Fish fish = new Fish("Nemo");

            this.aquarium.Add(fish);

            Assert.That(this.aquarium.SellFish(fish.Name), Is.EqualTo(fish));
            Assert.That(fish.Available, Is.False);
        }

        [Test]
        public void Report_ReturnsReport()
        {
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Ozzy");
            Fish fish3 = new Fish("George");

            this.aquarium.Add(fish1);
            this.aquarium.Add(fish2);
            this.aquarium.Add(fish3);

            string fishNames = string.Join(", ", fish1.Name, fish2.Name, fish3.Name);

            Assert.That(this.aquarium.Report(), Is.EqualTo($"Fish available at {this.aquarium.Name}: {fishNames}"));
        }
    }
}
