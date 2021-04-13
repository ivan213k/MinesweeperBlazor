using Minesweeper_WPF.Core.Core;
using MinesweeperBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperBlazor.Services
{
    public class GameLevelService : IGameLevelsService
    {
        public List<GameLevel> GetGameLevels()
        {
            List<GameLevel> defaultGameLevels = new List<GameLevel>()
            {
                new GameLevel{Name = "Beginner", GameConfiguration = new GameConfiguration(9,9,10) },
                new GameLevel{Name = "Intermediate", GameConfiguration = new GameConfiguration(16,16,40) },
                new GameLevel{Name = "Advanced", GameConfiguration = new GameConfiguration(16,30,99) },

            };
            return defaultGameLevels;
        }
    }
}
