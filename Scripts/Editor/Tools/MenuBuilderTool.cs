using System;
using System.Collections.Generic;
using Infrastructure.Attributes;
using Infrastructure.Common;
using Infrastructure.Screens;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public static class MenuBuilderTool
    {
        private static Dictionary<string, Type> _screens = new Dictionary<string, Type>
        {
            { Constants.Screens.Loading, typeof(LoadingScreen) },
            { Constants.Screens.Start, typeof(StartScreen) },
            { Constants.Screens.Menu, typeof(MenuScreen) },
            { Constants.Screens.Policy, typeof(PolicyScreen) },
            { Constants.Screens.Options, typeof(OptionsScreen) },
            { Constants.Screens.Levels, typeof(LevelsScreen) },
            { Constants.Screens.Game, typeof(GameScreen) },
            { Constants.Screens.Win, typeof(WinScreen) },
            { Constants.Screens.Lose, typeof(LoseScreen) },
            { Constants.Screens.Exit, typeof(ExitScreen) },
            { Constants.Screens.Rules, typeof(RulesScreen) }
        };


        [MenuItem("Tools/Build Menu Screens")]
        public static void BuildMenu()
        {
            var scene = SceneManager.GetActiveScene();
            var menuRoot = FindMenuRoot(scene);

            foreach (Transform child in menuRoot.transform) 
                ProcessChildScreen(child);
            
            Debug.Log("Success");
        }

        private static void ProcessChildScreen(Transform child)
        {
            foreach (var screenName in _screens.Keys)
            {
                if (child.name.ToLower().Contains(screenName))
                {
                    var type = _screens[screenName];
                    if (!child.gameObject.GetComponent(type))
                        child.gameObject.AddComponent(type);
                    
                    var component = child.gameObject.GetComponent(type);
                    TopmostComponentHandler.CorrectComponentOrder(component);
                }
            }
        }

        private static RectTransform FindMenuRoot(Scene scene) =>
            scene
                .Find<Canvas>()
                .GetComponent<RectTransform>();
    }
}