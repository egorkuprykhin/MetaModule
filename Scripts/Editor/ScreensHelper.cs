using System;
using System.Collections.Generic;
using Core.MetaModule.Scripts.Buttons;
using Infrastructure.Common;
using Infrastructure.Core;
using Infrastructure.Screens;
using Object = UnityEngine.Object;

namespace Editor
{
    public static class ScreensHelper
    {
#if UNITY_EDITOR
        private static readonly Dictionary<string, Type> _screens = new Dictionary<string, Type>
        {
            { Constants.Screens.Loading, typeof(LoadingScreen) },
            { Constants.Screens.Start, typeof(StartScreen) },
            { Constants.Screens.Menu, typeof(MenuScreen) },
            { Constants.Screens.Policy, typeof(PolicyScreen) },
            { Constants.Screens.Options, typeof(OptionsScreen) },
            { Constants.Screens.Settings, typeof(OptionsScreen) },
            { Constants.Screens.Level, typeof(LevelsScreen) },
            { Constants.Screens.Levels, typeof(LevelsScreen) },
            { Constants.Screens.Game, typeof(GameScreen) },
            { Constants.Screens.Win, typeof(WinScreen) },
            { Constants.Screens.Lose, typeof(LoseScreen) },
            { Constants.Screens.Exit, typeof(ExitScreen) },
            { Constants.Screens.Rules, typeof(RulesScreen) },
            { Constants.Buttons.Ok, typeof(MenuScreen) },
        };

        private static readonly Dictionary<string, ButtonBindingType> _buttonsToScreens = new Dictionary<string, ButtonBindingType>
        {
            { Constants.Buttons.Ok, ButtonBindingType.OpenScreen },
            { Constants.Buttons.Back, ButtonBindingType.Back },
            { Constants.Buttons.Yes, ButtonBindingType.ExitGame },
            { Constants.Buttons.No, ButtonBindingType.Back },
            { Constants.Buttons.Play, ButtonBindingType.StartGame },
            { Constants.Buttons.Start, ButtonBindingType.StartGame },
            { Constants.Buttons.Stop, ButtonBindingType.StopGame },
            { Constants.Buttons.Next, ButtonBindingType.StartAfterResult },
            { Constants.Buttons.TryAgain, ButtonBindingType.StartAfterResult }
        };
        
        private static readonly Dictionary<ButtonBindingType, Type> _bindingsToButtons = new Dictionary<ButtonBindingType, Type>()
        {
            { ButtonBindingType.OpenScreen, typeof(OpenScreenButton)}
        };

        public static Dictionary<string, Type> GetScreens() => _screens;

        public static ScreenBase GetPostLoadingScreen()
        {
            ScreenBase screen = Object.FindObjectOfType<StartScreen>();
            if(!screen)
                screen = Object.FindObjectOfType<MenuScreen>();

            return screen;
        }

        public static ScreenBase GetStopGameScreen()
        {
            ScreenBase screen = Object.FindObjectOfType<LevelsScreen>();
            if(!screen)
                screen = Object.FindObjectOfType<MenuScreen>();

            return screen;
        }

        public static ButtonBindingType GetBindingTypeByButtonId(string buttonId)
        {
            if (_buttonsToScreens.TryGetValue(buttonId, out var buttonBindingType))
                return buttonBindingType;

            foreach (var key in _buttonsToScreens.Keys)
            {
                if (buttonId.Contains(key))
                    return _buttonsToScreens[key];
            }
            
            return ButtonBindingType.OpenScreen;
        }

        public static ScreenBase GetScreenByButtonId(string name)
        {
            if (_screens.TryGetValue(name, out var screenType))
                return (ScreenBase)Object.FindObjectOfType(screenType, true);

            return null;
        }
        
#endif
    }
}