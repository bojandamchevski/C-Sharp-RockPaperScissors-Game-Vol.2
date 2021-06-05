using RockPaperScissors.Domain.Interfaces;

namespace RockPaperScissors.Domain.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id;
        public string PlayerName { get; set; }
        public IndividualGameStats PlayerStats { get; set; }
        public abstract void GetStatistics();
    }
}
