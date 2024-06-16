using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class OptionsCrossedButtonsView : OptionsView
    {
        [SerializeField] private Button SfxButton;
        [SerializeField] private Image SfxCross;
        [SerializeField] private Button MusicButton;
        [SerializeField] private Image MusicCross;

        protected override void Subscribe()
        {
            SfxButton.onClick.AddListener(SwitchEnableSfx);
            MusicButton.onClick.AddListener(SwitchEnableMusic);
        }

        protected override void UpdateView()
        {
            SfxCross.enabled = !_sfxService.SfxEnabled;
            MusicCross.enabled = !_sfxService.MusicEnabled;
        }

        private void SwitchEnableSfx()
        {
            _sfxService.SwitchSfxEnabled();
            UpdateView();
        }

        private void SwitchEnableMusic()
        {
            _sfxService.SwitchMusicEnabled();
            UpdateView();
        }
    }
}