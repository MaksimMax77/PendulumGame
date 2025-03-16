using System.Collections.Generic;
using UnityEngine;

namespace Code.Pooling
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PoolManagerSettings), fileName = nameof(PoolManagerSettings),
        order = 0)]
    public class PoolManagerSettings : ScriptableObject
    {
        [SerializeField] private List<MonoBehaviour> _prefabs;
        
        public List<MonoBehaviour> Prefabs => _prefabs;
    }
}
