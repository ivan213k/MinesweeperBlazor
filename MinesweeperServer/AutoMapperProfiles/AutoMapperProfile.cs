using AutoMapper;
using Minesweeper.Shared.Models;
using MinesweeperServer.Models;

namespace MinesweeperServer.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GameRecord, GameRecordModel>().ReverseMap();
        }
    }
}
