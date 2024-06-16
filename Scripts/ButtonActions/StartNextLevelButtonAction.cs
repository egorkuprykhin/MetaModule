using Infrastructure.Attributes;
using Infrastructure.Services;
// using Infrastructure.SortingGame;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 0)]
    public class StartNextLevelButtonAction : ButtonAction
    {
        private LevelsService _levelsService;
        // private SortingGameStarter _gameStarterService;
        private ScreensService _screensService;

        public override void Action()
        {
            _levelsService.SetNextLevel();
            _screensService.HideCurrentScreen();
            // _gameStarterService.StartGame();
        }

        protected override void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
            // _gameStarterService = ServiceLocator.GetService<SortingGameStarter>();
            _screensService = ServiceLocator.GetService<ScreensService>();
        }
    }
}