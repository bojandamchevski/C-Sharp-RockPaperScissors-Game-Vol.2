using RockPaperScissors.Domain.Database;
using RockPaperScissors.Domain.Models;
using RockPaperScissors.Service.Helpers;
using RockPaperScissors.Service.Interfaces;
using System;

namespace RockPaperScissors.Service.Services
{
    public class GameplayService //: IGameplayService
    {
        private Database<ComputerPlayer> _databaseComputer;
        private Database<Player> _databasePlayer;
        public TextGenerator textGenerator { get; set; }
        public GameplayService()
        {
            _databasePlayer = new Database<Player>();
            _databaseComputer = new Database<ComputerPlayer>();
            textGenerator = new TextGenerator();
        }
        public int ComputerMove()
        {
            int computerMove = new Random().Next(1, 3);
            return computerMove;
        }

        public void Gameplay(int id)
        {
            while (true)
            {
                Console.Clear();
                Player player = _databasePlayer.GetbyId(id);
                ComputerPlayer computerPlayer = _databaseComputer.GetbyId(1);
                textGenerator.GenerateText("Choose a move:\n\n", ConsoleColor.Yellow);
                textGenerator.GenerateText("1.) Rock        2.) Paper        3.) Scissors                          4.) Back to main menu", ConsoleColor.Yellow);
                textGenerator.GenerateText("Enter move:", ConsoleColor.DarkYellow);
                bool moveValidation = int.TryParse(Console.ReadLine(), out int move);
                if (!moveValidation)
                {

                    Console.Clear();
                    textGenerator.GenerateText("Invalid input, try again.\nPress any key to try again.", ConsoleColor.Red);
                    Console.ReadKey();
                }
                else
                {
                    int computerMove = ComputerMove();
                    if ((move == 1 && computerMove == 1) || (move == 2 && computerMove == 2) || (move == 3 && computerMove == 3))
                    {
                        player.PlayerStats.GamesPlayed++;
                        player.PlayerStats.Draws++;
                        computerPlayer.PlayerStats.GamesPlayed++;
                        computerPlayer.PlayerStats.Draws++;
                        _databaseComputer.Update(computerPlayer);
                        _databasePlayer.Update(player);
                        textGenerator.GenerateText("It's a draw.", ConsoleColor.DarkGray);
                        textGenerator.GenerateText("\n\nPress any key to continue.", ConsoleColor.Green);
                        Console.ReadKey();
                    }
                    else if ((move == 1 && computerMove == 3) || (move == 2 && computerMove == 1) || (move == 3 && computerMove == 2))
                    {
                        player.PlayerStats.GamesPlayed++;
                        player.PlayerStats.Wins++;
                        computerPlayer.PlayerStats.GamesPlayed++;
                        computerPlayer.PlayerStats.Losses++;
                        _databaseComputer.Update(computerPlayer);
                        _databasePlayer.Update(player);
                        textGenerator.GenerateText("You win !!!", ConsoleColor.Green);
                        textGenerator.GenerateText("\n\nPress any key to continue.", ConsoleColor.Green);
                        Console.ReadKey();
                    }
                    else if ((move == 3 && computerMove == 1) || (move == 1 && computerMove == 2) || (move == 2 && computerMove == 3))
                    {
                        player.PlayerStats.GamesPlayed++;
                        player.PlayerStats.Losses++;
                        computerPlayer.PlayerStats.GamesPlayed++;
                        computerPlayer.PlayerStats.Wins++;
                        _databaseComputer.Update(computerPlayer);
                        _databasePlayer.Update(player);
                        textGenerator.GenerateText("The computer won...", ConsoleColor.Blue);
                        textGenerator.GenerateText("\n\nPress any key to continue.", ConsoleColor.Green);
                        Console.ReadKey();
                    }
                    else if (move == 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        textGenerator.GenerateText("Invalid move (Must be between 1 and 3). Try again !\nPress any key to try again", ConsoleColor.Red);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
