using Core.Game;
using Infrastructure.Attributes;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class StopGameAction : ButtonAction
    {
        private GameLifecycleService _gameLifecycleService;
        private IGameService _gameService;

        public override void Action()
        {
            _gameLifecycleService.StopGame();
            _gameService?.ClearField();
        }

        protected override void Initialize()
        {
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _gameService = ServiceLocator.GetService<IGameService>();
        }
    }
}