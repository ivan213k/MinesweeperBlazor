using MinesweeperBlazor.Models;
using System.Collections.Generic;

namespace MinesweeperBlazor.Services
{
    public interface IGameLevelsService
    {
        List<GameLevel> GetGameLevels();
    }
}
