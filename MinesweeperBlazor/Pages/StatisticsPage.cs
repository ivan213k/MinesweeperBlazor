using Microsoft.AspNetCore.Components;
using Minesweeper.Shared.Models;
using MinesweeperBlazor.Components;
using MinesweeperBlazor.Models;
using MinesweeperBlazor.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MinesweeperBlazor.Pages
{
    public partial class StatisticsPage
    {
        private List<GameLevel> gameLevels;
        private string selectedLevel;
        private StatisticModel currentLevelStatistic;
        private ModalDialog modalDialog;

        [Inject]
        public IGameLevelsService GameLevelsService { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            gameLevels = GameLevelsService.GetGameLevels();
            selectedLevel = gameLevels.First().Name;
            var response = await HttpClient.GetAsync($"api/statistic/{selectedLevel}");
            if (response.IsSuccessStatusCode)
            {
                currentLevelStatistic = await response.Content.ReadFromJsonAsync<StatisticModel>();
                currentLevelStatistic.BestGames = currentLevelStatistic.BestGames.OrderBy(r => r.DurationInSeconds).ToList();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                NavigationManager.NavigateTo("/login/statistics");
            }
        }

        private async void OnSelectionChanged(ChangeEventArgs eventArgs) 
        {
            selectedLevel = eventArgs.Value.ToString();
            currentLevelStatistic = await HttpClient.GetFromJsonAsync<StatisticModel>($"api/statistic/{selectedLevel}");
            currentLevelStatistic.BestGames = currentLevelStatistic.BestGames.OrderBy(r => r.DurationInSeconds).ToList();
            StateHasChanged();
        }
        private void NavigateToGame() 
        {
            NavigationManager.NavigateTo("/game");
        }
        private void OnResetClicked() 
        {
            modalDialog.Show("Actually reset statistic ?");
        }
        private async void ResetStatistic() 
        {
            await HttpClient.DeleteAsync("api/statistic");
            currentLevelStatistic = await HttpClient.GetFromJsonAsync<StatisticModel>($"api/statistic/{selectedLevel}");
            StateHasChanged();
        }
    }
}
