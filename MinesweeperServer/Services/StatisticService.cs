using MinesweeperServer.Models;
using MinesweeperServer.Repositories;
using MinesweeperServer.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperServer.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository<GameRecord> _gamesRepository;

        public StatisticService(IRepository<GameRecord> gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task AddGameRecordAsync(GameRecord gameRecord)
        {
            await _gamesRepository.CreateAsync(gameRecord);
        }

        public async Task<int> GetTotalGamesCountAsync(string userId, int levelId)
        {
            return (await _gamesRepository.GetAllAsync()).Where(r => r.PlayerId == userId && r.ComplexityLevelId == levelId).Count();
        }

        public async Task<List<GameRecord>> GetWonGamesAsync(string userId, int levelId)
        {
            return (await _gamesRepository.GetAllAsync()).Where(r => r.PlayerId == userId && r.ComplexityLevelId == levelId && r.IsWin).ToList();
        }

        public async Task ResetStatisticAsync(string userId)
        {
            var games = (await _gamesRepository.GetAllAsync()).Where(r => r.PlayerId == userId).ToList();
            foreach (var game in games)
            {
                await _gamesRepository.DeleteAsync(game);
            }
        }
    }
}
