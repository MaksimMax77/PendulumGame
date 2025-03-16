using System;
using System.Collections.Generic;

namespace Code.BallsFieldManagement
{
    public class CellsFieldStateChecker : IDisposable
    {
        public event Action<List<BallsCell>> LineCreated;
        public event Action LineFounded; 
        public event Action FieldFilled;
        private BallAddEventInvoker _ballAddEventInvoker;
        private BallsCell[,] _cells;
        private int _xSize;
        private int _ySize;

        public CellsFieldStateChecker(BallAddEventInvoker ballAddEventInvoker,
            BallsCellsField ballsCellsField)
        {
            _ballAddEventInvoker = ballAddEventInvoker;
            _ballAddEventInvoker.BallAdded += OnBallAdded;
            _cells = ballsCellsField.Cells;
            _xSize = _cells.GetLength(0);
            _ySize = _cells.GetLength(1);
        }

        public void Dispose()
        {
            _ballAddEventInvoker.BallAdded -= OnBallAdded;
        }

        private void OnBallAdded(int x, int y)
        {
            if (TryGetHorizontalLine(y, out var line)
                || TryGetVerticalLine(x, out line)
                || CheckDownUpDiagonalLine(out line)
                || CheckUpDownDiagonalLine(out line))
            {
                LineCreated?.Invoke(line);
                LineFounded?.Invoke();
                return;
            }

            if (IsFieldFilled())
            {
                FieldFilled?.Invoke();
            }
        }

        #region Horizontal

        private bool TryGetHorizontalLine(int yPos, out List<BallsCell> line)
        {
            return TryCollectHorizontalLine(yPos, out line) && CheckLine(line);
        }

        private bool TryCollectHorizontalLine(int yPos, out List<BallsCell> line)
        {
            line = new List<BallsCell>();

            for (int x = 0; x < _xSize; x++)
            {
                var cell = _cells[x, yPos];

                if (cell == null)
                {
                    return false;
                }

                line.Add(cell);
            }

            return true;
        }

        #endregion

        #region Vertical

        private bool TryGetVerticalLine(int xPos, out List<BallsCell> line)
        {
            return TryCollectVerticalLine(xPos, out line) && CheckLine(line);
        }

        private bool TryCollectVerticalLine(int xPos, out List<BallsCell> line)
        {
            line = new List<BallsCell>();

            for (int y = 0; y < _ySize; y++)
            {
                var cell = _cells[xPos, y];

                if (cell == null)
                {
                    return false;
                }

                line.Add(cell);
            }

            return true;
        }

        #endregion

        #region DownUpDiagonal

        public bool CheckDownUpDiagonalLine(out List<BallsCell> line)
        {
            return TryCollectDownUpDiagonal(out line) && CheckLine(line);
        }

        private bool TryCollectDownUpDiagonal(out List<BallsCell> line)
        {
            line = new List<BallsCell>();

            for (int i = 0; i < _xSize; i++)
            {
                var ball = _cells[i, i];

                if (ball == null)
                {
                    return false;
                }

                line.Add(ball);
            }

            return true;
        }

        #endregion

        #region UpDownDiagonal

        private bool CheckUpDownDiagonalLine(out List<BallsCell> line)
        {
            return TryCollectUpDownDiagonalLine(out line) && CheckLine(line);
        }

        private bool TryCollectUpDownDiagonalLine(out List<BallsCell> line)
        {
            line = new List<BallsCell>();

            for (int x = 0, y = _ySize - 1; x < _xSize && y >= 0; ++x, --y)
            {
                var ball = _cells[x, y];

                if (ball == null)
                {
                    return false;
                }

                line.Add(ball);
            }

            return true;
        }

        #endregion

        private bool CheckLine(List<BallsCell> line)
        {
            for (int i = 0, count = line.Count; i < count; ++i)
            {
                var next = i + 1;
                if (next == line.Count)
                {
                    break;
                }

                var ball = line[i].AttachedBall;
                var nextBall = line[next].AttachedBall;
                if (nextBall == null || ball == null)
                {
                    return false;
                }

                if (ball.GetColor() != nextBall.GetColor())
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsFieldFilled()
        {
            for (var x = 0; x < _xSize; x++)
            {
                for (var y = 0; y < _ySize; y++)
                {
                    if (_cells[x, y].AttachedBall == null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}