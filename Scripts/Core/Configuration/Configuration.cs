using System.Collections.Generic;
using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Common
{
    [CreateAssetMenu(order = 0)]
    public class Configuration : ScriptableObject
    {
        [SerializeField] public List<SettingsModule> Modules;
    }
}