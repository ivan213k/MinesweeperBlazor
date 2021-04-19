using Minesweeper_WPF.Core.Core;

namespace MinesweeperBlazor.Pages
{
    public partial class Game
    {
        private GameConfiguration gameConfiguration;
        protected override void OnInitialized()
        {
            gameConfiguration = GameSesstings.GameConfiguration;
        }
    }
}
