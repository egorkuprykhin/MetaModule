using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class OptionsTogglesView : OptionsView
    {
        [SerializeField] private Toggle MusicToggle;
        [SerializeField] private Toggle SfxToggle;
        [SerializeField] private Toggle VibrationToggle;
        
        protected override void OnInitialize()
        {
            if (MusicToggle)
                MusicToggle.onValueChanged.AddListener(SwitchEnableMusic);
            
            if (SfxToggle)
                SfxToggle.onValueChanged.AddListener(SwitchEnableSound);
            
            if (VibrationToggle)
                VibrationToggle.onValueChanged.AddListener(SwitchEnableVibration);
        }

        protected override void OnShow()
        {
            if (MusicToggle)
                MusicToggle.isOn = _sfxService.MusicEnabled;
            
            if (SfxToggle)
                SfxToggle.isOn = _sfxService.SfxEnabled;

            if (VibrationToggle)
                VibrationToggle.isOn = _vibrationService.IsEnabled;
        }

        private void SwitchEnableMusic(bool isOn)
        {
            _sfxService.SetMusicEnabled(isOn);
        }

        private void SwitchEnableSound(bool isOn)
        {
            _sfxService.SetSfxEnabled(isOn);
        }

        private void SwitchEnableVibration(bool isOn)
        {
            _vibrationService.SetEnabled(isOn);
        }
    }
}