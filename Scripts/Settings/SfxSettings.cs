using Core.Sfx;
using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "SfxSettings")]
    public class SfxSettings : SettingsBase
    {
        [SerializeField] public SfxType BackMusic;
        
        [Space]
        [SerializeField] public SfxType Click;
        [SerializeField] public SfxType WinGame;
        [SerializeField] public SfxType LoseGame;
    }
}