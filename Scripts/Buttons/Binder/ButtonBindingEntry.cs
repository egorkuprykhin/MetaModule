using System;
using Infrastructure.Screens;
using UnityEngine;

namespace Infrastructure.Core
{
    [Serializable]
    public class ButtonBindingEntry
    {
        public GameObject Button;
        public ButtonBindingType BindingType;
        public ScreenBase Screen;
    }
}