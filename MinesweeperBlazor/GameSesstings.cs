using Minesweeper_WPF.Core.Core;

namespace MinesweeperBlazor
{
    public static class GameSesstings
    {
        public static string CurrentLevel { get; set; } = "Beginner";
        public static GameConfiguration GameConfiguration { get; set; } = new GameConfiguration();     
    }
}
