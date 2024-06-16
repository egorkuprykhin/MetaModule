using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "CommonSettings")]
    public class CommonSettings : SettingsBase
    {
        [SerializeField] public int ScoresForMatch;
        [SerializeField] public int ScoresToWin;
        
        [SerializeField] public int InitialLevelTime;
        [SerializeField] public bool TimerFromZero;
        [SerializeField] public int LevelsCount;
        [SerializeField] public string WinText;
        [SerializeField] public string LoseText;
    }
}