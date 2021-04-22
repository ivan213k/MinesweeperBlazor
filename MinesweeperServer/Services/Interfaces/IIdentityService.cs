using Microsoft.AspNetCore.Identity;
using Minesweeper.Shared.AuthorizationDtos;
using System.Threading.Tasks;

namespace MinesweeperServer.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthResponseDto> AuthorizeAsync(string email, string password);

        Task<(IdentityResult Result, string UserId)> CreateUserAsync(string userName, string password);
    }
}
