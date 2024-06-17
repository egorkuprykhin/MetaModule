using Infrastructure.Attributes;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 0)]
    public class StartNextLevelButtonAction : ButtonAction
    {
        private LevelsService _levelsService;
        private CoreStarterService _coreStarterService;
        private ScreensService _screensService;

        public override void Action()
        {
            _levelsService.SetNextLevel();
            _screensService.HideCurrentScreen();
            _coreStarterService.StartCore();
        }

        protected override void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
            _coreStarterService = ServiceLocator.GetService<CoreStarterService>();
            _screensService = ServiceLocator.GetService<ScreensService>();
        }
    }
}