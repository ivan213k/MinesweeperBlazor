using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Minesweeper_WPF.Core.Core;
using MinesweeperBlazor.Models;
using MinesweeperBlazor.Services;
using System.Collections.Generic;
using System.Linq;

namespace MinesweeperBlazor.Pages
{
    public partial class GameSettingsPage
    {
        private EditContext editContext;
        private List<GameLevel> gameLevels;
        private GameConfiguration customGameSettings;
        private EditForm editForm;

        private bool isSpecialFieldSelected;
        private GameLevel selectedLevel;
        public GameSettingsPage()
        {
            customGameSettings = new GameConfiguration();
        }

        [Inject]
        public IGameLevelsService GameLevelsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(customGameSettings);
            gameLevels = GameLevelsService.GetGameLevels();

            selectedLevel = gameLevels.FirstOrDefault();
        }
        private void OnSelectedLevelChanged(ChangeEventArgs eventArgs, GameLevel level) 
        {
            selectedLevel = level;
            isSpecialFieldSelected = false;
        }
        private void OnSpecialFieldSelected() 
        {
            isSpecialFieldSelected = true;
        }
        private void OnApplyClicked()
        {
            if (isSpecialFieldSelected)
            {
                if (editContext.Validate())
                {
                    GameSesstings.CurrentLevel = "Custom Field";
                    GameSesstings.GameConfiguration = customGameSettings;
                    NavigateToGame();
                }
            }
            else
            {
                GameSesstings.CurrentLevel = selectedLevel.Name;
                GameSesstings.GameConfiguration = selectedLevel.GameConfiguration;
                NavigateToGame();
            }
        }
        private void OnCancelClicked() 
        {
            NavigateToGame();
        }
        private void NavigateToGame()
        {
            NavigationManager.NavigateTo("/game");
        }
    }
}
