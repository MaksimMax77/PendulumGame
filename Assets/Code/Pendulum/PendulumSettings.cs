using UnityEngine;

namespace Code.Pendulum
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PendulumSettings), fileName = nameof(PendulumSettings), order = 0)]
    public class PendulumSettings : ScriptableObject
    {
        [SerializeField] private float _maxAngleDeflection = 30.0f;
        [SerializeField] private float _speedOfPendulum = 1.0f;
        
        public float MaxAngleDeflection => _maxAngleDeflection;
        public float SpeedOfPendulum => _speedOfPendulum;
    }
}
