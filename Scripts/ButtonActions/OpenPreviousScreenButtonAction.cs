using Infrastructure.Attributes;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class OpenPreviousScreenButtonAction : ButtonAction
    {
        private ScreensService _screensService;

        public override void Action()
        {
            _screensService.HideCurrentScreen();
            _screensService.ShowPreviousScreen();
        }

        protected override void Initialize()
        {
            _screensService = ServiceLocator.GetService<ScreensService>();
        }
    }
}