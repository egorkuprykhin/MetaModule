using System;
using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class ScoresService : IInitializableService
    {
        private ConfigurationService _configurationService;
        private CommonSettings _commonSettings;
        
        public int Scores { get; private set; }
        
        public event Action<int> ScoresAdded;

        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _commonSettings = _configurationService.GetSettings<CommonSettings>();
        }

        public void ResetScores()
        {
            Scores = 0;
        }

        public void AddScores(int matchesCount)
        {
            int scores = matchesCount * _commonSettings.MatchedCellScores;
            Scores += scores;
            
            ScoresAdded?.Invoke(scores);
        }
    }
}