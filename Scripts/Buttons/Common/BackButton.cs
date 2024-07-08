using Infrastructure.ButtonActions;
using UnityEngine;

namespace Core.MetaModule.Scripts.Buttons
{
    [RequireComponent(typeof(OpenPreviousScreenButtonAction))]
    [RequireComponent(typeof(PauseGameButtonAction))]
    public class BackButton : ButtonBase
    {
    }
}