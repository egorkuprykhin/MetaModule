using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Core
{
    public abstract class GameFactory<TGameSettings, TSfxSettings, TAnimationSettings> : 
        MonoService, 
        IInitializableService
        where TGameSettings : GameSettingsBase
        where TSfxSettings : SfxSettingBase
        where TAnimationSettings : AnimationSettingsBase
    {
        [SerializeField] private List<GameViewBase> Prefabs;
        
        private ConfigurationService _configurationService;

        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
        }

        public TView CreateView<TView>(Transform parent) where TView : GameViewBase
        {
            foreach (var gameView in Prefabs)
            {
                if (gameView is TView view)
                {
                    TView instance = Instantiate(view, parent, false);
                    
                    if (instance is GameView<TGameSettings, TSfxSettings, TAnimationSettings> gameViewInstance)
                    {
                        TGameSettings settings = _configurationService.GetSettings<TGameSettings>();
                        TSfxSettings sfxSettings = _configurationService.GetSettings<TSfxSettings>();
                        TAnimationSettings animationSettings = _configurationService.GetSettings<TAnimationSettings>();
                        
                        gameViewInstance.Construct(settings, sfxSettings, animationSettings);
                    }
                    
                    return instance;
                }
            }

            throw new ArgumentException($"Missed prefab for type: {nameof(TView)}");
        }
    }
}