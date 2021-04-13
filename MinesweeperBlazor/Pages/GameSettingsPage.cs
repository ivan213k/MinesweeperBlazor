using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Minesweeper_WPF.Core.Core;
using MinesweeperBlazor.Models;
using MinesweeperBlazor.Services;
using System.Collections.Generic;

namespace MinesweeperBlazor.Pages
{
    public partial class GameSettingsPage
    {
        private List<GameLevel> gameLevels;
        private GameConfiguration customGameSettings;
        private EditForm editForm;

        private bool isSpecialFieldSelected;

        [Inject]
        public IGameLevelsService GameLevelsService { get; set; }

        protected override void OnInitialized()
        {
            gameLevels = GameLevelsService.GetGameLevels();
            customGameSettings = new GameConfiguration();
        }

        private void OnApplyClicked()
        {
            if (editForm.EditContext.Validate())
            {

            }
        }
    }
}
