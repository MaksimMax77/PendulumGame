using System;
using Code.Ui.GameEnd;

namespace Code.Scores
{
    public class ScoresPresenter : IDisposable
    {
        private ScoresModel _scoresModel;
        private GameEndWindow _gameEndWindow;

        public ScoresPresenter(ScoresModel scoresModel, GameEndWindow gameEndWindow)
        {
            _scoresModel = scoresModel;
            _gameEndWindow = gameEndWindow;
            _scoresModel.ScoresUpdated += _gameEndWindow.OnScoresModelAdd;
        }

        public void Dispose()
        {
            _scoresModel.ScoresUpdated -= _gameEndWindow.OnScoresModelAdd;
        }
    }
}