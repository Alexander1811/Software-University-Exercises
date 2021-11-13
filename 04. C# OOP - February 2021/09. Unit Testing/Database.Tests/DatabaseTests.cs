namespace Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Add_IncreasesDatabaseCount_WhenAddIsValidOperation()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(123);
            }

            Assert.That(this.database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_AddsElementToDatabase()
        {
            int element = 123;

            this.database.Add(element);

            int[] elements = this.database.Fetch();

            Assert.IsTrue(elements.Contains(element));
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_DecreasesDatabaseCount()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            this.database.Remove();

            Assert.That(this.database.Count, Is.EqualTo(n - 1));
        }

        [Test]
        public void Remove_RemovesElementFromDatabase()
        {
            int lastElement = 3;

            this.database.Add(1);
            this.database.Add(2);
            this.database.Add(lastElement);

            this.database.Remove();

            int[] elements = this.database.Fetch();

            Assert.IsFalse(elements.Contains(lastElement));
        }

        [Test]
        public void Fetch_ReturnsDatabaseCopyInsteadOfReference()
        {
            this.database.Add(1);
            this.database.Add(2);

            int[] firstCopy = this.database.Fetch();

            this.database.Add(3);

            int[] secondCopy = this.database.Fetch();

            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }

        [Test]
        public void Count_ReturnsZero_WhenDatabaseIsEmpty()
        {
            Assert.That(this.database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsException_WhenDatabaseCapacityIsExceeded()
        {
            int[] array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() => this.database = new Database.Database(array));
        }

        [Test]
        public void Ctor_AddsElementsToDatabse()
        {
            int[] array = new[] { 1, 2, 3 };
            this.database = new Database.Database(array);

            Assert.That(this.database.Count, Is.EqualTo(array.Length));
            Assert.That(this.database.Fetch, Is.EquivalentTo(array));
        }
    }
}