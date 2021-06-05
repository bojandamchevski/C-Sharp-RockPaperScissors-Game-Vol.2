using System;

namespace RockPaperScissors.Domain.Models
{
    public class Player : BaseEntity
    {
        public Player(string playerName)
        {
            PlayerName = playerName;
            PlayerStats = new IndividualGameStats();
        }

        public override void GetStatistics()
        {
            Console.WriteLine($"_____________\nPlayer: {PlayerName}\n_____________\nGames played: {PlayerStats.GamesPlayed}\nWins: {PlayerStats.Wins}\nDraws: {PlayerStats.Draws}\nLosses: {PlayerStats.Losses}\n\n\n");
        }
    }
}
