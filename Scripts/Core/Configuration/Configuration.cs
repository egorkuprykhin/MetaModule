using System.Collections.Generic;
using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Common
{
    [CreateAssetMenu(order = 0)]
    public class Configuration : ScriptableObject
    {
        [SerializeField] public List<SettingsBase> Settings;

#if UNITY_EDITOR
        public void Collect(string assetPath)
        {
            Settings.Clear();
            
            var folderPath = assetPath.Substring(0, assetPath.LastIndexOf('/'));
            
            var guids = UnityEditor.AssetDatabase.FindAssets("t:SettingsBase", new[] {folderPath});
            foreach (var guid in guids)
            {
                var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                var settings = UnityEditor.AssetDatabase.LoadAssetAtPath<SettingsBase>(path);
                if (settings)
                    Settings.Add(settings);
            }
        }
#endif
    }
}