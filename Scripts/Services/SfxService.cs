using Core.Sfx;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services
{
    public class SfxService : MonoService, IInitializableService
    {
        [SerializeField] private AudioSource SfxSoundAudioSource;
        [SerializeField] private AudioSource MusicAudioSource;
        
        private OptionsDataService _optionsDataService;

        public bool SfxEnabled => _optionsDataService.OptionsData.SfxVolume > 0;
        public bool MusicEnabled => _optionsDataService.OptionsData.MusicVolume > 0;
        public float SfxVolume => _optionsDataService.OptionsData.SfxVolume;
        public float MusicVolume => _optionsDataService.OptionsData.MusicVolume;
        
        public void Initialize()
        {
            _optionsDataService = ServiceLocator.GetService<OptionsDataService>();
            UpdateVolume();
        }

        public void PlayBackgroundMusic()
        {
            MusicAudioSource.Play();
        }

        public void PlaySfx(SfxType sfxType)
        {
            if (sfxType.AudioClip)
                SfxSoundAudioSource.PlayOneShot(sfxType.AudioClip);
        }

        public void SwitchMusicEnabled()
        {
            int volume = _optionsDataService.OptionsData.MusicVolume > 0 ? 0 : 1;
            _optionsDataService.OptionsData.MusicVolume = volume;
            UpdateVolume();
        }
        
        public void SwitchSfxEnabled()
        {
            int volume = _optionsDataService.OptionsData.SfxVolume > 0 ? 0 : 1;
            _optionsDataService.OptionsData.SfxVolume = volume;
            UpdateVolume();
        }

        public void SetSfxEnabled(bool isEnabled)
        {
            _optionsDataService.OptionsData.SfxVolume = isEnabled ? 1 : 0;
            UpdateVolume();
        }

        public void SetMusicEnabled(bool isEnabled)
        {
            _optionsDataService.OptionsData.MusicVolume = isEnabled ? 1 : 0;
            UpdateVolume();
        }

        public void SetSfxVolume(float value)
        {
            _optionsDataService.OptionsData.SfxVolume = value;
            UpdateVolume();
        }

        public void SetMusicVolume(float value)
        {
            _optionsDataService.OptionsData.MusicVolume = value;
            UpdateVolume();
        }

        private void UpdateVolume()
        {
            SfxSoundAudioSource.volume = SfxVolume;
            MusicAudioSource.volume = MusicVolume;
        }

        public void SaveSettings()
        {
            _optionsDataService.Save();
        }
    }
}