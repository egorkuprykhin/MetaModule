using Infrastructure.Attributes;
using Infrastructure.Common;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Views
{
    [TopmostComponent]
    public abstract class OptionsView : MonoBehaviour, IInitializable
    {
        protected SfxService _sfxService;
        protected VibrationService _vibrationService;

        public void Initialize()
        {
            _sfxService = ServiceLocator.GetService<SfxService>();
            _vibrationService = ServiceLocator.GetService<VibrationService>();
            
            OnInitialize();
        }

        public void Show()
        {
            OnShow();
        }

        public void Hide()
        {
            _sfxService.SaveSettings();
            _vibrationService.SaveSettings();
        }

        protected abstract void OnInitialize();

        protected abstract void OnShow();
    }
}