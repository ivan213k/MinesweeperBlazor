using Minesweeper_WPF.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperBlazor.Models
{
    public class GameLevel
    {
        public string Name { get; set; }

        public GameConfiguration GameConfiguration { get; set; }
    }
}
