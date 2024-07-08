using System.Collections.Generic;
using Infrastructure.Common;
using Infrastructure.Screens.Internal;
using UnityEditor;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class ScreenLocator : ScreenLocatorBase, IInitializable
    {
        [SerializeField] private List<ScreenBase> Screens;

        public new static TScreen GetScreen<TScreen>()
            where TScreen : ScreenBase =>
            ScreenLocatorBase.GetScreen<TScreen>();

        public void Register() => Screens.ForEach(Register);

        public new void Initialize() => base.Initialize();
        
#if UNITY_EDITOR
        public void CollectScreens()
        {
            var screens = Resources.FindObjectsOfTypeAll<ScreenBase>();
            Screens = new List<ScreenBase>(screens);
            
            EditorUtility.SetDirty(this);
        }
#endif
    }
}