using UnityEngine;

namespace Code.Pooling
{
    public class PoolSibling
    {
        private Transform _enabledParent;
        private Transform _disabledParent;

        public Transform EnabledParent => _enabledParent;
        public Transform DisabledParent => _disabledParent;

        public void Create(string poolName)
        {
            var root = new GameObject(poolName);
            var enabled = new GameObject(poolName + "_Enabled");
            var disabled = new GameObject(poolName + "_Disabled");
            enabled.transform.SetParent(root.transform);
            disabled.transform.SetParent(root.transform);
            _enabledParent = enabled.transform;
            _disabledParent = disabled.transform;
        }
    }
}