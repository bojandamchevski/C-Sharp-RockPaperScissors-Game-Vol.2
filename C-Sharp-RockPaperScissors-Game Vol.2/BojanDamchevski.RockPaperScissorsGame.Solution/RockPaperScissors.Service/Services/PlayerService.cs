using RockPaperScissors.Domain.Database;
using RockPaperScissors.Domain.Models;
using System.Collections.Generic;

namespace RockPaperScissors.Service.Services
{
    public class PlayerService<T> where T : BaseEntity
    {
        private Database<T> _database;

        public PlayerService()
        {
            _database = new Database<T>();
        }

        public int AddPlayer(T player)
        {
            return _database.Insert(player);
        }

        public T GetPlayer(int id)
        {
            return _database.GetbyId(id);
        }

        public List<T> GetAllPlayers()
        {
            return _database.GetAll();
        }
    }
}
