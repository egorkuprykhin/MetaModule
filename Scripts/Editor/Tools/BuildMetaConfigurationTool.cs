using Infrastructure.Common;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class BuildMetaConfigurationTool
    {
        [MenuItem(Constants.Tools.BuildMetaConfiguration)]
        public static void CollectMetaConfiguration()
        {
            var configuration = EditorExtensions.GetSingleByName<Configuration>(Constants.MetaConfiguration);
            if (configuration)
            {
                var assetPath = AssetDatabase.GetAssetPath(configuration);
                configuration.CollectSettings(assetPath);
                
                Logger.LogColored("Done", Color.green);
            }
        }
    }
}