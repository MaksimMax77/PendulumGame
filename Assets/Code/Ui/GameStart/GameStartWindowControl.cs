using System;
using Code.Ui.GameEnd;

namespace Code.Ui.GameStart
{
    public class GameStartWindowControl : IDisposable
    { 
        private GameStartWindow _gameStartWindow;
        private GameEndWindowControl _gameEndWindowControl;
        private bool _windowShowedOnStar;

        public GameStartWindowControl(GameStartWindow gameStartWindow, GameEndWindowControl gameEndWindowControl)
        {
            _gameStartWindow = gameStartWindow;
            _gameEndWindowControl = gameEndWindowControl;
            _gameStartWindow.StartGameButtonClicked += OnStartGameButtonClicked;
            _gameEndWindowControl.MainMenuClicked += OnMainMenuClicked;
            _gameStartWindow.Open();
        }

        public void Dispose()
        {
            _gameStartWindow.StartGameButtonClicked += OnStartGameButtonClicked;
            _gameEndWindowControl.MainMenuClicked += OnMainMenuClicked;
        }

        private void OnStartGameButtonClicked()
        {
            _gameStartWindow.Close();
        }

        private void OnMainMenuClicked()
        {
            _gameStartWindow.Open();
        }
    }
}
