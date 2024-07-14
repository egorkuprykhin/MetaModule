using Infrastructure.Common;
using Infrastructure.Core;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class CreateButtonsBinderTool
    {
        [MenuItem(Constants.Tools.CreateButtonsBinder)]
        public static void CreateButtonsBinder()
        {
            ButtonsBinder buttonsBinder = Object.FindObjectOfType<ButtonsBinder>();
            
            if (!buttonsBinder) 
                buttonsBinder = new GameObject("ButtonsBinder")
                    .GetOrAddComponent<ButtonsBinder>();
            
            buttonsBinder.CollectBindings();
            
            Selection.activeGameObject = buttonsBinder.gameObject;
            
            Logger.LogColored("Done", Color.green);
        }
    }
}