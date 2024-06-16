using Infrastructure.Attributes;
using Infrastructure.Screens;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 0)]
    public class RestartCurrentLevelButtonAction : ButtonAction
    {
        private GameStarterService _gameStarterService;
        private ResultScreen _resultScreen;

        public override void Action()
        {
            _resultScreen.Hide();
            _gameStarterService.StartGame();
        }

        protected override void Initialize()
        {
            _gameStarterService = ServiceLocator.GetService<GameStarterService>();
            _resultScreen = ScreenLocator.GetScreen<ResultScreen>();
        }
    }
}