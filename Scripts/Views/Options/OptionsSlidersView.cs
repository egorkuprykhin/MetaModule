using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class OptionsSlidersView : OptionsView
    {
        [SerializeField] private Slider SoundSlider;
        [SerializeField] private Slider MusicSlider;

        protected override void Subscribe()
        {
            SubscribeSliders();
        }

        protected override void UpdateView()
        {
            UpdateSliderValues();
        }

        private void UpdateSliderValues()
        {
            SoundSlider.value = _sfxService.SfxVolume;
            MusicSlider.value = _sfxService.MusicVolume;
        }

        private void SubscribeSliders()
        {
            SoundSlider.onValueChanged.AddListener(SoundEnableChanged);
            MusicSlider.onValueChanged.AddListener(MusicEnableChanged);
        }

        private void SoundEnableChanged(float value)
        {
            _sfxService.SetSfxVolume(value);
        }

        private void MusicEnableChanged(float value)
        {
            _sfxService.SetMusicVolume(value);
        }
    }
}