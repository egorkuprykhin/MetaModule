using Infrastructure.Attributes;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class StopGameButtonAction : ButtonAction
    {
        private GameLifecycleService _gameLifecycleService;

        public override void Action()
        {
            _gameLifecycleService.StopGame();
        }

        protected override void Initialize()
        {
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
        }
    }
}