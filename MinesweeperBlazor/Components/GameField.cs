using Microsoft.AspNetCore.Components;
using Minesweeper_WPF.Core.Core;

namespace MinesweeperBlazor.Components
{
    public partial class GameField
    {      
        [Parameter]
        public int RowsCount { get; set; }

        [Parameter]
        public int ColumnsCount { get; set; }

        [Parameter]
        public int BombsCount { get; set; }

        private Cell[,] cells;
        private GameBar gameBar;
        private ModalDialog modalDialog;

        private CellToImageConverter CellToImageConverter = new CellToImageConverter();
        protected override void OnParametersSet()
        {
            cells = new Cell[RowsCount, ColumnsCount];
        }

        private void OpenCell(Point point)
        {
            if (CellIsFlaged(cells[point.X, point.Y]))
            {
                RemoveFlagedMark(point);
            }
            if (CellIsClosed(cells[point.X, point.Y]))
            {
                var cellsToOpen = GameCore.OpenCell(point);
                foreach (var cell in cellsToOpen)
                {
                    cells[cell.RowIndex, cell.ColumnIndex].SetNewValue(CellToImageConverter.ConvertToImage(cell));
                }
            }   
        }

        private void MarkCellAsBomb(Point point)
        {
            if (CellIsFlaged(cells[point.X, point.Y]))
            {
                RemoveFlagedMark(point);
            }
            if(CellIsClosed(cells[point.X, point.Y]))
            {
                GameCore.MarkCellAsBomb(point);
                cells[point.X, point.Y].SetNewValue(CellToImageConverter.GetFlaggedImage());
                gameBar.DecrementBombsCount();
            }
        }
        private void RemoveFlagedMark(Point point) 
        {
            cells[point.X, point.Y].SetNewValue("closed");
            GameCore.RemoveBombMark(point);
            gameBar.IncrementBombsCount();
        }
        protected override void OnInitialized()
        {
            GameCore.OnGameOver += GameCore_OnGameOver;
            GameCore.OnGameWin += GameCore_OnGameWin;
        }

        private void GameCore_OnGameWin()
        {
            gameBar.StopTimer();
            modalDialog.Show("You won!");
        }

        private void GameCore_OnGameOver(Minesweeper_WPF.Core.Cell bombedCell)
        {
            cells[bombedCell.RowIndex, bombedCell.ColumnIndex].SetNewValue(CellToImageConverter.ConvertToImage(bombedCell));
            gameBar.StopTimer();
            modalDialog.Show("You lost this game!");
        }

        private void StartNewGame()
        {
            CloseAllCells();
            gameBar.SetBombsCount(BombsCount);
            gameBar.StartTimer();
            GameCore.StartNewGame();
        }

        private void CloseAllCells()
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    cells[i, j].SetNewValue("closed");
                }
            }
        }

        private bool CellIsFlaged(Cell cell)
        {
            return cell.Value == "flaged";
        }

        private bool CellIsClosed(Cell cell)
        {
            return cell.Value == "closed";
        }
    }
}
