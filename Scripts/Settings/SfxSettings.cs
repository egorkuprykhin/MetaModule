using Core.Sfx;
using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "SfxSettings")]
    public class SfxSettings : SettingsBase
    {
        public SfxType Click;
        public SfxType WinGame;
        public SfxType LoseGame;
    }
}