using Infrastructure.ButtonActions;
using Infrastructure.Components;
using UnityEngine;

namespace Core.MetaModule.Scripts.Buttons
{
    [RequireComponent(typeof(PlayClickSfxButtonAction))]
    [RequireComponent(typeof(StartNextLevelButtonAction))]
    [RequireComponent(typeof(EmptyGraphic))]
    public class StartNextLevelButton : MonoBehaviour
    {
    }
}