using Infrastructure.Attributes;
using Infrastructure.ButtonActions;
using UnityEngine;

namespace Core.MetaModule.Scripts.Buttons
{
    [TopmostComponent(Order = 0)]
    [RequireComponent(typeof(PlayClickSfxButtonAction))]
    public class ButtonBase : MonoBehaviour
    {
    }
}