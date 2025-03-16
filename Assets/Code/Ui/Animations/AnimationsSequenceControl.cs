using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Ui.Animations
{
    public class AnimationsSequenceControl : MonoBehaviour
    {
        [SerializeField] private TweenAnimation[] _tweenAnimations;
        private Sequence _sequence;

        public void DoAnimations(Action onEnd = null)
        {
            _sequence = DOTween.Sequence();

            for (int i = 0, len = _tweenAnimations.Length; i < len; i++)
            {
                _sequence.Append(_tweenAnimations[i].GetAnimation()).OnComplete(() => onEnd?.Invoke());
            }
        }
    }
}