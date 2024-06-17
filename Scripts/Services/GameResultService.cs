using Core.Sfx;
using Infrastructure.Data;
using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class GameResultService : IInitializableService
    {
        private ConfigurationService _configurationService;
        private CommonSettings _commonSettings;
        private SfxSettings _sfxSettings;
        private TimerService _timerService;

        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _timerService = ServiceLocator.GetService<TimerService>();
            
            _commonSettings = _configurationService.GetSettings<CommonSettings>();
            _sfxSettings = _configurationService.GetSettings<SfxSettings>();
        }

        public GameResultData GameResultData { get; private set; } = new GameResultData();

        public void CalculateGameResult()
        {
            GameResultData.Result = GameResult.Win;
            GameResultData.FinishTime = _timerService.CurrentTime;
            GameResultData.Stars = CalculateStars();
        }

        public void ResetGameResult()
        {
            GameResultData = new GameResultData();
        }

        public string ResultText() => GameResultData.Result switch
        {
            GameResult.Win => _commonSettings.WinText,
            GameResult.Lose => _commonSettings.LoseText,
            _ => _commonSettings.WinText
        };

        public SfxType ResultSfx() => GameResultData.Result switch
        {
            GameResult.Win => _sfxSettings.WinGame,
            GameResult.Lose => _sfxSettings.LoseGame,
            _ => _sfxSettings.WinGame
        };
        
        private int CalculateStars()
        {
            if (GameResultData.FinishTime <= _commonSettings.Time3Stars)
                return 3;
            
            if (GameResultData.FinishTime <= _commonSettings.Time2Stars)
                return 2;

            return 1;
        }
    }
}