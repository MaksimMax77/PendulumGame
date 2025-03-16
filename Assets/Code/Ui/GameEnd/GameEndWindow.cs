using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Ui.GameEnd
{
    public class GameEndWindow : Window
    {
        public event Action RestartButtonClicked;
        public event Action MainMenuButtonClicked;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private TMP_Text _scoresValue;

        public override void Initialize()
        {
            base.Initialize();
            _restartButton.onClick.AddListener(RestartButtonClickedInvoke);
            _mainMenuButton.onClick.AddListener(MainMenuButtonClickedInvoke);
        }

        public void OnScoresModelAdd(int value)
        {
            _scoresValue.text = value.ToString();
        }

        public override void Dispose()
        {
            base.Dispose();
            _restartButton.onClick.RemoveListener(RestartButtonClickedInvoke);
            _mainMenuButton.onClick.RemoveListener(MainMenuButtonClickedInvoke);
        }

        private void RestartButtonClickedInvoke()
        {
            RestartButtonClicked?.Invoke();
        }

        private void MainMenuButtonClickedInvoke()
        {
            MainMenuButtonClicked?.Invoke();
        }
    }
}
