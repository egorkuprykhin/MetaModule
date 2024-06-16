using Core.Sfx;
using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "CommonSfxSettings")]
    public class CommonSfxSettings : SettingsBase
    {
        public SfxType Click;
        public SfxType WinGame;
        public SfxType LoseGame;
    }
}