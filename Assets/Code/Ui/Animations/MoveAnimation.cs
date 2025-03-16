using DG.Tweening;
using UnityEngine;

namespace Code.Ui.Animations
{
    public class MoveAnimation : TweenAnimation
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Vector2 _targetPos;

        public override Tween GetAnimation()
        {
            return rectTransform.DOAnchorPos(_targetPos, 1f);
        }
    }
}