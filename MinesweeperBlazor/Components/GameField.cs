using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Minesweeper_WPF.Core.Core;

namespace MinesweeperBlazor.Components
{
    public partial class GameField
    {
        [Parameter]
        public int RowsCount { get; set; }

        [Parameter]
        public int ColumnsCount { get; set; }

        private Cell[,] cells;

        private CellToImageConverter CellToImageConverter = new CellToImageConverter();
        protected override void OnParametersSet()
        {
            cells = new Cell[RowsCount, ColumnsCount];
        }

        private void OpenCell(Point point)
        {
            var cellsToOpen = GameCore.OpenCell(point);
            foreach (var cell in cellsToOpen)
            {
                cells[cell.RowIndex, cell.ColumnIndex].SetNewValue(CellToImageConverter.ConvertToImage(cell));
            }
        }

        private void MarkCellAsBomb(Point point)
        {
            if (cells[point.X, point.Y].Value == "flaged")
            {
                cells[point.X, point.Y].SetNewValue("closed");
                GameCore.RemoveBombMark(point);
            }
            else
            {
                GameCore.MarkCellAsBomb(point);
                cells[point.X, point.Y].SetNewValue(CellToImageConverter.GetFlaggedImage());
            }
        }

        protected override void OnInitialized()
        {
            GameCore.OnGameOver += GameCore_OnGameOver;
            GameCore.OnGameWin += GameCore_OnGameWin;
        }

        private void GameCore_OnGameWin()
        {
            JsRuntime.InvokeVoidAsync("alert", "Game win!");
        }

        private void GameCore_OnGameOver(Minesweeper_WPF.Core.Cell bombedCell)
        {
            JsRuntime.InvokeVoidAsync("alert", "Game over!");
            cells[bombedCell.RowIndex, bombedCell.ColumnIndex].SetNewValue(CellToImageConverter.ConvertToImage(bombedCell));
        }
    }
}
