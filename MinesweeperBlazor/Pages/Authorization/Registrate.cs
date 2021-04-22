using Microsoft.AspNetCore.Components;
using Minesweeper.Shared.AuthorizationDtos;
using MinesweeperBlazor.Interfaces;
using System.Threading.Tasks;

namespace MinesweeperBlazor.Pages.Authorization
{
    public partial class Registrate
    {
        private UserForRegistrationDto userForRegistration = new UserForRegistrationDto();

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public bool ShowRegistrationError { get; set; }

        public string Error { get; set; }

        public async Task ExecuteRegister()
        {
            var result = await AuthenticationService.RegisterUser(userForRegistration);
            if (!result.IsRegistrationSuccessful)
            {
                Error = result.ErrorMessage;
                ShowRegistrationError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/login");
            }
        }
    }
}
