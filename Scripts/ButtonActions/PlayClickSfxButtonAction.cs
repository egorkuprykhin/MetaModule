using Infrastructure.Attributes;
using Infrastructure.Services;
using Infrastructure.Settings;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 3)]
    public class PlayClickSfxButtonAction : ButtonAction
    {
        private SfxService _sfxService;
        private SfxSettings _sfxSettings;

        public override void Action()
        {
            _sfxService.PlaySfx(_sfxSettings.Click);
        }

        protected override void Initialize()
        {
            _sfxService = ServiceLocator.GetService<SfxService>();
            _sfxSettings = ServiceLocator.GetService<ConfigurationService>().GetSettings<SfxSettings>();
        }
    }
}