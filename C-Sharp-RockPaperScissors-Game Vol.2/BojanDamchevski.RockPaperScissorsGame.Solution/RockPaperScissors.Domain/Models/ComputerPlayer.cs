using System;

namespace RockPaperScissors.Domain.Models
{
    public class ComputerPlayer : BaseEntity
    {
        public ComputerPlayer()
        {
            PlayerName = "Computer_Player";
            PlayerStats = new IndividualGameStats();
        }

        public override void GetStatistics()
        {
            Console.WriteLine($"_____________\nPlayer: {PlayerName}\n_____________\nGames played: {PlayerStats.GamesPlayed}\nWins: {PlayerStats.Wins}\nDraws: {PlayerStats.Draws}\nLosses: {PlayerStats.Losses}\n\n\n");
        }
    }
}
