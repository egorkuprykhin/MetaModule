using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class OptionsButtonsView : OptionsView
    {
        [SerializeField] private Button MusicOnButton;
        [SerializeField] private Button MusicOffButton;
        [SerializeField] private Button SfxOnButton;
        [SerializeField] private Button SfxOffButton;

        protected override void Subscribe()
        {
            SubscribeButtons();
        }

        protected override void UpdateView()
        {
        }

        private void SubscribeButtons()
        {
            if (MusicOnButton)
                MusicOnButton.onClick.AddListener(() => _sfxService.SetMusicEnabled(true));
            
            if (MusicOffButton)
                MusicOffButton.onClick.AddListener(() => _sfxService.SetMusicEnabled(false));
            
            if (SfxOnButton)
                SfxOnButton.onClick.AddListener(() => _sfxService.SetSfxEnabled(true));
            
            if (SfxOffButton)
                SfxOffButton.onClick.AddListener(() => _sfxService.SetSfxEnabled(false));
        }
    }
}