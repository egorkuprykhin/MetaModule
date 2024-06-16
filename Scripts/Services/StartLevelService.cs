using Infrastructure.Screens;

namespace Infrastructure.Services
{
    public class StartLevelService : IInitializableService
    {
        private LevelsService _levelsService;
        private GameStarterService _gameStarterService;
        private LevelsScreen _levelsScreen;

        public void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
            _levelsScreen = ScreenLocator.GetScreen<LevelsScreen>();
            _gameStarterService = ServiceLocator.GetService<GameStarterService>();
        }

        public void StartLevelIfUnlocked(int level)
        {
            if (_levelsService.IsLevelUnlocked(level))
            {
                _levelsScreen.Hide();
                
                _levelsService.SetCurrentLevel(level);
                
                _gameStarterService.StartGame();
            }
        }
    }
}