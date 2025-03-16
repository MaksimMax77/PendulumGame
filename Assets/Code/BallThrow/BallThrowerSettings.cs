using UnityEngine;

namespace Code.BallThrow
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(BallThrowerSettings), fileName = nameof(BallThrowerSettings), order = 0)]
    public class BallThrowerSettings : ScriptableObject
    {
        [SerializeField] private Color[] _colors;
        public Color[] Colors => _colors;
    }
}
