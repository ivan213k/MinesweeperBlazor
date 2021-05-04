using System;
using System.Collections.Generic;

namespace Minesweeper.Shared.Models
{
    public class StatisticModel
    {
        private double percentOfVictories;
        public List<GameRecordModel> BestGames { get; set; }
        public int TotalGamesCount { get; set; }
        public int WonGamesCount { get; set; }
        public double PercentOfVictories
        {
            set => percentOfVictories = value;
            get
            {
                if (TotalGamesCount == 0)
                {
                    return 0;
                }
                return Math.Round((double)WonGamesCount / (double)TotalGamesCount * 100);
            }
        }
    }
}
