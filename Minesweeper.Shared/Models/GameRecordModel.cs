using System;

namespace Minesweeper.Shared.Models
{
    public class GameRecordModel
    {
        public TimeSpan Duration { get; set; }
        public int DurationInSeconds { get; set; }
        public bool IsWin { get; set; }
        public DateTime Date { get; set; }
    }
}
