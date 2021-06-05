using RockPaperScissors.Domain.Models;
using RockPaperScissors.Service.Services;
using System;

namespace RockPaperScissors.App
{
    class Program
    {
        public static UIService _uiService = new UIService();
        public static PlayerService<Player> _PlayerService = new PlayerService<Player>();
        public static PlayerService<ComputerPlayer> _ComputerService = new PlayerService<ComputerPlayer>();
        static void Main(string[] args)
        {
            //Player player = new Player("Player1");
            //_PlayerService.AddPlayer(player);
            //_ComputerService.AddPlayer(new ComputerPlayer());
            _uiService.MainMenu();
        }
    }
}
