using Infrastructure.Common;
using Infrastructure.Settings;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class AssignMetaScriptsTool
    {
        [MenuItem(Constants.Tools.AssignMetaScripts)]
        public static void AssignScriptsToConfigs()
        {
            AssignScriptsProcessor.ProcessAsset<Configuration>(Constants.MetaConfiguration);
            AssignScriptsProcessor.ProcessAsset<CommonSettings>();
            AssignScriptsProcessor.ProcessAsset<LoadingSettings>();
            AssignScriptsProcessor.ProcessAsset<ScoresSettings>();
            AssignScriptsProcessor.ProcessAsset<SoundSettings>();
            AssignScriptsProcessor.ProcessAsset<TargetsSettings>();

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Logger.LogColored("Done", Color.green);
        }
    }
}