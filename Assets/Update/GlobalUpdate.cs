using System.Collections.Generic;
using UnityEngine;

namespace Update
{
    public class GlobalUpdate : MonoBehaviour
    {
        private List<IUpdatable> _updatableObjects = new List<IUpdatable>();

        public void Add(IUpdatable updatable)
        {
            _updatableObjects.Add(updatable);
        }

        private void Update()
        {
            for (int i = 0, count = _updatableObjects.Count; i < count; i++)
            {
                _updatableObjects[i].Update();
            }
        }
    }
}