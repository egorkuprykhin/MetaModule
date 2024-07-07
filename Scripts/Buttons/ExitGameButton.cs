using Infrastructure.ButtonActions;
using Infrastructure.Components;
using UnityEngine;

namespace Core.MetaModule.Scripts.Buttons
{
    [RequireComponent(typeof(PlayClickSfxButtonAction))]
    [RequireComponent(typeof(ExitGameButtonAction))]
    [RequireComponent(typeof(EmptyGraphic))]
    public class ExitGameButton : MonoBehaviour
    {
    }
}