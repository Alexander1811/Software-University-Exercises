using System;
using System.Collections.Generic;
using System.Linq;
using Players_and_Monsters.Common;
using Players_and_Monsters.Models.Cards.Contracts;
using Players_and_Monsters.Repositories.Contracts;

namespace Players_and_Monsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private IDictionary<string, ICard> cards;

        public CardRepository()
        {
            this.cards = new Dictionary<string, ICard>();
        }

        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.Values.ToList();

        public void Add(ICard card)
        {
            Validator.ThrowIfObjectIsNull(card, ExceptionMessages.CardIsNull);

            if (cards.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card.Name, card);
        }

        public bool Remove(ICard card)
        {
            Validator.ThrowIfObjectIsNull(card, ExceptionMessages.CardIsNull);

            bool isRemoved = this.cards.Remove(card.Name);

            return isRemoved;
        }

        public ICard Find(string name)
        {
            ICard card = cards.Where(c => c.Key == name).FirstOrDefault().Value;

            return card;
        }
    }
}
