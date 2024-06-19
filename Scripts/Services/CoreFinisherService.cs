using Core.Game;
using Infrastructure.Screens;

namespace Infrastructure.Services
{
    public class CoreFinisherService : IInitializableService
    {
        private GameLifecycleService _gameLifecycleService;
        private GameResultService _gameResultService;
        private PlayerDataService _playerDataService;
        private IGameService _gameService;

        private ResultScreen _resultScreen;
        private GameScreen _gameScreen;

        public void Initialize()
        {
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            _playerDataService = ServiceLocator.GetService<PlayerDataService>();
            _gameService = ServiceLocator.GetService<IGameService>();
            
            _resultScreen = ScreenLocator.GetScreen<ResultScreen>();
            _gameScreen = ScreenLocator.GetScreen<GameScreen>();
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
    }
}