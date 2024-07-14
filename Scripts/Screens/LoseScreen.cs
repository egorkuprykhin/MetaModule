using Infrastructure.ButtonActions;
using Infrastructure.Services;
using Infrastructure.Settings;
using Infrastructure.Views;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class LoseScreen : ScreenBase, IInitializableScreen
    {
        [SerializeField] private TimerView TimerView;
        [SerializeField] private ScoresView ScoresView;
        [SerializeField] private CurrentLevelView LevelView;

        private ConfigurationService _configurationService;
        private SfxService _sfxService;
        private SoundSettings _soundSettings;

        public void Initialize()
        {
            _sfxService = ServiceLocator.GetService<SfxService>();
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _soundSettings = _configurationService?.GetSettings<SoundSettings>();
            
            if (TimerView)
                TimerView.Initialize();
            
            if (ScoresView)
                ScoresView.Initialize();
            
            if (LevelView)
                LevelView.Initialize();
        }

        protected override void OnShow()
        {
            if (ScoresView)
                ScoresView.Show();
            if (LevelView)
                LevelView.Show();
            if (TimerView) 
                TimerView.Show();
            
            _sfxService.PlaySfx( _soundSettings.LoseGame);
        }
    }
}