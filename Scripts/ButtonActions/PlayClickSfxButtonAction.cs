using Infrastructure.Attributes;
using Infrastructure.Services;
using Infrastructure.Settings;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 3)]
    public class PlayClickSfxButtonAction : ButtonAction
    {
        private SfxService _sfxService;
        private CommonSfxSettings _commonSfxSettings;

        public override void Action()
        {
            _sfxService.PlaySfx(_commonSfxSettings.Click);
        }

        protected override void Initialize()
        {
            _sfxService = ServiceLocator.GetService<SfxService>();
            _commonSfxSettings = ServiceLocator.GetService<ConfigurationService>().GetSettings<CommonSfxSettings>();
        }
    }
}