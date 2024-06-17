using Core.Services;
using Infrastructure.Screens;

namespace Infrastructure.Services
{
    public class CoreFinisherService : IInitializableService
    {
        private GameLifecycleService _gameLifecycleService;
        private GameResultService _gameResultService;
        private PlayerDataService _playerDataService;
        private IGameFinisherService _gameFinisher;

        private ResultScreen _resultScreen;
        private GameScreen _gameScreen;

        public void Initialize()
        {
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            _playerDataService = ServiceLocator.GetService<PlayerDataService>();
            _gameFinisher = ServiceLocator.GetService<IGameFinisherService>();
            
            _resultScreen = ScreenLocator.GetScreen<ResultScreen>();
            _gameScreen = ScreenLocator.GetScreen<GameScreen>();
        }

        public void FinishGame()
        {
            _gameLifecycleService.StopGame();
            _gameResultService.CalculateGameResult();
            _playerDataService.UpdateCurrentLevelProgress();
            _playerDataService.SavePlayerData();
            
            _gameFinisher?.FinishGame();

            _gameScreen.Hide();
            _resultScreen.Show();
        }
    }
}