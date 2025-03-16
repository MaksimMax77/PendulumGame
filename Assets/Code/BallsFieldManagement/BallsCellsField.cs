using Code.Restart;
using UnityEngine;

namespace Code.BallsFieldManagement
{
    public class BallsCellsField : MonoBehaviour, IRestartable
    {
        [SerializeField] private BallsCell _firstCellPrefab;
        [SerializeField] private BallsCell _cellPrefab;
        [SerializeField] private float _yOffset;
        [SerializeField] private float _xOffset;
        private Vector3 _creationPosition;
        private BallsCell[,] _cells;
        private int _xSize;
        private int _ySize;

        public BallsCell[,] Cells => _cells;

        public void Initialize(BallsFieldSettings settings)
        {
            _xSize = settings.XSize;
            _ySize = settings.YSize;
            _cells = new BallsCell[_xSize, _ySize];
            _creationPosition = transform.position;
            DrawField();
        }

        private void DrawField()
        {
            for (int x = 0; x < _xSize; x++)
            {
                for (int y = 0; y < _ySize; y++)
                {
                    var cell = Instantiate(y == 0 ? _firstCellPrefab : _cellPrefab, _creationPosition,
                        Quaternion.identity);
                    cell.transform.SetParent(transform);
                    var pos = cell.transform.position;
                    pos.x += _xOffset * x;
                    pos.y += _yOffset * y;
                    cell.transform.position = pos;
                    cell.SetPosition(x, y);
                    _cells[x, y] = cell;
                }
            }
        }

        public void Restart()
        {
            for (var x = 0; x < _xSize; x++)
            {
                for (var y = 0; y < _ySize; y++)
                {
                    _cells[x, y].RestoreBall();
                }
            }
        }
    }
}