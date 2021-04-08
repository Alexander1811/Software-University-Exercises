namespace Players_and_Monsters.Core
{
    using System.Text;
    using Contracts;
    using Players_and_Monsters.Common;
    using Players_and_Monsters.Core.Factories;
    using Players_and_Monsters.Core.Factories.Contracts;
    using Players_and_Monsters.Models.BattleFields;
    using Players_and_Monsters.Models.BattleFields.Contracts;
    using Players_and_Monsters.Models.Cards.Contracts;
    using Players_and_Monsters.Models.Players.Contracts;
    using Players_and_Monsters.Repositories;
    using Players_and_Monsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IBattleField battleField;

        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            this.playerRepository.Add(this.playerFactory.CreatePlayer(type, username));

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            this.cardRepository.Add(this.cardFactory.CreateCard(type, name));

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string userName, string cardName)
        {
            IPlayer player = this.playerRepository.Find(userName);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, userName);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IPlayer player in this.playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                foreach (ICard card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                sb.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }

            return sb.ToString().Trim();
        }
    }
}
