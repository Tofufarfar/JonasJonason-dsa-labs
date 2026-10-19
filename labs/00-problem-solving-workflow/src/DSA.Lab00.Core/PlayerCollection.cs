using System;
using System.Collections.Generic;

namespace DSA.Lab00
{
    public sealed class PlayerCollection
    {
        private readonly List<Player> _players;

        public PlayerCollection(IEnumerable<Player> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            _players = new List<Player>(players);
        }

        public Player? FindById(int id)
        {
            foreach (Player player in _players)
            {
                if (player.Id == id)
                {
                    return player;
                }
            }

            return null;
        }

        public Player? FindHighestScore()
        {
           if(_players.Count == 0) return null;
            Player _highestScore = _players[0];

                foreach(Player player in _players)
                {
                    if(player.Score > _highestScore.Score)
                    {
                        _highestScore = player;
                    }
                }
            return _highestScore;
        }

        public bool ContainsName(string name)
        {
            foreach(Player player in _players)
            {
                if(player.Name == name)
                {
                    return true;
                }
            }
            // Use case-sensitive comparison for this lab.
            return false;
        }
    }
}
