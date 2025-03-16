using Code.Pooling;
using UnityEngine;

namespace Code.BallThrow
{
    public class Ball : PoolElementWithLifeTime
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _minMagnitude;
        
        public bool IsStopped =>
            _rigidbody2D.velocity.magnitude <= _minMagnitude;

        public Color GetColor()
        {
            return _spriteRenderer.color;
        }

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }
    }
}