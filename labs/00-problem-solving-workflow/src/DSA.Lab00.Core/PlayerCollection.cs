using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DSA.Lab00
{
    public sealed class PlayerCollection
    {
        private readonly List<Player> _players;

        public PlayerCollection(IEnumerable<Player>? players = null)
        {
            if (players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            _players = new List<Player>(players);
        }

        public Player? FindById(int id)
        {
            int count = 0;
            foreach (Player player in _players)
            {
                count++;
                Console.WriteLine(count);
                if (player.Id == id)
                {
                    return player;
                }
            }

            return null;
        }

        public Player? FindHighestScore()
        {
            if (_players.Count == 0)
                return null;
            Player highestScorer = _players[0];

            for (int i = 1; i < _players.Count; i++)
            {
                if (_players[i].Score > highestScorer.Score)
                {
                    highestScorer = _players[i];   
                }
            }
            return highestScorer;
        }

        public bool ContainsName(string name)
        {
            foreach (Player player in _players)
            {
                if (player.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
            }
            // Use case-sensitive comparison for this lab.
            return false;
        }
    }
}
