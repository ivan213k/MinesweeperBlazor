using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinesweeperServer.Models;
using MinesweeperServer.Repositories;
using MinesweeperServer.Services.Interfaces;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MinesweeperServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;
        private readonly IRepository<ComplexityLevel> _levelsRepository;

        public StatisticController(IStatisticService statisticService, IRepository<ComplexityLevel> repository)
        {
            _statisticService = statisticService;
            _levelsRepository = repository;
        }

        [HttpGet("{level}")]
        public async Task<StatisticModel> GetStatistic(string level) 
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int levelId = (await _levelsRepository.GetAllAsync()).Where(r => r.Complexity.ToLower() == level.ToLower()).Single().Id;
            var wonGames = await _statisticService.GetWonGamesAsync(userId, levelId);
            var statisticModel = new StatisticModel 
            {
                BestGames = wonGames,
                TotalGamesCount = await _statisticService.GetTotalGamesCountAsync(userId,levelId),
                WonGamesCount = wonGames.Count,
            };
            return statisticModel;
        }

        [HttpPost("{level}")]
        public async Task AddGameRecord(string level, GameRecord gameRecord) 
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int levelId = (await _levelsRepository.GetAllAsync()).Where(r => r.Complexity.ToLower() == level.ToLower()).Single().Id;
            gameRecord.ComplexityLevelId = levelId;
            gameRecord.PlayerId = userId;
            await _statisticService.AddGameRecordAsync(gameRecord);
        }

        [HttpDelete]
        public async Task ResetStatistic() 
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await _statisticService.ResetStatisticAsync(userId);
        }
    }
}
