using System;
using System.Collections.Generic;
using Update;

namespace Code.Pooling
{
    public class PoolsManager : IUpdatable
    {
        private List<Pool> _pools = new();

        public PoolsManager(PoolManagerSettings poolManagerSettings)
        {
            for (int i = 0, len = poolManagerSettings.Prefabs.Count; i < len; i++)
            {
                var pool = new Pool(poolManagerSettings.Prefabs[i]);
                _pools.Add(pool);
            }
        }

        public Pool GetPool(Type type)
        {
            for (int i = 0, len = _pools.Count; i < len; i++)
            {
                var pool = _pools[i];
                var prefabType = pool.Prefab.GetType();
                if (prefabType == type)
                {
                    return pool;
                }
            }

            return null;
        }

        public void Update()
        {
            for (int i = 0, len = _pools.Count; i < len; i++)
            {
                var pool = _pools[i];
                pool.UpdateElementsLifeTime();
            }
        }
    }
}