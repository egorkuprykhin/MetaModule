using Infrastructure.Attributes;
using Infrastructure.Screens;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class RestartCurrentLevelAction : ButtonAction
    {
        private CoreStarterService _coreStarterService;
        private ResultScreen _resultScreen;

        public override void Action()
        {
            _resultScreen.Hide();
            _coreStarterService.StartCore();
        }

        protected override void Initialize()
        {
            _coreStarterService = ServiceLocator.GetService<CoreStarterService>();
            _resultScreen = ScreenLocator.GetScreen<ResultScreen>();
        }
    }
}