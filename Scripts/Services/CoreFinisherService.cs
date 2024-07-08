using Core.Game;
using Cysharp.Threading.Tasks;
using Infrastructure.Screens;
using Match3Game.Services;
using UnityEngine;

namespace Infrastructure.Services
{
    public class CoreFinisherService : IInitializableService, IPostInitializableService, IUpdatableService
    {
        private GameLifecycleService _gameLifecycleService;
        private GameResultService _gameResultService;
        private PlayerDataService _playerDataService;
        private IGameService _gameService;
        private ITargetsService _targetsService;

        private ResultScreen _resultScreen;
        private GameScreen _gameScreen;

        public void Initialize()
        {
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            _playerDataService = ServiceLocator.GetService<PlayerDataService>();
            _gameService = ServiceLocator.GetService<IGameService>();
            _targetsService = ServiceLocator.GetService<ITargetsService>();
            
            _resultScreen = ScreenLocator.GetScreen<ResultScreen>();
            _gameScreen = ScreenLocator.GetScreen<GameScreen>();
        }

        public void PostInitialize()
        {
            SubscribeOnTargetsCollection();
        }

        private void SubscribeOnTargetsCollection()
        {
            if (_targetsService is { Enabled: true })
                _targetsService.TargetsCollected += AllTargetsCollected;
        }

        private void AllTargetsCollected()
        {
            _gameLifecycleService.SetPause(true);
            FinishGameByTargets().Forget();
        }

        private async UniTaskVoid FinishGameByTargets()
        {
            await UniTask.WaitForSeconds(_targetsService.DelayBeforeWin);
            FinishGame();
        }

        public void FinishGame()
        {
            _gameLifecycleService.StopGame();
            _gameResultService.CalculateGameResult();
            _playerDataService.UpdateCurrentLevelProgress();
            _playerDataService.SavePlayerData();
            
            _gameService?.ClearField();

            _gameScreen.Hide();
            _resultScreen.Show();
        }

        public void UpdateService(float deltaTime)
        {
#if UNITY_EDITOR
            if (Input.GetKeyUp(KeyCode.W)) 
                FinishGame();
#endif
        }
    }
}