using System.Linq;
using Infrastructure.Common;
using Infrastructure.Core;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services
{
    public class ConfigurationService : MonoService, IInitializableService
    {
        [SerializeField] public Configuration Configuration;
        
        private TypedDictionary<SettingsBase> _settingsCache = new TypedDictionary<SettingsBase>();

        public TSettings GetSettings<TSettings>() where TSettings : SettingsBase
        {
            return _settingsCache.Get<TSettings>();
        }

        public void Initialize()
        {
            Configuration.Modules.ForEach(CacheModuleSettings);
        }

        private void CacheModuleSettings(SettingsModule settingsModule)
        {
            if (settingsModule)
            {
                settingsModule.Settings
                    .Where(settings => settings)
                    .ToList()
                    .ForEach(settings => _settingsCache.Register(settings.GetType(), settings));
            }
        }
    }
}