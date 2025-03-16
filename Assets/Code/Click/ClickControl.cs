using System;
using UnityEngine.UI;

namespace Code.Click
{
    public class ClickControl : IDisposable
    {
        public event Action CreateBallButtonClicked;
        private Button _createBallButton;

        public ClickControl(Button createBallButton)
        {
            _createBallButton = createBallButton;
            _createBallButton.onClick.AddListener(CreateBallButtonClickedInvoke);
        }
        
        public void Dispose()
        {
            _createBallButton.onClick.RemoveListener(CreateBallButtonClickedInvoke);
        }

        private void CreateBallButtonClickedInvoke()
        {
            CreateBallButtonClicked?.Invoke();
        }
    }
}