using Infrastructure.Screens;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services
{
    public class PostLoadingService : MonoService, IInitializableService
    {
        [SerializeField] private ScreenBase NextScreen;
        
        private SfxService _sfxService;

        public void Initialize()
        {
            _sfxService = ServiceLocator.GetService<SfxService>();
        }

        public void PostLoadingAction()
        {
            NextScreen.Show();
            _sfxService.PlayBackgroundMusic();
        }
    }
}