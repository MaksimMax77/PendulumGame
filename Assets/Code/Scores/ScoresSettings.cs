using UnityEngine;

namespace Code.Scores
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(ScoresSettings), fileName = nameof(ScoresSettings),
        order = 0)]
    public class ScoresSettings : ScriptableObject
    {
        [SerializeField] private int _scoresAddingValue;

        public int ScoresAddingValue => _scoresAddingValue;
    }
}