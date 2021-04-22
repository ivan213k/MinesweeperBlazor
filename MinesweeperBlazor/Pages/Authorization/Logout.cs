using Microsoft.AspNetCore.Components;
using MinesweeperBlazor.Interfaces;
using System.Threading.Tasks;

namespace MinesweeperBlazor.Pages.Authorization
{
    public partial class Logout
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await AuthenticationService.Logout();
            NavigationManager.NavigateTo("/");
        }
    }
}
