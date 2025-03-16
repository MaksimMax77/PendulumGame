using Code.Pooling;
using Code.Restart;

namespace Code.BallThrow
{
    public class BallsRemover : IRestartable
    {
        private Pool _ballPool;

        public BallsRemover(PoolsManager manager)
        {
            _ballPool = manager.GetPool(typeof(Ball));
        }

        public void Restart()
        {
            _ballPool.ReleaseAll();
        }
    }
}
