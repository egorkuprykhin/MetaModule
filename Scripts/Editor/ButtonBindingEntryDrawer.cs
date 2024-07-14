using Infrastructure.Core;
using Infrastructure.Screens;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(ButtonBindingEntry))]
    public class ButtonBindingEntryDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty buttonProperty = property.FindPropertyRelative(nameof(ButtonBindingEntry.Button));
            SerializedProperty bindingTypeProperty = property.FindPropertyRelative(nameof(ButtonBindingEntry.BindingType));
            SerializedProperty screenProperty = property.FindPropertyRelative(nameof(ButtonBindingEntry.Screen));

            label.text = "Fix or delete this";
            if (buttonProperty != null)
            {
                var buttonObject = (GameObject)buttonProperty.objectReferenceValue;
                if (buttonObject)
                {
                    var parentScreen = buttonObject.GetComponentInParent<ScreenBase>();
                    if (parentScreen)
                    {
                        var buttonName = $"{parentScreen.name.Replace("Screen", "")}/{buttonObject.name.Replace("Button", "")}";
                        label.text = buttonName;
                    }
                }
            }
            
            var drawScreen = false;
            if (bindingTypeProperty != null)
            {
                var bindingType = (ButtonBindingType)bindingTypeProperty.enumValueIndex;
                if (bindingType == ButtonBindingType.OpenScreen)
                    drawScreen = true;
            }
            
            EditorGUI.BeginProperty(position, label, property);

            var prefixRect = new Rect(position.x, position.y, 100, position.height);
            var buttonObjectRect = new Rect(position.x + 110, position.y, 130, position.height);
            var buttonTypeRect   = new Rect(position.x + 110 + 140, position.y, 100, position.height);
            var screenRect = new Rect(position.x + 110 + 140 + 110, position.y, 100, position.height);

            EditorGUI.PrefixLabel(prefixRect, GUIUtility.GetControlID(FocusType.Passive), label);
            EditorGUI.PropertyField(buttonObjectRect, buttonProperty, GUIContent.none);
            EditorGUI.PropertyField(buttonTypeRect, bindingTypeProperty, GUIContent.none);
            if (drawScreen)
                EditorGUI.PropertyField(screenRect, screenProperty, GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}