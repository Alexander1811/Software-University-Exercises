using Chainblock.Contracts;

namespace Chainblock.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Setup()
        {
            this.chainblock = new Chainblock();
        }

        [Test]
        public void Add_ThrowsException_WhenTransactionWithIdAlreadyExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.Add(transaction));
        }

        [Test]
        public void Add_AddsTransaction()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Count, Is.EqualTo(1));
            Assert.That(this.chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsId_ReturnsTrue_WhenTransactionWithIdExists()
        {
            ITransaction transaction = CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsFalse_WhenTransactionWithIdDoesNotExist()
        {
            Assert.That(this.chainblock.Contains(1), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionWithIdDoesNotExist()
        {
            Assert.That(this.chainblock.Contains(this.CreateSimpleTransaction()), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionWithIdExistsButOtherPropertiesDoNotMatch()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            ITransaction searchingTransaction = new Transaction
            {
                Id = transaction.Id,
                Amount = transaction.Amount + 50,
                From = transaction.From + "Fake",
                To = transaction.To + "Fake",
                Status = TransactionStatus.Failed
            };

            Assert.That(this.chainblock.Contains(searchingTransaction), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsTrue_WhenTransactionMatchesWithChainblockTransaction()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            ITransaction searchingTransaction = new Transaction
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                From = transaction.From,
                To = transaction.To,
                Status = transaction.Status
            };

            Assert.That(this.chainblock.Contains(searchingTransaction), Is.True);
        }

        [Test]
        public void Count_ReturnsZero_WhenChainblockIsEmpty()
        {
            Assert.That(this.chainblock.Count, Is.EqualTo(0));
        }

        [Test]
        public void ChangeTransactionStatus_ThrowsException_WhenIdDoesNotExist()
        {
            this.chainblock.Add(this.CreateSimpleTransaction());

            Assert.Throws<ArgumentException>(() => this.chainblock.ChangeTransactionStatus(100, TransactionStatus.Failed));
        }

        [Test]
        public void ChangeTransactionStatus_ChangesTransactionStatus_WhenIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            TransactionStatus newStatus = TransactionStatus.Unauthorized;

            this.chainblock.ChangeTransactionStatus(transaction.Id, newStatus);

            Assert.That(transaction.Status, Is.EqualTo(newStatus));
        }

        [Test]
        public void RemoveTransactionById_ThrowsException_WhenIdDoesNotExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(transaction.Id + 2));
        }

        [Test]
        public void RemoveTransactionById_RemovesTransaction_WhenIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            this.chainblock.RemoveTransactionById(transaction.Id);

            Assert.That(this.chainblock.Count, Is.EqualTo(0));
            Assert.That(this.chainblock.Contains(transaction), Is.False);
        }

        [Test]
        public void GetById_ThrowsException_WhenIdDoesNotExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(transaction.Id + 2));
        }

        [Test]
        public void GetById_ReturnsExpectedTransaction_WhenIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            ITransaction chainblockTransaction = this.chainblock.GetById(transaction.Id);

            Assert.That(transaction, Is.EqualTo(chainblockTransaction));
        }

        [Test]
        public void GetByTransactionStatus_ThrowsException_WhenThereAreNoTransactionsWithStatus()
        {
            this.AddThreeTransactionWithDifferentStatus();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void GetByTransactionStatus_ReturnsFilteredAndSortedData_WhenChainblockContainsTransactionsWithStatus()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            TransactionStatus filterStatus = TransactionStatus.Successful;

            List<ITransaction> expectedTransactions = this.chainblock
                .Where(t => t.Status == filterStatus)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actualTransactions = this.chainblock.GetByTransactionStatus(filterStatus).ToList();

            Assert.That(expectedTransactions, Is.EquivalentTo(actualTransactions));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ThrowsException_WhenTransactionsWithStatusDoNotExist()
        {
            this.AddThreeTransactionWithDifferentStatus();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ReturnsFilteredAndSortedData_WhenChainblockContainsTransactionsWithStatus()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            TransactionStatus filterStatus = TransactionStatus.Successful;

            List<string> expectedSenders = this.chainblock
                .Where(t => t.Status == filterStatus)
                .OrderByDescending(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            List<string> actualSenders = this.chainblock.GetAllSendersWithTransactionStatus(filterStatus).ToList();

            Assert.That(expectedSenders, Is.EquivalentTo(actualSenders));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ThrowsException_WhenTransactionsWithStatusDoNotExist()
        {
            this.AddThreeTransactionWithDifferentStatus();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ReturnsFilteredAndSortedData_WhenChainblockContainsTransactionsWithStatus()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            TransactionStatus filterStatus = TransactionStatus.Successful;

            List<string> expectedReceivers = this.chainblock
                .Where(t => t.Status == filterStatus)
                .OrderByDescending(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            List<string> actualReceivers = this.chainblock.GetAllReceiversWithTransactionStatus(filterStatus).ToList();

            Assert.That(expectedReceivers, Is.EquivalentTo(actualReceivers));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsSortedData()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            List<ITransaction> expectedTransactions = this.chainblock
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            List<ITransaction> actualTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.That(expectedTransactions, Is.EquivalentTo(actualTransactions));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsException_WhenSenderHasNoTransactions()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderOrderedByAmountDescending("FakeSender"));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsFilteredAndSortedData()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            string sender = this.chainblock.FirstOrDefault().From;

            List<ITransaction> expectedTransactions = this.chainblock
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actualTransactions = this.chainblock.GetBySenderOrderedByAmountDescending(sender).ToList();

            Assert.That(expectedTransactions, Is.EquivalentTo(actualTransactions));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ThrowsException_WhenReceiverHasNoTransactions()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverOrderedByAmountThenById("FakeReceiver"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsFilteredAndSortedData()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            string receiver = this.chainblock.FirstOrDefault().To;

            List<ITransaction> expectedTransactions = this.chainblock
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenByDescending(t => t.Id)
                .ToList();

            List<ITransaction> actualTransactions = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver).ToList();

            Assert.That(expectedTransactions, Is.EquivalentTo(actualTransactions));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsEmptyCollection_WhenStatusOrAmountIsNotValid()
        {
            this.AddThreeTransactionWithDifferentStatus();

            double amountMax = this.chainblock.Select(t => t.Amount).Max();
            double amountMin = this.chainblock.Select(t => t.Amount).Min();

            List<ITransaction> transactions = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successful, amountMax).ToList();

            Assert.That(transactions.Count, Is.Zero);

            transactions = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, amountMin - 1).ToList();

            Assert.That(transactions.Count, Is.Zero);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsFilteredAndSortedData()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            TransactionStatus filterStatus = TransactionStatus.Aborted;
            double filterAmount = this.chainblock.Average(t => t.Amount);

            List<ITransaction> expectedTransactions = this.chainblock
                .Where(t => t.Status == filterStatus && t.Amount <= filterAmount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actualTransactions = this.chainblock.GetByTransactionStatusAndMaximumAmount(filterStatus, filterAmount).ToList();

            Assert.That(expectedTransactions, Is.EquivalentTo(actualTransactions));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsException_WhenSenderOrAmountIsNotValid()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            string realSender = this.chainblock.FirstOrDefault().From;
            double amountMin = this.chainblock.Select(t => t.Amount).Min();

            string fakeSender = "FakeSender";
            double amountMax = this.chainblock.Select(t => t.Amount).Max();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending(fakeSender, amountMin).ToList());
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending(realSender, amountMax).ToList());
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ReturnsFilteredAndSortedData()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            string realSender = this.chainblock.FirstOrDefault().From;
            double amountMin = this.chainblock.Select(t => t.Amount).Min();

            List<ITransaction> expectedTransactions = this.chainblock
                .Where(t => t.From == realSender && t.Amount > amountMin)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actualTransactions = this.chainblock.GetBySenderAndMinimumAmountDescending(realSender, amountMin).ToList();

            Assert.That(expectedTransactions, Is.EquivalentTo(actualTransactions));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ThrowsException_WhenReceiverOrAmountIsNotValid()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            string realReceiver = this.chainblock.FirstOrDefault().To;
            string fakeReceiver = "FakeReceiver";

            double lo = this.chainblock.Select(t => t.Amount).Min();
            double hi = this.chainblock.Select(t => t.Amount).Max();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverAndAmountRange(fakeReceiver, lo, hi).ToList());
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverAndAmountRange(realReceiver, hi, lo).ToList());
        }

        [Test]
        public void GetByReceiverAndAmountRange_ReturnsFilteredAndSortedData()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            string realReceiver = this.chainblock.FirstOrDefault().To;

            double lo = this.chainblock.Select(t => t.Amount).Min();
            double hi = this.chainblock.Select(t => t.Amount).Max();

            List<ITransaction> expectedTransactions = this.chainblock
                .Where(t => t.To == realReceiver && t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actualTransactions = this.chainblock.GetByReceiverAndAmountRange(realReceiver, lo, hi).ToList();

            Assert.That(expectedTransactions, Is.EquivalentTo(actualTransactions));
        }

        [Test]
        public void GetAllInAmountRange_ThrowsException_WhenAmountIsNotValid()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            double amountMin = this.chainblock.Select(t => t.Amount).Min();
            double amountMax = this.chainblock.Select(t => t.Amount).Max();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllInAmountRange(amountMax, amountMin).ToList());
        }

        [Test]
        public void GetAllInAmountRange_ReturnsFilteredAndSortedData()
        {
            this.AddBulkOfTransactionWithDifferentStatus();

            double lo = this.chainblock.Select(t => t.Amount).Min();
            double hi = this.chainblock.Select(t => t.Amount).Max();

            List<ITransaction> expectedTransactions = this.chainblock
                .Where(t => t.Amount >= lo && t.Amount <= hi)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actualTransactions = this.chainblock.GetAllInAmountRange(lo, hi).ToList();

            Assert.That(expectedTransactions, Is.EquivalentTo(actualTransactions));
        }

        private void AddThreeTransactionWithDifferentStatus()
        {
            this.chainblock.Add(new Transaction
            {
                Id = 1,
                Amount = 100,
                From = "From",
                To = "To",
                Status = TransactionStatus.Failed
            });

            this.chainblock.Add(new Transaction
            {
                Id = 2,
                Amount = 100,
                From = "From",
                To = "To",
                Status = TransactionStatus.Aborted
            });

            this.chainblock.Add(new Transaction
            {
                Id = 3,
                Amount = 100,
                From = "From",
                To = "To",
                Status = TransactionStatus.Unauthorized
            });
        }

        private void AddBulkOfTransactionWithDifferentStatus()
        {
            int n = 100;

            for (int i = 0; i < n; i++)
            {
                TransactionStatus status = TransactionStatus.Successful;

                if (i % 2 == 0)
                {
                    status = TransactionStatus.Aborted;
                }
                else if (i % 3 == 0)
                {
                    status = TransactionStatus.Failed;
                }
                else if (i % 5 == 0)
                {
                    status = TransactionStatus.Unauthorized;
                }

                double amount = i % 2 == 0 ? 100 : 100 + i;

                string from = i % 3 == 0 ? $"Sender" : $"Sender{i}";

                string to = i % 5 == 0 ? $"Receiver" : $"Receiver{i}";

                ITransaction transaction = new Transaction
                {
                    Id = n - i,
                    Amount = amount,
                    From = from,
                    To = to,
                    Status = status
                };

                this.chainblock.Add(transaction);
            }
        }

        private ITransaction CreateSimpleTransaction()
        {
            ITransaction transaction = new Transaction
            {
                Id = 1,
                Amount = 100,
                From = "From",
                To = "To",
                Status = TransactionStatus.Successful
            };

            return transaction;
        }
    }
}