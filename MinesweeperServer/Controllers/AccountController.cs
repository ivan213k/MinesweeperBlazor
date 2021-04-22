using Microsoft.AspNetCore.Mvc;
using Minesweeper.Shared.AuthorizationDtos;
using MinesweeperServer.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForAuthenticationDto userForAuthentication)
        {
            var authResult = await _identityService.AuthorizeAsync(userForAuthentication.Email, userForAuthentication.Password);
            if (authResult.IsAuthSuccessful)
            {
                return Ok(authResult);
            }
            return Unauthorized(authResult);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegistrationDto userForRegistrationDto)
        {
            var registrationResult = await _identityService.CreateUserAsync(userForRegistrationDto.Email, userForRegistrationDto.Password);
            if (registrationResult.Result.Succeeded)
            {
                return Ok(new RegistrationResponseDto {IsRegistrationSuccessful = true, UserId = registrationResult.UserId});
            }
            return BadRequest(new RegistrationResponseDto {ErrorMessage = registrationResult.Result.Errors.FirstOrDefault().Description });
        }
    }
}
