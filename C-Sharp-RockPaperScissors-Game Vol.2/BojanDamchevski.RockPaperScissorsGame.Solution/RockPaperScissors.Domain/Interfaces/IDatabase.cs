using RockPaperScissors.Domain.Models;
using System.Collections.Generic;

namespace RockPaperScissors.Domain.Interfaces
{
    public interface IDatabase<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetbyId(int id);
        int Insert(T entity);
        void Update(T entity);
        void RemoveById(int id);
    }
}
