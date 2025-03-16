using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Code.Pooling
{
    public class Pool 
    {
        private MonoBehaviour _prefab;
        private PoolSibling _poolSibling;
        private ObjectPool<MonoBehaviour> _pool;
        private List<MonoBehaviour> _enabledObjs = new();
        private List<PoolElementWithLifeTime> _elementsWithLifeTime = new();
        
        public Object Prefab => _prefab;
        
        public Pool(MonoBehaviour prefab)
        {
            _prefab = prefab;
            _poolSibling = new PoolSibling();
            _poolSibling.Create(_prefab.name + "_Pool");

            _pool = new ObjectPool<MonoBehaviour>(() => Object.Instantiate(_prefab),
                OnGet,
                OnRelease,
                Object.Destroy,
                false);
        }
        
        private void OnGet(MonoBehaviour item)
        {
            item.gameObject.SetActive(true);
            item.gameObject.transform.SetParent(_poolSibling.EnabledParent);
            
            if (item is not PoolElementWithLifeTime elementWithLifeTime)
            {
                return;
            }
            elementWithLifeTime.SetTimer(true);
        }

        private void OnRelease(MonoBehaviour item)
        {
            item.gameObject.SetActive(false);
            item.gameObject.transform.SetParent(_poolSibling.DisabledParent);
            
            if (item is not PoolElementWithLifeTime elementWithLifeTime)
            {
                return;
            }
            elementWithLifeTime.SetTimer(false);
        }
        
        public T Get<T>() where T: MonoBehaviour
        {
            var item = _pool.Get();
            TryAddElementWithLifeTime(item);
            _enabledObjs.Add(item);
            return (T)item;
        }

        private void TryAddElementWithLifeTime(MonoBehaviour obj)
        {
            if (obj is not PoolElementWithLifeTime elementWithLifeTime)
            {
                return;
            }
            _elementsWithLifeTime.Add(elementWithLifeTime);
        }

        public void UpdateElementsLifeTime()
        {
            for (int i = 0, len = _elementsWithLifeTime.Count; i < len; i++)
            {
                var elementWithLifeTime = _elementsWithLifeTime[i];

                if (!elementWithLifeTime.isActiveAndEnabled)
                {
                    return;
                }
                
                elementWithLifeTime.UpdateLifeTime();

                if (elementWithLifeTime.TimeToRelease)
                {
                    Release(elementWithLifeTime);
                }
            }
        }
        
        public void Release(MonoBehaviour item)
        {
            _enabledObjs.Remove(item);
            _pool.Release(item);
        }
        
        public void ReleaseAll()
        {
            for (int i = 0, len = _enabledObjs.Count; i < len; i++)
            {
                _pool.Release(_enabledObjs[i]);
            }

            _enabledObjs.Clear();
        }
    }
}
