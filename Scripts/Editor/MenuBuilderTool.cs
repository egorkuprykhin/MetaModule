using System;
using System.Collections.Generic;
using Infrastructure.Attributes.Internal;
using Infrastructure.Screens;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public static class MenuBuilderTool
    {
        private const string Loading = "loading";
        private const string Start = "start";
        private const string Menu = "menu";
        private const string Policy = "policy";
        private const string Options = "options";
        private const string Levels = "levels";
        private const string Game = "game";
        private const string Result = "result";
        private const string Exit = "exit";

        private static Dictionary<string, Type> _screens = new Dictionary<string, Type>
        {
            { Loading, typeof(LoadingScreen) },
            { Start, typeof(StartScreen) },
            { Menu, typeof(MenuScreen) },
            { Policy, typeof(PolicyScreen) },
            { Options, typeof(OptionsScreen) },
            { Levels, typeof(LevelsScreen) },
            { Game, typeof(GameScreen) },
            { Result, typeof(ResultScreen) },
            { Exit, typeof(ExitScreen) }
        };


        [MenuItem("Tools/Build Menu Screens")]
        public static void BuildMenu()
        {
            var scene = SceneManager.GetActiveScene();
            var menuRoot = FindMenuRoot(scene);

            foreach (Transform child in menuRoot.transform) 
                ProcessChildScreen(child);
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