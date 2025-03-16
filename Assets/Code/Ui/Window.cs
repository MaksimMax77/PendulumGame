using System;
using Code.Ui.Animations;
using UnityEngine;

namespace Code.Ui
{
    public abstract class Window : MonoBehaviour, IDisposable
    {
        [SerializeField] private AnimationsSequenceControl _closeAnimatons;
        [SerializeField] private AnimationsSequenceControl _openAnimatons;

        public virtual void Initialize()
        {
            //no op
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _openAnimatons.DoAnimations();
        }

        public void Close()
        {
            _closeAnimatons.DoAnimations((() => gameObject.SetActive(false)));
        }

        public virtual void Dispose()
        {
            //no op
        }
    }
}