using Infrastructure.Attributes;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 0)]
    public class ExitGameButtonAction : ButtonAction
    {
        private ExitGameService _exitGameService;

        public override void Action()
        {
            _exitGameService.ExitGame();
        }

        protected override void Initialize()
        {
            _exitGameService = ServiceLocator.GetService<ExitGameService>();
        }
    }
}