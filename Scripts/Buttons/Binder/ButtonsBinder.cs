using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Core
{
    public class ButtonsBinder : MonoBehaviour
    {
        [SerializeField] public List<ButtonBindingEntry> ButtonsBindings;
        
#if UNITY_EDITOR
        public void CollectBindings()
        {
            ButtonsBindings = new List<ButtonBindingEntry>();

            var scene = SceneManager.GetActiveScene();
            var canvas = scene.GetRootGameObjects().First(x => x.GetComponent<Canvas>());
            
            if (canvas)
            {
                var gameObjects = canvas.gameObject.GetComponentsInChildren<Transform>(true);
                foreach (var go in gameObjects)
                {
                    if (go.name.Contains("Button"))
                    {
                        ButtonsBindings.Add(new ButtonBindingEntry
                        {
                            Button = go.gameObject,
                            BindingType = ButtonBindingType.OpenScreen
                        });
                    }
                }
                
                EditorUtility.SetDirty(this);
            }
        }
#endif
    }
}