using System.Linq;
using Infrastructure.Common;

namespace Infrastructure.Core
{
    public class ConfigurationProxy
    {
        private TypedDictionary<SettingsBase> _settingsCache = new TypedDictionary<SettingsBase>();
        private Configuration _configuration;

        public ConfigurationProxy(Configuration configuration)
        {
            _configuration = configuration;
            CacheModules();
        }
        
        public TSettings GetSettings<TSettings>() where TSettings : SettingsBase
        {
            return _settingsCache.Get<TSettings>();
        }

        private void CacheModules()
        {
            _configuration.Modules.ForEach(CacheModuleSettings);
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