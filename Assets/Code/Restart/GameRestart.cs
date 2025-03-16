using System.Collections.Generic;

namespace Code.Restart
{
    public class GameRestart
    {
        private List<IRestartable> _restartableItemItems = new();

        public void AddRestartableItem(IRestartable restartableItem)
        {
            _restartableItemItems.Add(restartableItem);
        }

        public void Restart()
        {
            for (int i = 0, count = _restartableItemItems.Count; i < count; i++)
            {
                _restartableItemItems[i].Restart();
            }
        }
    }
}