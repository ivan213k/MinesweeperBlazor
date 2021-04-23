using MinesweeperServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinesweeperServer.Services.Interfaces
{
    public interface IStatisticService
    {
        Task AddGameRecordAsync(GameRecord gameRecord);
        Task<List<GameRecord>> GetWonGamesAsync(string userId, int levelId);
        Task<int> GetTotalGamesCountAsync(string userId, int levelId);
        Task ResetStatisticAsync(string userId);
    }
}
