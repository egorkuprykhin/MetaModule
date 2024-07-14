using Infrastructure.ButtonActions;
using Infrastructure.Services;
using Infrastructure.Settings;
using Infrastructure.Views;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class WinScreen : ScreenBase, IInitializableScreen
    {
        [SerializeField] private TimerView TimerView;
        [SerializeField] private StarsView StarsView;
        [SerializeField] private ScoresView ScoresView;
        [SerializeField] private CurrentLevelView LevelView;

        private ConfigurationService _configurationService;
        private SoundService _soundService;
        private SoundSettings _soundSettings;

        public void Initialize()
        {
            _soundService = ServiceLocator.GetService<SoundService>();
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _soundSettings = _configurationService?.GetSettings<SoundSettings>();
            
            if (TimerView)
                TimerView.Initialize();
            
            if (StarsView)
                StarsView.Initialize();
            
            if (ScoresView)
                ScoresView.Initialize();
            
            if (LevelView)
                LevelView.Initialize();
        }

        protected override void OnShow()
        {
            if (StarsView)
                StarsView.Show();
            if (ScoresView)
                ScoresView.Show();
            if (LevelView)
                LevelView.Show();
            if (TimerView) 
                TimerView.Show();
            
            _soundService.PlaySfx( _soundSettings.WinGame);
        }
    }
}