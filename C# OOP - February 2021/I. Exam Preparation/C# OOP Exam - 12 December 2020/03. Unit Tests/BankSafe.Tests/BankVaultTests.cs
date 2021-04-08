using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellDoesNotExist()
        {
            string cell = "D5";
            Item item = new Item("Ivan", "ABC123");

            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem(cell, item));
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellIsAlreadyTaken()
        {
            string cell = "A1";
            Item firstItem = new Item("Ivan", "ABC123");

            this.bankVault.AddItem(cell, firstItem);

            Item secondItem = new Item("Misho", "DEF456");

            Assert.Throws<ArgumentException>(()=> this.bankVault.AddItem(cell, secondItem));
        }

        [Test]
        public void AddItem_ThrowsException_WhenItemIsAlreadyInCell()
        {
            string cell = "A1";
            Item item = new Item("Ivan", "ABC123");

            this.bankVault.AddItem(cell, item);

            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem(cell, item));
        }

        [Test]
        public void AddItem_AddsItemToCell()
        {
            string cell = "A1";
            Item item = new Item("Ivan", "ABC123");

            string result = this.bankVault.AddItem(cell, item);

            Assert.That(this.bankVault.VaultCells.Values.Where(i => i == item).Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenCellDoesNotExist()
        {
            string cell = "D5";
            Item item = new Item("Ivan", "ABC123");

            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem(cell, item));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenCellDoesNotContainItem()
        {
            string cell = "A1";
            Item firstItem = new Item("Ivan", "ABC123");

            this.bankVault.AddItem(cell, firstItem);
            this.bankVault.RemoveItem(cell, firstItem);

            Item secondItem = new Item("Misho", "DEF456");

            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem(cell, secondItem));
        }

        [Test]
        public void RemoveItem_RemovesItemFromCell()
        {
            string cell = "A1";
            Item item = new Item("Ivan", "ABC123");

            this.bankVault.AddItem(cell, item);

            string result = this.bankVault.RemoveItem(cell, item);
            Assert.That(this.bankVault.VaultCells.Values.Where(i => i == item).Count, Is.EqualTo(0));
            Assert.That(result, Is.EqualTo($"Remove item:{item.ItemId} successfully!"));            
        }

        [Test]
        public void Ctor_InitalizesBankVault()
        {
            Assert.That(this.bankVault.VaultCells.Keys != null);
            Assert.That(this.bankVault.VaultCells.Values.All(cell => cell == null));
        }
    }
}