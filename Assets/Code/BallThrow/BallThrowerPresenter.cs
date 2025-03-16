using System;
using Code.Click;

namespace Code.BallThrow
{
    public class BallThrowerPresenter : IDisposable
    {
        private BallThrower _ballThrower;
        private ClickControl _clickControl;

        public BallThrowerPresenter(BallThrower ballThrower, ClickControl clickControl)
        {
            _ballThrower = ballThrower;
            _clickControl = clickControl;

            _clickControl.CreateBallButtonClicked += _ballThrower.ThrowBall;
        }

        public void Dispose()
        {
            _clickControl.CreateBallButtonClicked -= _ballThrower.ThrowBall;
        }
    }
}