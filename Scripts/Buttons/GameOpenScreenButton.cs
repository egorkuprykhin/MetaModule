using Infrastructure.ButtonActions;
using UnityEngine;

namespace Core.MetaModule.Scripts.Buttons
{
    [RequireComponent(typeof(PauseGameButtonAction))]
    [RequireComponent(typeof(PlayClickSfxButtonAction))]
    [RequireComponent(typeof(OpenScreenButtonAction))]
    public class GameOpenScreenButton : MonoBehaviour
    {
    }
}