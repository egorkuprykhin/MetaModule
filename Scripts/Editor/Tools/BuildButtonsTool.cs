using System;
using Infrastructure.Attributes;
using Infrastructure.ButtonActions;
using Infrastructure.Common;
using Infrastructure.Core;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor
{
    public static class BuildButtonsTool
    {
        [MenuItem(Constants.Tools.BuildButtons)]
        public static void BuildButtons()
        {
            var buttonsBinder = Object.FindObjectOfType<ButtonsBinder>();
            if (buttonsBinder)
            {
                buttonsBinder.ButtonsBindings.ForEach(binding =>
                {
                    Type buttonType = ScreensHelper.GetButtonTypeByBinding(binding);

                    var buttonComponent = binding.Button.GetOrAddComponent(buttonType);

                    if (binding.BindingType == ButtonBindingType.OpenScreen)
                    {
                        var openScreenAction = binding.Button.GetComponent<OpenScreenAction>();
                        openScreenAction.Screen = binding.Screen;
                    }
                    
                    TopmostComponentHandler.CorrectComponentOrder(buttonComponent);
                });
                
                Logger.LogColored("Done", Color.green);
            }
            else
            {
                Logger.LogColored("ButtonsBinder not found", Color.red);
            }
        }
    }
}