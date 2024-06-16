using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Core
{
    [CreateAssetMenu(fileName = "SettingsModule")]
    public class SettingsModule : ScriptableObject
    {
        [SerializeField] public List<SettingsBase> Settings;
    }
}