using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public static class EditorExtensions
    {
        public static T Find<T>(this Scene scene)
        {
            foreach (var rootGameObject in scene.GetRootGameObjects())
                if (rootGameObject.TryGetComponent(out T component))
                    return component;
            
            foreach (var rootGameObject in scene.GetRootGameObjects())
            {
                var component = rootGameObject.GetComponentInChildren<T>();
                if (component != null)
                    return component;
            }

            return default;
        }
        
        public static T GetSingle<T>() where T : Object
        {
            var guids = AssetDatabase.FindAssets($"t:{typeof(T)}");
            var asset = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guids[0]));
            
            return asset;
        }
        
        public static T GetSingleByName<T>(string name) where T : Object
        {
            var guids = AssetDatabase.FindAssets($"t:{typeof(T)} {name}");
            var asset = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guids[0]));
            
            return asset;
        }
        
        public static List<T> GetAll<T>() where T : Object
        {
            List<T> list = new List<T>();
            
            var guids = AssetDatabase.FindAssets(
                filter: $"t:{typeof(T).Name}");

            foreach (string guid in guids)
            {
                var asset = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid));
                list.Add(asset);
            }
            
            return list;
        }
        
        public static List<T> GetAll<T>(string sourceFolder) where T : Object
        {
            List<T> list = new List<T>();
            
            var guids = AssetDatabase.FindAssets(
                filter: $"t:{typeof(T).Name}",
                searchInFolders: new [] {sourceFolder});

            foreach (string guid in guids)
            {
                var asset = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid));
                list.Add(asset);
            }
            
            return list;
        }
    }
}