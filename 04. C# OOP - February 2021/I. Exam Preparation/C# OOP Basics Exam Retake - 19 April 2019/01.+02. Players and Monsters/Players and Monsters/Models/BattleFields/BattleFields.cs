namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;

    using Common;
    using Contracts;
    using Cards.Contracts;
    using Players;
    using Players.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.PlayerIsDead);
            }

            if (attackPlayer is Beginner)
            {
                this.BoostPlayer(attackPlayer);
            }
            if (enemyPlayer is Beginner)
            {
                this.BoostPlayer(enemyPlayer);
            }

            attackPlayer.Health += this.GetBonusHealthPoints(attackPlayer);
            enemyPlayer.Health += this.GetBonusHealthPoints(enemyPlayer);

            int attackerDamage = this.GetDamagePoints(attackPlayer);
            int enemyDamage = this.GetDamagePoints(enemyPlayer);

            while (true)
            {
                enemyPlayer.TakeDamage(attackerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private int GetDamagePoints(IPlayer player)
        {
            return player.CardRepository.Cards.Sum(card => card.DamagePoints);
        }
        private int GetBonusHealthPoints(IPlayer player)
        {
            return player.CardRepository.Cards.Sum(card => card.HealthPoints);
        }

        private void BoostPlayer(IPlayer player)
        {
            player.Health += 40;

            foreach (ICard card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
