using UnityEngine;
using Update;

namespace Code.Pendulum
{
    public class PendulumControl : IUpdatable
    {
        private Transform _pivotTransform;
        private float _maxAngleDeflection;
        private float _speedOfPendulum;

        public PendulumControl(Transform pivotTransform, PendulumSettings pendulumSettings)
        {
            _pivotTransform = pivotTransform;
            _maxAngleDeflection = pendulumSettings.MaxAngleDeflection;
            _speedOfPendulum = pendulumSettings.SpeedOfPendulum;
        }

        public void Update()
        {
            var angle = _maxAngleDeflection * Mathf.Sin(Time.time * _speedOfPendulum);
            _pivotTransform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
