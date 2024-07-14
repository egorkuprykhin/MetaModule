using System;
using System.Collections.Generic;
using System.Linq;
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
        [MenuItem(Constants.Tools.BuildScreens)]
        public static void BuildMenuScreens()
        {
            var designRoot = FindDesignRoot();

            foreach (Transform child in designRoot.transform) 
                ProcessChildScreen(child);
            
            Logger.LogColored("Done", Color.green);
        }

        private static void ProcessChildScreen(Transform child)
        {
            var screens = ScreensHelper.GetScreens();
            foreach (var screenName in screens.Keys)
            {
                if (child.name.ToLower().Contains(screenName))
                {
                    var type = screens[screenName];
                    if (!child.gameObject.GetComponent(type))
                        child.gameObject.AddComponent(type);
                    
                    var component = child.gameObject.GetComponent(type);
                    TopmostComponentHandler.CorrectComponentOrder(component);
                }
            }
        }

        private static GameObject FindDesignRoot()
        {
            var scene = SceneManager.GetActiveScene();
            return scene.GetRootGameObjects().First(x => x.GetComponent<Canvas>());
        }
    }
}