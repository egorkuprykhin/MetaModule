using Infrastructure.Attributes;
using Infrastructure.Core;
using Infrastructure.Services;

namespace Infrastructure.Views
{
    [TopmostComponent]
    public abstract class OptionsView : MetaView
    {
        protected SfxService _sfxService;
        protected VibrationService _vibrationService;

        public override void Initialize()
        {
            _sfxService = ServiceLocator.GetService<SfxService>();
            _vibrationService = ServiceLocator.GetService<VibrationService>();
            
            Subscribe();
        }
        
        public override void Show()
        {
            UpdateView();
        }

        public override void Hide()
        {
            _sfxService.SaveSettings();
            _vibrationService.SaveSettings();
        }

        protected abstract void Subscribe();
    }
}