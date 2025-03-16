using System;
using System.Collections.Generic;
using Update;

namespace Code.BallsFieldManagement
{
    /// <summary>
    /// Это класс нужен, чтоб событие добавления шара вызывалось,
    /// когда мяч остановился, чтоб было возможно удобным образом
    /// подать индексы ячеек в параметры события BallAdded,
    /// для удобного определения позиции ячейки, куда упал мяч
    /// </summary>
    public class BallAddEventInvoker : IUpdatable, IDisposable
    {
        public event Action<int, int> BallAdded;
        private BallsCell[,] _cells;
        private List<BallsCell> _cellsMarketedToAddBall = new();

        public BallAddEventInvoker(BallsCellsField ballsCellsField)
        {
            _cells = ballsCellsField.Cells;
            var xSize = _cells.GetLength(0);
            var ySize = _cells.GetLength(1);

            for (var x = 0; x < xSize; x++)
            {
                for (var y = 0; y < ySize; y++)
                {
                    var cell = _cells[x, y];

                    cell.BallColliderEnter += AddCellToDirtyList;
                    cell.BallColliderExit += RemoveCellFromDirtyList;
                }
            }
        }

        public void Dispose()
        {
            var xSize = _cells.GetLength(0);
            var ySize = _cells.GetLength(1);

            for (var x = 0; x < xSize; x++)
            {
                for (var y = 0; y < ySize; y++)
                {
                    var cell = _cells[x, y];

                    cell.BallColliderEnter += AddCellToDirtyList;
                    cell.BallColliderExit += RemoveCellFromDirtyList;
                }
            }
        }

        private void AddCellToDirtyList(int x, int y)
        {
            _cellsMarketedToAddBall.Add(_cells[x, y]);
        }

        private void RemoveCellFromDirtyList(int x, int y)
        {
            _cellsMarketedToAddBall.Remove(_cells[x, y]);
        }


        public void Update()
        {
            if (_cellsMarketedToAddBall.Count == 0)
            {
                return;
            }

            for (var i = 0; i < _cellsMarketedToAddBall.Count; i++)
            {
                var cell = _cellsMarketedToAddBall[i];
                var ball = cell.AttachedBall;

                if (!ball.IsStopped)
                {
                    continue;
                }

                BallAdded?.Invoke(cell.XPos, cell.YPos);
                _cellsMarketedToAddBall.Remove(cell);
            }
        }
    }
}