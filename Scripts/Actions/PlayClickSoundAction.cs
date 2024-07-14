using Infrastructure.Attributes;
using Infrastructure.Services;
using Infrastructure.Settings;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 4)]
    public class PlayClickSoundAction : ButtonAction
    {
        private SfxService _sfxService;
        private SoundSettings _soundSettings;

        public override void Action()
        {
            _sfxService.PlaySfx(_soundSettings.Click);
        }

        protected override void Initialize()
        {
            _sfxService = ServiceLocator.GetService<SfxService>();
            _soundSettings = ServiceLocator.GetService<ConfigurationService>().GetSettings<SoundSettings>();
        }
    }
}