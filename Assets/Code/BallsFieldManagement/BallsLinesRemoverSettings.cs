using UnityEngine;

namespace Code.BallsFieldManagement
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(BallsLinesRemoverSettings), fileName = nameof(BallsLinesRemoverSettings), order = 0)]
    public class BallsLinesRemoverSettings : ScriptableObject //TODO REMOVE
    {
        [SerializeField] private GameObject _removeEffect;
        public GameObject RemoveEffect => _removeEffect;
    }
}
