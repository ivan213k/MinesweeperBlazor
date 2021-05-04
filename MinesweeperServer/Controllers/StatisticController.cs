using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minesweeper.Shared.Models;
using MinesweeperServer.Models;
using MinesweeperServer.Repositories;
using MinesweeperServer.Services.Interfaces;
using System;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;

        public StatisticController(IStatisticService statisticService, IRepository<ComplexityLevel> levelsRepository, IMapper mapper)
        {
            _statisticService = statisticService;
            _levelsRepository = levelsRepository;
            _mapper = mapper;
        }

        [HttpGet("{level}")]
        public async Task<StatisticModel> GetStatistic(string level) 
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int levelId = (await _levelsRepository.GetAllAsync()).Where(r => r.Complexity.ToLower() == level.ToLower()).Single().Id;
            var wonGames = await _statisticService.GetWonGamesAsync(userId, levelId);
            var statisticModel = new StatisticModel 
            {
                BestGames = _mapper.Map<List<GameRecordModel>>(wonGames),
                TotalGamesCount = await _statisticService.GetTotalGamesCountAsync(userId,levelId),
                WonGamesCount = wonGames.Count,
            };
            foreach (var game in statisticModel.BestGames)
            {
                game.DurationInSeconds = (int)game.Duration.TotalSeconds;
            }
            return statisticModel;
        }

        [HttpPost("{level}")]
        public async Task AddGameRecord(string level, GameRecordModel gameRecordModel) 
        {
            GameRecord gameRecord = _mapper.Map<GameRecord>(gameRecordModel);
            gameRecord.Duration = TimeSpan.FromSeconds(gameRecordModel.DurationInSeconds);
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
