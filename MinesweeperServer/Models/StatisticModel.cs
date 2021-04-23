using System;
using System.Collections.Generic;

namespace MinesweeperServer.Models
{
    public class StatisticModel
    {
        public List<GameRecord> BestGames { get; set; }
        public int TotalGamesCount { get; set; }
        public int WonGamesCount { get; set; }
        public double PercentOfVictories 
        { 
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
