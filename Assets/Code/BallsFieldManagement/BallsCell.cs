using System;
using Code.BallThrow;
using UnityEngine;

namespace Code.BallsFieldManagement
{
    public class BallsCell : MonoBehaviour
    {
        public event Action<int, int> BallColliderEnter;
        public event Action<int, int> BallColliderExit;
        private Ball _attachedBall;
        private int _xPos;
        private int _yPos;

        public Ball AttachedBall => _attachedBall;
        public int XPos => _xPos;
        public int YPos => _yPos;

        public void SetPosition(int x, int y)
        {
            _xPos = x;
            _yPos = y;
        }

        public Ball RestoreBall()
        {
            var returnedBall = _attachedBall;
            _attachedBall = null;
            return returnedBall;
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (_attachedBall != null)
            {
                return;
            }

            var ball = other.gameObject.GetComponent<Ball>();

            if (ball == null)
            {
                return;
            }

            _attachedBall = ball;
            _attachedBall.SetTimer(false);
            BallColliderEnter?.Invoke(_xPos, _yPos);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _attachedBall = null;
            BallColliderExit?.Invoke(_xPos, _yPos);
        }
    }
}