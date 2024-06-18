using Cysharp.Threading.Tasks;
using Infrastructure.Core;
using Infrastructure.Screens;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Common
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private RegistrationsBinder RegistrationsBinder;
        [SerializeField] private ServiceLocator ServiceLocator; 
        [SerializeField] private ScreenLocator ScreensLocator;

        private void Awake()
        {
            RegistrationsBinder.BindRegistrations(ServiceLocator);
            
            ScreensLocator.Register();

            ServiceLocator.Initialize();
            
            ScreensLocator.Initialize();
        }

        private async void Start()
        {
            await UniTask.NextFrame();
            
            LoadingScreen loadingScreen = ScreenLocator.GetScreen<LoadingScreen>();
            loadingScreen.Show();
        }

        private void Update()
        {
            ServiceLocator.UpdateServices(Time.deltaTime);
        }
    }
}