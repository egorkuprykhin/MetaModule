using System;
using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class ScoresService : IInitializableService
    {
        private ConfigurationService _configurationService;
        private GameFinisherService _gameFinisher;
        private ScoresSettings _scoresSettings;

        public int Scores { get; private set; }
        
        public int MaxScores { get; private set; }
        
        public event Action<int> ScoresAdded;

        public void Initialize()
        {
            _gameFinisher = ServiceLocator.GetService<GameFinisherService>();
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _scoresSettings = _configurationService.GetSettings<ScoresSettings>();
        }

        public void ResetScores()
        {
            Scores = 0;
            MaxScores = _scoresSettings.ScoresToWin;
        }

        public void AddScores(int matchesCount)
        {
            int scores = matchesCount * _scoresSettings.ScoresForMatch;
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