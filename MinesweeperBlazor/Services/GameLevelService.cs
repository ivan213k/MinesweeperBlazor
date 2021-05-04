using Minesweeper_WPF.Core.Core;
using MinesweeperBlazor.Models;
using System.Collections.Generic;

namespace MinesweeperBlazor.Services
{
    public class GameLevelService : IGameLevelsService
    {
        public List<GameLevel> GetGameLevels()
        {
            List<GameLevel> defaultGameLevels = new List<GameLevel>()
            {
                new GameLevel{Name = "Beginner", GameConfiguration = new GameConfiguration(9,9,10) },
                new GameLevel{Name = "Intermediate", GameConfiguration = new GameConfiguration(16,14,40) },
                new GameLevel{Name = "Advanced", GameConfiguration = new GameConfiguration(30,14,99) },
                new GameLevel{Name = "Custom Field" }
            };
            return defaultGameLevels;
        }
    }
}
