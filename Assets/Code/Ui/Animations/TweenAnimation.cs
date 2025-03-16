using DG.Tweening;
using UnityEngine;

namespace Code.Ui.Animations
{
    public abstract class TweenAnimation : MonoBehaviour
    {
        public abstract Tween GetAnimation();
    }
}