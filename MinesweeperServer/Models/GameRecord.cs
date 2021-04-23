using System;

namespace MinesweeperServer.Models
{
    public class GameRecord
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsWin { get; set; }
        public DateTime Date { get; set; }

        public virtual ApplicationUser Player { get; set; }
        public string PlayerId { get; set; }

        public virtual ComplexityLevel ComplexityLevel { get; set; }
        public int ComplexityLevelId { get; set; }
    }
}
