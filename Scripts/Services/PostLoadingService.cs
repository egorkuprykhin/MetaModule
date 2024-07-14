using Game.Services;
using Infrastructure.Screens;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services
{
    public class PostLoadingService : MonoService, IInitializableService
    {
        [SerializeField] public ScreenBase NextScreen;
        
        private SoundService _soundService;
        private BlurService _blurService;

        public void Initialize()
        {
            _soundService = ServiceLocator.GetService<SoundService>();
            _blurService = ServiceLocator.GetService<BlurService>();
        }

        public void PostLoadingAction()
        {
            _blurService.EnableBlur();
            _soundService.PlayBackgroundMusic();
            
            if (NextScreen)
                NextScreen.Show();
        }
    }
}