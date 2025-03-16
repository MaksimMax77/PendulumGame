using UnityEngine;

namespace Code.Pooling
{
    public class PoolElementWithLifeTime: MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        private float _currentLifeTime;
        private bool _timerEnabled = true;

        public bool TimeToRelease => _currentLifeTime <= 0;

        private void OnEnable()
        {
            SetTimer(true);
        }

        private void OnDisable()
        {
            _timerEnabled = false;
        }

        public void UpdateLifeTime()
        {
            if (!_timerEnabled)
            {
                return;
            }
            _currentLifeTime -= Time.deltaTime;
        }

        public void SetTimer(bool value)
        {
            ResetLifeTime();
            _timerEnabled = value;
        }

        private void ResetLifeTime()
        {
            _currentLifeTime = _lifeTime;
        }
    }
}
