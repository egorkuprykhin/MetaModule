using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class RegenerateMetaTool : EditorWindow
    {
        private Object _dotween;
        private Object _unitask;
        private Object _uiparticle;
        private Object _scriptsMeta;
        private Object _scriptsCore;

        [MenuItem("Tools/CoreObjectsGenerator")]
        public new static void Show()
        {
            EditorWindow window = GetWindow<RegenerateMetaTool>("Meta tool");
            window.Show();
        }
        
        [MenuItem("Tools/Regenerate meta")]
        public static void RegenerateMetaWindow()
        {
            // Delete all meta files in project
            var allAssetPaths = AssetDatabase.GetAllAssetPaths();
            foreach (var path in allAssetPaths)
            {
                var metaPath = path + ".meta";
                if (AssetDatabase.LoadAssetAtPath<Object>(metaPath))
                    AssetDatabase.DeleteAsset(metaPath);
            }

            AssetDatabase.Refresh();
        }
    }
}