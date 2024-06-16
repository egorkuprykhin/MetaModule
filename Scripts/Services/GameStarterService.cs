using Infrastructure.Screens;

namespace Infrastructure.Services
{
    public class GameStarterService : IInitializableService
    {
        private TimerService _timerService;
        private GameLifecycleService _gameLifecycleService;
        private GameResultService _gameResultService;
        private ScoresService _scoresService;
        private PlayerDataService _playerDataService;
        
        private GameScreen _gameScreen;

        public void Initialize()
        {
            _timerService = ServiceLocator.GetService<TimerService>();
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            _scoresService = ServiceLocator.GetService<ScoresService>();
            _playerDataService = ServiceLocator.GetService<PlayerDataService>();
            
            _gameScreen = ScreenLocator.GetScreen<GameScreen>();
        }

        public void StartGame()
        {
            ResetServices();
            StartServices();
            ShowGameScreen();
        }

        private void ResetServices()
        {
            _scoresService.ResetScores();
            _gameResultService.ResetGameResult();
            _playerDataService.ResetSeed();
        }

        private void StartServices()
        {
            _timerService.StartTimer();
            _gameLifecycleService.StartGame();
        }

        private void ShowGameScreen()
        {
            _gameScreen.Show();
            _gameScreen.StartGame();
        }
    }
}