using System;
using Code.BallsFieldManagement;
using Code.Restart;

namespace Code.Ui.GameEnd
{
    public class GameEndWindowControl : IDisposable
    {
        public event Action MainMenuClicked; 
        private GameEndWindow _gameEndWindow;
        private CellsFieldStateChecker _cellsFieldStateChecker;
        private GameRestart _gameRestart;

        public GameEndWindowControl(GameEndWindow window,
            CellsFieldStateChecker cellsFieldStateChecker, GameRestart gameRestart)
        {
            _gameEndWindow = window;
            _cellsFieldStateChecker = cellsFieldStateChecker;
            _gameRestart = gameRestart;
            _cellsFieldStateChecker.FieldFilled += OnFieldFilled;
            _gameEndWindow.RestartButtonClicked += OnRestartButtonClicked;
            _gameEndWindow.MainMenuButtonClicked += OnMainMenuButtonClicked;
        }

        public void Dispose()
        {
            _cellsFieldStateChecker.FieldFilled -= OnFieldFilled;
            _gameEndWindow.RestartButtonClicked -= OnRestartButtonClicked;
            _gameEndWindow.MainMenuButtonClicked -= OnMainMenuButtonClicked;
        }
        
        private void OnFieldFilled()
        {
            _gameEndWindow.Open();
        }

        private void OnRestartButtonClicked()
        {
            _gameRestart.Restart();
            _gameEndWindow.Close();
        }

        private void OnMainMenuButtonClicked()
        {
            _gameRestart.Restart();
            _gameEndWindow.Close(); 
            MainMenuClicked?.Invoke();
        }
    }
}