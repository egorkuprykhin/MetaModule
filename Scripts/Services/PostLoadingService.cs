using Game.Services;
using Infrastructure.Screens;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services
{
    public class PostLoadingService : MonoService, IInitializableService
    {
        [SerializeField] private ScreenBase NextScreen;
        
        private SfxService _sfxService;
        private BlurService _blurService;

        public void Initialize()
        {
            _sfxService = ServiceLocator.GetService<SfxService>();
            _blurService = ServiceLocator.GetService<BlurService>();
        }

        public void PostLoadingAction()
        {
            _blurService.EnableBlur();
            _sfxService.PlayBackgroundMusic();
            
            if (NextScreen)
                NextScreen.Show();
        }
    }
}