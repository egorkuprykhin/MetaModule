using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class ClearPrefsTool
    {
        [MenuItem("Tools/Clear Saves")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}