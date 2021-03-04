﻿using Minesweeper_WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperBlazor
{
    public class CellToImageConverter
    {
        public string ConvertToImage(Cell cell)
        {
            string imagePath = GetImagePath(cell);

            return imagePath;
        }

        public string GetFlaggedImage()
        {
            string imagePath = @"flaged";
            return imagePath;
        }
        private string GetImagePath(Cell cell)
        {
            if (cell.IsEmpty)
            {
                return @"zero";
            }
            if (cell.IsBomb)
            {
                return @"bombed";
            }
            return $@"num{cell.Number}";
        }
    }
}
