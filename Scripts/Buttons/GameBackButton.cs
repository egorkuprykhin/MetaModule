using Infrastructure.ButtonActions;
using UnityEngine;

namespace Core.MetaModule.Scripts.Buttons
{
    [RequireComponent(typeof(PlayClickSfxButtonAction))]
    [RequireComponent(typeof(OpenScreenButtonAction))]
    [RequireComponent(typeof(StopGameButtonAction))]
    public class GameBackButton : MonoBehaviour
    {
    }
}