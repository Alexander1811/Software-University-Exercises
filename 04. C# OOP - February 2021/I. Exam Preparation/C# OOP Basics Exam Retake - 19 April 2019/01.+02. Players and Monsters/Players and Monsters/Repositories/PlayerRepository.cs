using System;
using System.Collections.Generic;
using System.Linq;
using Players_and_Monsters.Common;
using Players_and_Monsters.Models.Players.Contracts;
using Players_and_Monsters.Repositories.Contracts;

namespace Players_and_Monsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> players;

        public PlayerRepository()
        {
            this.players = new Dictionary<string, IPlayer>();
        }

        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.Values.ToList();

        public void Add(IPlayer player)
        {
            Validator.ThrowIfObjectIsNull(player, ExceptionMessages.PlayerIsNull);

            if (players.ContainsKey(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player.Username, player);
        }
        public bool Remove(IPlayer player)
        {
            Validator.ThrowIfObjectIsNull(player, ExceptionMessages.PlayerIsNull);

            bool isRemoved = this.players.Remove(player.Username);

            return isRemoved;
        }

        public IPlayer Find(string username)
        {
            IPlayer player = players.Where(p => p.Key == username).FirstOrDefault().Value;

            return player;
        }
    }
}
