using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor
{
    public static class AssignScriptsProcessor
    {
        public static void ProcessAsset<T>(string name = null) where T : Object
        {
            name ??= typeof(T).Name;
            var guids = AssetDatabase.FindAssets(name);
            var assetPaths = guids.Select(AssetDatabase.GUIDToAssetPath).ToArray();
            var assetPath = assetPaths.First(path => path.Contains(".asset"));
            
            var systemPath = Application.dataPath + assetPath.Replace("Assets", "");
            var scriptPath = GetScriptPath<T>();

            var guid = GetGuidFromOriginalAsset(systemPath);
            var metaGuid = GetGuidFromScriptMeta(scriptPath);
            
            Debug.Log($"{typeof(T).Name} processed");
            
            ReplaceGuidInFile(systemPath, guid, metaGuid);

            var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssetIfDirty(asset);
        }

        private static string GetScriptPath<T>()
        {
            var name = $"{typeof(T).Name}.cs";
            string[] res = Directory.GetFiles(Application.dataPath, name, SearchOption.AllDirectories);
            return res[0];
        }

        private static string GetGuidFromOriginalAsset(string path)
        {
            using var streamReader = new StreamReader(path);
            while (streamReader.ReadLine() is {} line)
            {
                if (line.Contains("m_Script:") && line.Contains("guid"))
                    return line.Substring(line.IndexOf("guid: ", StringComparison.Ordinal) + 6, 32);
            }

            return null;
        }
        
        private static string GetGuidFromScriptMeta(string path)
        {
            var metaPath = path + ".meta";
            using var streamReader = new StreamReader(metaPath);
            while (streamReader.ReadLine() is {} line)
            {
                if (line.StartsWith("guid:"))
                    return line.Substring(line.IndexOf("guid: ", StringComparison.Ordinal) + 6, 32);
            }

            return null;
        }
        
        private static void ReplaceGuidInFile(string path, string guid, string newGuid)
        {
            string text = File.ReadAllText(path);
            text = text.Replace(guid, newGuid);
            File.WriteAllText(path, text);
        }
    }
}