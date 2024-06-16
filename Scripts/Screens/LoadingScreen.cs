using System.Threading.Tasks;
using Infrastructure.Services;
using Infrastructure.Settings;
using Infrastructure.Views;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class LoadingScreen : ScreenBase, IInitializableScreen
    {
        [SerializeField] private ProgressbarBaseView ProgressbarView;

        private PostLoadingService _postLoadingService;
        private LoadingSettings _loadingSettings;

        public void Initialize()
        {
            _postLoadingService = ServiceLocator.GetService<PostLoadingService>();
            _loadingSettings = ServiceLocator.GetService<ConfigurationService>().GetSettings<LoadingSettings>();
            
            if (ProgressbarView)
                ProgressbarView.Initialize();
        }

        protected override async void OnShow()
        {
            await ShowProgress();
            Hide();
        }

        protected override void OnHide()
        {
            if (ProgressbarView)
                ProgressbarView.Hide();
            
            _postLoadingService.PostLoadingAction();
        }

        private async Task ShowProgress()
        {
            if (ProgressbarView)
                await ProgressbarView.Show(_loadingSettings.LoadingTime);
            else
                await Task.Delay((int)(_loadingSettings.LoadingTime * 1000));
        }
    }
}