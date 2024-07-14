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
        
        [MenuItem("Tools/ Collect Configuration")]
        public static void CollectConfiguration()
        {
            var configuration = EditorExtensions.GetSingleByName<Configuration>("_Configuration");
            if (configuration)
            {
                var assetPath = AssetDatabase.GetAssetPath(configuration);
                configuration.Collect(assetPath);
                
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