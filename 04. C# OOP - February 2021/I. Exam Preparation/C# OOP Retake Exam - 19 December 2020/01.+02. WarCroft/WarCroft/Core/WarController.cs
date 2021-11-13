namespace WarCroft.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Constants;
    using Entities.Characters;
    using Entities.Characters.Contracts;
    using Entities.Items;

    public class WarController
    {
        private readonly IDictionary<string, Character> characterParty;
        private readonly IList<Item> itemPool;

        public WarController()
        {
            this.characterParty = new Dictionary<string, Character>();
            this.itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            if (characterType != nameof(Warrior) && characterType != nameof(Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            Character character = null;

            if (characterType == nameof(Warrior))
            {
                character = new Warrior(name);
            }
            else if (characterType == nameof(Priest))
            {
                character = new Priest(name);
            }

            this.characterParty.Add(character.Name, character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            if (itemName != nameof(FirePotion) && itemName != nameof(HealthPotion))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            Item item = null;

            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }

            this.itemPool.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (!this.characterParty.ContainsKey(characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Character character = this.characterParty.FirstOrDefault(c => c.Key == characterName).Value;
            Item item = this.itemPool.Last();
            character.Bag.AddItem(item);

            this.itemPool.RemoveAt(this.itemPool.IndexOf(item));


            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (!this.characterParty.ContainsKey(characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Character character = this.characterParty.FirstOrDefault(c => c.Key == characterName).Value;
            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name);
        }

        public string GetStats()
        {
            List<Character> charactersSorted = this.characterParty.Values.OrderByDescending(c => c.Health).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (Character character in charactersSorted)
            {
                string status = character.IsAlive == true ? "Alive" : "Dead";
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, status));
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            if (!this.characterParty.ContainsKey(attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (!this.characterParty.ContainsKey(receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            Warrior attacker = (Warrior)this.characterParty.FirstOrDefault(c => c.Key == attackerName).Value;

            if (attacker.GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Character receiver = this.characterParty.FirstOrDefault(c => c.Key == receiverName).Value;

            attacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
                receiver.IsAlive = false;
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            if (!this.characterParty.ContainsKey(healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (!this.characterParty.ContainsKey(healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            Priest healer = (Priest)this.characterParty.FirstOrDefault(c => c.Key == healerName).Value;

            if (healer.GetType().Name != nameof(Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Character healingReceiver = this.characterParty.FirstOrDefault(c => c.Key == healingReceiverName).Value;

            healer.Heal(healingReceiver);

            return string.Format(SuccessMessages.HealCharacter, healer.Name, healingReceiver.Name, healer.AbilityPoints, healingReceiver.Name, healingReceiver.Health);
        }
    }
}
