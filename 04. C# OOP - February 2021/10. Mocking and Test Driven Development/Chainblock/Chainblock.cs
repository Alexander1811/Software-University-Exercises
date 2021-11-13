using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Chainblock : IChainblock, IEnumerable
    {
        private readonly Dictionary<int, ITransaction> transactionsById;

        public Chainblock()
        {
            this.transactionsById = new Dictionary<int, ITransaction>();
        }

        public int Count => this.transactionsById.Count;

        public void Add(ITransaction tx)
        {
            if (this.transactionsById.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException($"Transaction with id: {tx.Id} already exists.");
            }

            this.transactionsById.Add(tx.Id, tx);
        }

        public bool Contains(ITransaction tx)
        {
            if (!this.Contains(tx.Id))
            {
                return false;
            }

            ITransaction existingTransaction = this.transactionsById[tx.Id];

            return tx.From == existingTransaction.From &&
                   tx.To == existingTransaction.To &&
                   tx.Amount == existingTransaction.Amount &&
                   tx.Status == existingTransaction.Status;
        }

        public bool Contains(int id)
        {
            return this.transactionsById.ContainsKey(id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException($"Transaction with id {id} does not exist.");
            }

            ITransaction transaction = this.transactionsById[id];

            transaction.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with id {id} does not exist.");
            }

            this.transactionsById.Remove(id);
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with id {id} does not exist.");
            }

            return this.transactionsById[id];
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> result = this.transactionsById.Values.Where(t => t.Status == status).OrderByDescending(t => t.Amount).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException($"No transaction with status {status}.");
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = this.transactionsById.Values.Where(t => t.Status == status).OrderBy(t => t.Amount).Select(t => t.From).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException($"No senders with transactions with status {status}.");
            }

            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = this.transactionsById.Values.Where(t => t.Status == status).OrderBy(t => t.Amount).Select(t => t.To).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException($"No receivers with transactions with status {status}.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (transactionsById.Values.FirstOrDefault(t => t.From == sender) == null)
            {
                throw new InvalidOperationException($"No transactions sent by {sender}.");
            }

            return this.Where(t => t.From == sender).OrderByDescending(t => t.Amount).ToList();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (this.transactionsById.Values.FirstOrDefault(t => t.To == receiver) == null)
            {
                throw new InvalidOperationException($"No transactions received by {receiver}.");
            }

            return this.Where(t => t.To == receiver).OrderByDescending(t => t.Amount).ThenByDescending(t => t.Id).ToList();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            if (this.transactionsById.Values.FirstOrDefault(t => t.Status == status && t.Amount <= amount) == null)
            {
                //throw new InvalidOperationException($"No transactions with status {status} with amount less or equal to {amount}.");

                return new List<ITransaction>();
            }

            return this.Where(t => t.Status == status && t.Amount <= amount).OrderByDescending(t => t.Amount).ToList();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (this.transactionsById.Values.FirstOrDefault(t => t.From == sender && t.Amount > amount) == null)
            {
                throw new InvalidOperationException($"No transactions sent by sender {sender} with amount more than {amount}.");
            }

            return this.Where(t => t.From == sender && t.Amount > amount).OrderByDescending(t => t.Amount).ToList();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (this.transactionsById.Values.FirstOrDefault(t => t.To == receiver && t.Amount >= lo && t.Amount < hi) == null)
            {
                throw new InvalidOperationException($"No transactions received by receiver {receiver} with amount in the range [{lo};{hi}).");
            }

            return this.Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi).OrderByDescending(t => t.Amount).ToList();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            if (this.transactionsById.Values.FirstOrDefault(t=> t.Amount >= lo && t.Amount <= hi) == null)
            {
                throw new InvalidOperationException($"No transactions with amount in the range [{lo};{hi}].");
            }

            return this.Where(t => t.Amount >= lo && t.Amount <= hi).OrderByDescending(t => t.Amount).ToList();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (KeyValuePair<int, ITransaction> transaction in this.transactionsById)
            {
                yield return transaction.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
