using System.Collections.Generic;
using Infrastructure.Core;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Infrastructure.Common
{
    [CreateAssetMenu(order = 0)]
    public class Configuration : ScriptableObject
    {
        [SerializeField] public List<SettingsBase> Settings;

#if UNITY_EDITOR
        public void CollectSettings(string assetPath)
        {
            Settings.Clear();
            
            var folderPath = assetPath.Substring(0, assetPath.LastIndexOf('/'));
            
            var guids = AssetDatabase.FindAssets("t:SettingsBase", new[] {folderPath});
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var settings = AssetDatabase.LoadAssetAtPath<SettingsBase>(path);
                if (settings)
                    Settings.Add(settings);
            }
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssetIfDirty(this);
            AssetDatabase.Refresh();
        }
#endif
    }
}