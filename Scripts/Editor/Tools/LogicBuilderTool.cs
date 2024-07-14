using Coffee.UIEffects;
using Game.Services;
using Infrastructure.Common;
using Infrastructure.Core;
using Infrastructure.Screens;
using Infrastructure.Services;
using Registrations;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class LogicBuilderTool
    {
        [MenuItem(Constants.Tools.BuildMetaLogic)]
        public static void Build()
        {
            var logicGo = new GameObject("Logic");

            var entryPointGo = new GameObject("EntryPoint");
            entryPointGo.transform.SetParent(logicGo.transform);
            
            var registrationsGo = new GameObject("Registrations");
            registrationsGo.transform.SetParent(logicGo.transform);
            
            var preloadingRegistrationGo = new GameObject("PreloadingRegistration");
            preloadingRegistrationGo.transform.SetParent(registrationsGo.transform);
            
            var loadingRegistrationGo = new GameObject("LoadingRegistration");
            loadingRegistrationGo.transform.SetParent(registrationsGo.transform);
            
            var serviceLocatorGo = new GameObject("ServiceLocator");
            serviceLocatorGo.transform.SetParent(logicGo.transform);
            
            var screensLocatorGo = new GameObject("ScreensLocator");
            screensLocatorGo.transform.SetParent(logicGo.transform);
            
            var configurationServiceGo = new GameObject("ConfigurationService");
            configurationServiceGo.transform.SetParent(preloadingRegistrationGo.transform);
            
            var blurServiceGo = new GameObject("BlurService");
            blurServiceGo.transform.SetParent(preloadingRegistrationGo.transform);
            
            var soundServiceGo = new GameObject("SoundService");
            soundServiceGo.transform.SetParent(loadingRegistrationGo.transform);
            
            var soundAudioSourceGo = new GameObject("SoundAudioSource");
            soundAudioSourceGo.transform.SetParent(soundServiceGo.transform);
            
            var musicAudioSourceGo = new GameObject("MusicAudioSource");
            musicAudioSourceGo.transform.SetParent(soundServiceGo.transform);
            
            var vibrationServiceGo = new GameObject("VibrationService");
            vibrationServiceGo.transform.SetParent(loadingRegistrationGo.transform);
            
            var screensServiceGo = new GameObject("ScreensService");
            screensServiceGo.transform.SetParent(loadingRegistrationGo.transform);
            
            var entryPoint = entryPointGo.GetOrAddComponent<EntryPoint>();
            var registrationsBinder = registrationsGo.GetOrAddComponent<RegistrationsBinder>();
            var preloadingRegistration = preloadingRegistrationGo.GetOrAddComponent<PreloadingRegistration>();
            var loadingRegistration = loadingRegistrationGo.GetOrAddComponent<LoadingRegistration>();
            var serviceLocator = serviceLocatorGo.GetOrAddComponent<ServiceLocator>();
            var screensLocator = screensLocatorGo.GetOrAddComponent<ScreenLocator>();
            
            var configurationService = configurationServiceGo.GetOrAddComponent<ConfigurationService>();
            var blurService = blurServiceGo.GetOrAddComponent<BlurService>();
            var soundService = soundServiceGo.GetOrAddComponent<SoundService>();
            var soundAudioSource = soundAudioSourceGo.GetOrAddComponent<AudioSource>();
            var musicAudioSource = musicAudioSourceGo.GetOrAddComponent<AudioSource>();
            var vibrationService = vibrationServiceGo.GetOrAddComponent<VibrationService>();
            var screensService = screensServiceGo.GetOrAddComponent<ScreensService>();

            entryPoint.ServiceLocator = serviceLocator;
            entryPoint.ScreensLocator = screensLocator;
            entryPoint.RegistrationsBinder = registrationsBinder;

            registrationsBinder.CollectRegistrations();
            preloadingRegistration.CollectMonoServices();
            loadingRegistration.CollectMonoServices();
            screensLocator.CollectScreens();

            configurationService.Configuration =
                EditorExtensions.GetSingleByName<Configuration>(Constants.MetaConfiguration);
            
            UIEffect blurEffect = Object.FindObjectOfType<UIEffect>();
            if (blurEffect)
                blurService.BlurEffect = blurEffect;
            
            soundService.SoundAudioSource = soundAudioSource;
            soundService.MusicAudioSource = musicAudioSource;

            soundAudioSource.playOnAwake = false;
            musicAudioSource.playOnAwake = false;
            musicAudioSource.loop = true;

            screensService.AfterLoadingScreen = ScreensHelper.GetPostLoadingScreen();
            screensService.StopGameScreen = ScreensHelper.GetStopGameScreen();
            
            Logger.LogColored("Done", Color.green);
        }
    }
}