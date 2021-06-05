using RockPaperScissors.Domain.Models;
using RockPaperScissors.Service.Helpers;
using System;
using System.Collections.Generic;

namespace RockPaperScissors.Service.Services
{
    public class UIService
    {
        public TextGenerator textGenerator { get; set; }
        private GameplayService _gameplayService;
        private GameStatistics _gameStatistics;
        private PlayerService<Player> _playerService;
        public UIService()
        {
            textGenerator = new TextGenerator();
            _gameplayService = new GameplayService();
            _gameStatistics = new GameStatistics();
            _playerService = new PlayerService<Player>();
        }
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                textGenerator.GenerateText("Welcome to the game Rock Paper Scissors !\n\n\n", ConsoleColor.Yellow);
                textGenerator.GenerateText("1.) Play a game", ConsoleColor.Yellow);
                textGenerator.GenerateText("    [Enter 1 to play a game]", ConsoleColor.DarkYellow);
                textGenerator.GenerateText("2.) View stats", ConsoleColor.Yellow);
                textGenerator.GenerateText("    [Enter 2 to view game stats]", ConsoleColor.DarkYellow);
                textGenerator.GenerateText("3.) Exit", ConsoleColor.Yellow);
                textGenerator.GenerateText("    [Enter 3 to exit]", ConsoleColor.DarkYellow);
                bool mainMenuChoiceValidation = int.TryParse(Console.ReadLine(), out int mainMenuChoice);
                if (!mainMenuChoiceValidation)
                {
                    Console.Clear();
                    textGenerator.GenerateText("Bad input, please enter a number.\nPress any key to continue.", ConsoleColor.Red);
                    Console.ReadKey();
                }
                else
                {
                    if (mainMenuChoice == 1)
                    {
                        Console.Clear();
                        textGenerator.GenerateText("1.) Enter existing player Id", ConsoleColor.Yellow);
                        textGenerator.GenerateText("    [Enter player Id you want to play with]", ConsoleColor.DarkYellow);
                        textGenerator.GenerateText("2.) Create a new player profile", ConsoleColor.Yellow);
                        textGenerator.GenerateText("    [Enter 2 to create a new player]", ConsoleColor.DarkYellow);
                        textGenerator.GenerateText("3.) Back to main menu", ConsoleColor.Yellow);
                        textGenerator.GenerateText("    [Enter 3 to go back to the main menu]", ConsoleColor.DarkYellow);
                        bool playGameValidation = int.TryParse(Console.ReadLine(), out int playerChoice);
                        while (true)
                        {
                            if (!playGameValidation)
                            {
                                Console.Clear();
                                textGenerator.GenerateText("Bad input, please enter a number.\nPress any key to continue.", ConsoleColor.Red);
                                Console.ReadKey();
                            }
                            else
                            {
                                if (playerChoice <= 3 && playerChoice >= 1)
                                {
                                    if (playerChoice == 1)
                                    {
                                        Console.Clear();
                                        textGenerator.GenerateText("Players:\n", ConsoleColor.Yellow);
                                        List<Player> players = _playerService.GetAllPlayers();
                                        foreach (Player playerObject in players)
                                        {
                                            textGenerator.GenerateText($"Name: {playerObject.PlayerName} ID: {playerObject.Id}", ConsoleColor.Cyan);
                                        }
                                        textGenerator.GenerateText("\n\n\nEnter your player Id", ConsoleColor.Yellow);
                                        bool idValidation = int.TryParse(Console.ReadLine(), out int id);
                                        Player player = _playerService.GetPlayer(id);
                                        if (player == null)
                                        {
                                            textGenerator.GenerateText("\nPlayer does not exist.", ConsoleColor.Red);
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            int playerId = player.Id;
                                            _gameplayService.Gameplay(playerId);
                                        }
                                        break;
                                    }
                                    else if (playerChoice == 2)
                                    {
                                        Console.Clear();
                                        textGenerator.GenerateText("Welcome to the create new player menu.\n\n\n", ConsoleColor.Yellow);
                                        textGenerator.GenerateText("Type your new player name:\n", ConsoleColor.Yellow);
                                        string playerName = Console.ReadLine();
                                        Player newPlayer = new Player(playerName);
                                        _playerService.AddPlayer(newPlayer);
                                        textGenerator.GenerateText("\n\n\nSuccess, press any key to continue.", ConsoleColor.Green);
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    textGenerator.GenerateText("You must enter between 1 and 2.\nPress any key to continue.", ConsoleColor.Red);
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                    else if (mainMenuChoice == 2)
                    {
                        while (true)
                        {

                            Console.Clear();
                            textGenerator.GenerateText("Players:\n", ConsoleColor.Yellow);
                            List<Player> players = _playerService.GetAllPlayers();
                            foreach (Player playerObject in players)
                            {
                                textGenerator.GenerateText($"Name: {playerObject.PlayerName} ID: {playerObject.Id}", ConsoleColor.Cyan);
                            }
                            textGenerator.GenerateText("\n\nEnter the ID of the player you want to see the statistics.", ConsoleColor.Yellow);
                            textGenerator.GenerateText("Enter the ID:", ConsoleColor.Yellow);
                            bool enterIdValidation = int.TryParse(Console.ReadLine(), out int id);
                            if (!enterIdValidation)
                            {
                                textGenerator.GenerateText("You must enter a number. Press any key to continue.", ConsoleColor.Red);
                                Console.ReadKey();
                            }
                            else
                            {
                                _gameStatistics.GameStats(id);
                                break;
                            }
                        }
                    }
                    else if (mainMenuChoice == 3)
                    {
                        break;
                    }
                }
            }
        }
    }
}
