using Infrastructure.Screens;

namespace Infrastructure.Services
{
    public class GameFinisherService : IInitializableService
    {
        private GameLifecycleService _gameLifecycleService;
        private GameResultService _gameResultService;
        
        private ResultScreen _resultScreen;
        private GameScreen _gameScreen;
        private PlayerDataService _playerDataService;

        public void Initialize()
        {
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            _playerDataService = ServiceLocator.GetService<PlayerDataService>();
            
            _resultScreen = ScreenLocator.GetScreen<ResultScreen>();
            _gameScreen = ScreenLocator.GetScreen<GameScreen>();
        }

        public void FinishGame()
        {
            _gameLifecycleService.StopGame();
            _gameResultService.CalculateGameResult();
            _playerDataService.UpdateCurrentLevelProgress();

            _gameScreen.Hide();
            _resultScreen.Show();
        }
    }
}