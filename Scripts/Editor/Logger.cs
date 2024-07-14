using UnityEngine;

namespace Editor
{
    public static class Logger
    {
        public static void LogColored(string message, Color color)
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>");
        }
    }
}