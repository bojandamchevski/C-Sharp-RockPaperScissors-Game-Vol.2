using RockPaperScissors.Domain.Database;
using RockPaperScissors.Domain.Models;
using RockPaperScissors.Service.Helpers;
using System;

namespace RockPaperScissors.Service.Services
{
    public class GameStatistics
    {
        public TextGenerator textGenerator { get; set; }
        private Database<Player> _playerDatabase;
        private Database<ComputerPlayer> _computerPlayerDatabase;

        public GameStatistics()
        {
            _playerDatabase = new Database<Player>();
            _computerPlayerDatabase = new Database<ComputerPlayer>();
            textGenerator = new TextGenerator();
        }

        public void GameStats(int id)
        {
            Console.Clear();
            Player player = _playerDatabase.GetbyId(id);
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (player == null)
            {
                textGenerator.GenerateText("\nPlayer does not exist.", ConsoleColor.Red);
            }
            else
            {
                player.GetStatistics();
            }
            textGenerator.GenerateText("\n\nPress any key to continue.", ConsoleColor.Green);
            Console.ReadKey();
        }
    }
}
