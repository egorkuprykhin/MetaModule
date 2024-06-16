using Infrastructure.Attributes;
using Infrastructure.Screens;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class OpenScreenButtonAction : ButtonAction
    {
        [SerializeField] private ScreenBase Screen;

        private ScreensService _screensService;

        public override void Action()
        {
            _screensService.HideCurrentScreen();
            Screen.Show();
        }

        protected override void Initialize()
        {
            _screensService = ServiceLocator.GetService<ScreensService>();
        }
    }
}