using System;
using Code.BallsFieldManagement;
using Code.Restart;

namespace Code.Scores
{
    public class ScoresModel : IDisposable, IRestartable
    {
        public event Action<int> ScoresUpdated;
        private readonly CellsFieldStateChecker _cellsFieldStateChecker;
        private readonly int _addingValue;
        private int _scores;

        public ScoresModel(CellsFieldStateChecker cellsFieldStateChecker, ScoresSettings settings)
        {
            _cellsFieldStateChecker = cellsFieldStateChecker;
            _addingValue = settings.ScoresAddingValue;
            _cellsFieldStateChecker.LineFounded += AddScores;
        }

        public void Dispose()
        {
            _cellsFieldStateChecker.LineFounded -= AddScores;
        }

        private void AddScores()
        {
            _scores += _addingValue;
            ScoresUpdated?.Invoke(_scores);
        }

        public void Restart()
        {
            _scores = 0;
            ScoresUpdated?.Invoke(_scores);
        }
    }
}