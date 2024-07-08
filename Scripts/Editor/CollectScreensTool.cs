using Infrastructure.Screens;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Editor
{
    public static class CollectScreensTool
    {
        [MenuItem("Tools/ Collect Screens")]
        public static void CollectScreens()
        {
            var screenLocator = FindScreenLocator();
            if (screenLocator)
                screenLocator.CollectScreens();
        }

        private static ScreenLocator FindScreenLocator()
        {
            var scene = SceneManager.GetActiveScene();
            return scene.Find<ScreenLocator>();
        }
    }
}