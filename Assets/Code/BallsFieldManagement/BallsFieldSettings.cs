using UnityEngine;

namespace Code.BallsFieldManagement
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(BallsFieldSettings), fileName = nameof(BallsFieldSettings), order = 0)]
    public class BallsFieldSettings : ScriptableObject
    {
        [SerializeField] private int _xSize;
        [SerializeField] private int _ySize;

        public int XSize => _xSize;
        public int YSize => _ySize;
    }
}
