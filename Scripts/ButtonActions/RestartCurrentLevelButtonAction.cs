using Infrastructure.Attributes;
using Infrastructure.Screens;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 0)]
    public class RestartCurrentLevelButtonAction : ButtonAction
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