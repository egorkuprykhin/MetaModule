using Infrastructure.Common;
using Infrastructure.Core;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class AssignScreenBindings
    {
        [MenuItem(Constants.Tools.AssignButtonBindings)]
        public static void AssignButtonsScreenBindings()
        {
            var buttonBinder = Object.FindObjectOfType<ButtonsBinder>();
            
            buttonBinder.ButtonsBindings.ForEach(binding =>
            {
                var buttonId = binding.Button.name.Replace("Button", "").ToLower();
                
                binding.BindingType = ScreensHelper.GetBindingTypeByButtonId(buttonId);
                
                if (binding.BindingType == ButtonBindingType.OpenScreen)
                {
                    var screen = ScreensHelper.GetScreenByButtonId(buttonId);
                    if (screen)
                        binding.Screen = screen;
                }
            });
        }
    }
}