namespace RockPaperScissors.Domain.Models
{
    public class IndividualGameStats
    {
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public IndividualGameStats()
        {

        }
    }
}
