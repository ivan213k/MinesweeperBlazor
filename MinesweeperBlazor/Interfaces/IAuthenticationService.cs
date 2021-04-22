using Minesweeper.Shared.AuthorizationDtos;
using System.Threading.Tasks;

namespace MinesweeperBlazor.Interfaces
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);
        Task Logout();
    }
}
