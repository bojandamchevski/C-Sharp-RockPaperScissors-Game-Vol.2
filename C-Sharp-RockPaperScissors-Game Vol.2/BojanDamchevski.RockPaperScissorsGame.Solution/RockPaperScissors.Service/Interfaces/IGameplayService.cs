using RockPaperScissors.Domain.Models;

namespace RockPaperScissors.Service.Interfaces
{
    public interface IGameplayService
    {
        public int ComputerMove();
        public void Gameplay(int idComputer, int idPlayer);
        public void GameStats();
    }
}
