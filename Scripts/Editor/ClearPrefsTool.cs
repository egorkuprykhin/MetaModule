using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class ClearPrefsTool
    {
        [MenuItem("Tools/Clear saves")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}