using System;
using System.Collections.Generic;
using Code.BallThrow;
using Code.Pooling;
using UnityEngine;
using Update;
using Object = UnityEngine.Object;

namespace Code.BallsFieldManagement
{
    public class BallsLinesRemover : IUpdatable, IDisposable
    {
        private List<BallsCell> _line = new();
        private CellsFieldStateChecker _cellsFieldStateChecker;
        private Pool _ballPool;
        private Pool _effectPool;

        public BallsLinesRemover(CellsFieldStateChecker cellsFieldStateChecker, PoolsManager poolsManager)
        {
            _cellsFieldStateChecker = cellsFieldStateChecker;
            _ballPool = poolsManager.GetPool(typeof(Ball));
            _effectPool = poolsManager.GetPool(typeof(PoolElementWithLifeTime));
            _cellsFieldStateChecker.LineCreated += SetLine;
        }

        public void Dispose()
        {
            _cellsFieldStateChecker.LineCreated -= SetLine;
        }

        private void SetLine(List<BallsCell> line)
        {
            _line = line;
        }

        public void Update()
        {
            if (_line.Count == 0)
            {
                return;
            }

            for (int i = 0, len = _line.Count; i < len; ++i)
            {
                var cell = _line[i];
                var pos = cell.transform.position;
                var ball = cell.RestoreBall();
                if (ball == null)
                {
                    _line.Clear();
                    return;
                }

                _ballPool.Release(ball);
                var effect = _effectPool.Get<PoolElementWithLifeTime>();
                effect.transform.position = pos;
            }

            _line.Clear();
        }
    }
}