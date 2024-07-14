using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Editor
{
    public static class EditorExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (!component)
                component = gameObject.AddComponent<T>();

            return component;
        }
        
        public static Component GetOrAddComponent(this GameObject gameObject, Type type)
        {
            var component = gameObject.GetComponent(type);
            if (!component)
                component = gameObject.AddComponent(type);

            return component;
        }
        
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
            var filter = $"t:{typeof(T)}";
            var guids = AssetDatabase.FindAssets(filter);
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