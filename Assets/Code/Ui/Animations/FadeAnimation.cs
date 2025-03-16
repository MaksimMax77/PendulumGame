using DG.Tweening;
using UnityEngine;

namespace Code.Ui.Animations
{
    public class FadeAnimation : TweenAnimation
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _targetAlpha;

        public override Tween GetAnimation()
        {
            return _canvasGroup.DOFade(_targetAlpha, 1);
        }
    }
}