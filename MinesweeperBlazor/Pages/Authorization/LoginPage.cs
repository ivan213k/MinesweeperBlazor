using Microsoft.AspNetCore.Components;
using Minesweeper.Shared.AuthorizationDtos;
using MinesweeperBlazor.Interfaces;
using System.Threading.Tasks;

namespace MinesweeperBlazor.Pages.Authorization
{
    public partial class LoginPage
    {
        private UserForAuthenticationDto userForAuthentication = new UserForAuthenticationDto();
       
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        public bool ShowAuthError { get; set; }
       
        public string Error { get; set; }
       
        public async Task ExecuteLogin()
        {
            var result = await AuthenticationService.Login(userForAuthentication);
            if (!result.IsAuthSuccessful)
            {
                Error = result.ErrorMessage;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
