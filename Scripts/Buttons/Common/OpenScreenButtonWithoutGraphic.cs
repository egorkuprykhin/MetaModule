using Infrastructure.ButtonActions;
using UnityEngine;

namespace Core.MetaModule.Scripts.Buttons
{
    [RequireComponent(typeof(OpenScreenButtonAction))]
    [RequireComponent(typeof(PauseGameButtonAction))]
    public class OpenScreenButtonWithoutGraphic : ButtonBaseWithoutGraphic
    {
    }
}