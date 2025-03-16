using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Dispose
{
    public class Disposer : MonoBehaviour
    {
        private List<IDisposable> _disposableItems = new();

        public void Add(IDisposable item)
        {
            _disposableItems.Add(item);
        }

        private void OnDestroy()
        {
            for (var i = _disposableItems.Count - 1; i >= 0; i--)
            {
                _disposableItems[i].Dispose();
            }
        }
    }
}
