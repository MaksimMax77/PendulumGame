using Code.Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.BallThrow
{
    public class BallThrower
    {
        private GameObject _ballImitator;
        private SpriteRenderer _ballImitatorSpriteRenderer;
        private Color[] _colors;
        private Color _currentBallColor;
        private Pool _ballPool;

        public BallThrower(GameObject ballImitator, BallThrowerSettings settings, PoolsManager poolsManager)
        {
            _ballImitator = ballImitator;
            _colors = settings.Colors;
            _ballPool = poolsManager.GetPool(typeof(Ball));
            _ballImitatorSpriteRenderer = _ballImitator.GetComponent<SpriteRenderer>();
            SetRandomColor();
        }

        public void ThrowBall()
        {
            var ball = _ballPool.Get<Ball>();
            ball.transform.position = _ballImitator.transform.position;
            ball.SetColor(_currentBallColor);
            SetRandomColor();
        }

        private void SetRandomColor()
        {
            _currentBallColor = _colors[Random.Range(0, _colors.Length)];
            _ballImitatorSpriteRenderer.color = _currentBallColor;
        }
    }
}