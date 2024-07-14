using Infrastructure.Common;
using Infrastructure.Screens;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public static class CollectTools
    {
        [MenuItem("Tools/ Collect Screens")]
        public static void CollectScreens()
        {
            var screenLocator = FindScreenLocator();
            if (screenLocator)
            {
                screenLocator.CollectScreens();
                Logger.LogColored("Done", Color.green);
            }
        }
        
        [MenuItem(Constants.Tools.CollectMetaConfiguration)]
        public static void CollectMetaConfiguration()
        {
            var configuration = EditorExtensions.GetSingleByName<Configuration>(Constants.Configuration.MetaConfiguration);
            if (configuration)
            {
                var assetPath = AssetDatabase.GetAssetPath(configuration);
                configuration.CollectSettings(assetPath);
                
                Logger.LogColored("Done", Color.green);
            }
        }

        private static ScreenLocator FindScreenLocator()
        {
            var scene = SceneManager.GetActiveScene();
            return scene.Find<ScreenLocator>();
        }
    }
}