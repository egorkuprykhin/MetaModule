using Infrastructure.Attributes;
using Infrastructure.Screens;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class RestartCurrentLevelAction : ButtonAction
    {
        private CoreStarterService _coreStarterService;
        private WinScreen _winScreen;
        private LoseScreen _loseScreen;
        

        public override void Action()
        {
            _winScreen.Hide();
            _loseScreen.Hide();
            _coreStarterService.StartCore();
        }

        protected override void Initialize()
        {
            _coreStarterService = ServiceLocator.GetService<CoreStarterService>();
            _winScreen = ScreenLocator.GetScreen<WinScreen>();
            _loseScreen = ScreenLocator.GetScreen<LoseScreen>();
        }
    }
}