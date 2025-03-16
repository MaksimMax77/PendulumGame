using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Ui.GameStart
{
    public class GameStartWindow : Window
    {
        public event Action StartGameButtonClicked;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _quitGameButton;
        
        public override void Initialize()
        {
            base.Initialize();
            _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
            _quitGameButton.onClick.AddListener(OnQuitGameButtonClicked);
            Open();
        }

        public override void Dispose()
        {
            base.Dispose();
            _startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
            _quitGameButton.onClick.RemoveListener(OnQuitGameButtonClicked);
        }

        private void OnStartGameButtonClicked()
        {
            StartGameButtonClicked?.Invoke();
        }

        private void OnQuitGameButtonClicked()
        {
            Application.Quit();
        }
    }
}
