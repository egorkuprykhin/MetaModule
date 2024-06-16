using System;
using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class ScoresService : IInitializableService
    {
        private ConfigurationService _configurationService;
        private GameFinisherService _gameFinisher;
        private CommonSettings _commonSettings;

        public int Scores { get; private set; }
        
        public int MaxScores { get; private set; }
        
        public event Action<int> ScoresAdded;

        public void Initialize()
        {
            _gameFinisher = ServiceLocator.GetService<GameFinisherService>();
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _commonSettings = _configurationService.GetSettings<CommonSettings>();
        }

        public void ResetScores()
        {
            Scores = 0;
            MaxScores = _commonSettings.ScoresToWin;
        }

        public void AddScores(int matchesCount)
        {
            int scores = matchesCount * _commonSettings.ScoresForMatch;
            Scores += scores;
            
            ScoresAdded?.Invoke(scores);

            if (Scores >= MaxScores)
                WinGameByScores();
        }

        private void WinGameByScores()
        {
            _gameFinisher.FinishGame();
        }
    }
}