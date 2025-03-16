using Code.BallsFieldManagement;
using Code.BallThrow;
using Code.Click;
using Code.Dispose;
using Code.Pendulum;
using Code.Pooling;
using Code.Restart;
using Code.Scores;
using Code.Ui.GameEnd;
using Code.Ui.GameStart;
using UnityEngine;
using UnityEngine.UI;
using Update;
using GameStartWindowControl = Code.Ui.GameStart.GameStartWindowControl;

namespace Code.Installers
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private GlobalUpdate _globalUpdate;
        [SerializeField] private Disposer _disposer;

        [SerializeField] private Transform _pivotTransform;
        [SerializeField] private GameObject _ballImitator;
        [SerializeField] private BallsCellsField _ballsCellsField;
        [SerializeField] private Button _createBallButton;
        [SerializeField] private GameStartWindow _gameStartWindow;
        [SerializeField] private GameEndWindow _gameEndWindow;

        [SerializeField] private PendulumSettings _pendulumSettings;
        [SerializeField] private BallThrowerSettings _ballThrowerSettings;
        [SerializeField] private BallsFieldSettings _ballFieldSettings;
        [SerializeField] private ScoresSettings _scoresSettings;
        [SerializeField] private PoolManagerSettings _poolManagerSettings;

        private void Awake()
        {
            _ballsCellsField.Initialize(_ballFieldSettings);
            var poolsManager = new PoolsManager(_poolManagerSettings);
            var gameRestart = new GameRestart();
            var pendulumControl = new PendulumControl(_pivotTransform, _pendulumSettings);
            var addEventInvoker = new BallAddEventInvoker(_ballsCellsField);
            var cellsFieldStateChecker = new CellsFieldStateChecker(addEventInvoker, _ballsCellsField);
            var ballsLinesRemover = new BallsLinesRemover(cellsFieldStateChecker, poolsManager);
            var ballThrower = new BallThrower(_ballImitator, _ballThrowerSettings, poolsManager);
            var clickControl = new ClickControl(_createBallButton);
            var ballThrowerPresenter = new BallThrowerPresenter(ballThrower, clickControl);

            _gameStartWindow.Initialize();
            _gameEndWindow.Initialize();

            var gameEndWindowControl = new GameEndWindowControl(_gameEndWindow, cellsFieldStateChecker, gameRestart);
            var gameStartWindowControl = new GameStartWindowControl(_gameStartWindow, gameEndWindowControl);
            var scores = new ScoresModel(cellsFieldStateChecker, _scoresSettings);
            var scoresPresenter = new ScoresPresenter(scores, _gameEndWindow);
            var ballsRemover = new BallsRemover(poolsManager);

            _globalUpdate.Add(pendulumControl);
            _globalUpdate.Add(addEventInvoker);
            _globalUpdate.Add(ballsLinesRemover);
            _globalUpdate.Add(poolsManager);

            _disposer.Add(clickControl);
            _disposer.Add(addEventInvoker);
            _disposer.Add(cellsFieldStateChecker);
            _disposer.Add(ballsLinesRemover);
            _disposer.Add(ballThrowerPresenter);
            _disposer.Add(_gameStartWindow);
            _disposer.Add(_gameEndWindow);
            _disposer.Add(gameEndWindowControl);
            _disposer.Add(gameStartWindowControl);
            _disposer.Add(scores);
            _disposer.Add(scoresPresenter);

            gameRestart.AddRestartableItem(_ballsCellsField);
            gameRestart.AddRestartableItem(scores);
            gameRestart.AddRestartableItem(ballsRemover);
        }
    }
}